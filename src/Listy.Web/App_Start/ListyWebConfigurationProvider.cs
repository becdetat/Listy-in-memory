using System.Configuration;
using Listy.Core.Configuration;

namespace Listy.Web.App_Start
{
    public class ListyWebConfigurationProvider : IConfigurationProvider
    {
        public string ListyConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["listy"].ConnectionString; }
        }
    }
}