namespace Listy.Core.Configuration
{
    public interface IConfigurationProvider
    {
        string ListyConnectionString { get; }
    }
}