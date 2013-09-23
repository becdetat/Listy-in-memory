param([switch]$UpdateOnly)

$SqlServer= "(local)"
$Database = "Listy"
$DataProjectName = "Listy.ResetTheWorld"
$DataProjectPath = "src\$DataProjectName"

Write-Host -ForegroundColor Green "Building Data Project"
. C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild $DataProjectPath\$DataProjectName.csproj /verbosity:quiet /nologo /property:Platform=AnyCpu
if(!$?) { exit 1; }

[System.Reflection.Assembly]::LoadWithPartialName("Microsoft.SqlServer.SMO") | out-null;
if(!$?) { 
	throw "Exception loading SMO";
}

$dataAssembly = [System.Reflection.Assembly]::LoadFrom("$DataProjectPath\bin\Debug\$DataProjectName.dll") | out-null;
if(!$?) { throw "Error loading data dll"; }

$SmoServer = New-Object Microsoft.SqlServer.Management.Smo.Server($SqlServer);

if($UpdateOnly -eq $False)
{
	if ($SmoServer.Databases[$Database] -eq $null)  
	{  
		Write-Host -ForegroundColor Yellow  "Database does not exist";
	} 
	else	
	{
		Write-Host -ForegroundColor Green  "Dropping database $Database on $SqlServer";
		$SmoServer.KillDatabase($Database);
		Write-Host -ForegroundColor Green  "Dropped";
	}

	Write-Host -ForegroundColor Green "Recreating Database"
	$databaseObj = New-Object ('Microsoft.SqlServer.Management.Smo.Database') -argumentlist $SmoServer, $Database;
	$databaseObj.Create();
	if(!$?) { exit 1; }
}

Write-Host -ForegroundColor Green "Setting Connection String"

$connectionString = "Data Source=$SqlServer;Initial Catalog=$Database;Trusted_Connection=True;MultipleActiveResultSets=True"
Write-Host -ForegroundColor DarkGray "Connection String:"
Write-Host -ForegroundColor DarkGray "$connectionString"
if(!$?) { exit 1; }

Write-Host -ForegroundColor Green "Updating Database"
[Listy.ResetTheWorld.DatabaseUpgrader]::Upgrade($connectionString);
if(!$?) { exit 1; }
