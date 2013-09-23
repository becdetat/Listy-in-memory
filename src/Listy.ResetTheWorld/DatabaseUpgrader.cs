using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DbUp;
using DbUp.Engine.Output;

namespace Listy.ResetTheWorld
{
    public class DatabaseUpgrader
    {
        public static void Upgrade(string connectionString, IUpgradeLog upgradeLog = null)
        {
            upgradeLog = upgradeLog ?? new ConsoleUpgradeLog();

            var upgrader = DeployChanges.To
                                        .SqlDatabase(connectionString)
                                        .WithScriptsEmbeddedInAssembly(Assembly.GetAssembly(typeof(DatabaseUpgrader)))
                                        .LogTo(upgradeLog)
                                        .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                throw new Exception("DB Upgrade failed", result.Error);
            }
        }
    }
}
