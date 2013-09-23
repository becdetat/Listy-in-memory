using System;
using FluentNHibernate.Automapping;

namespace Listy.Web.App_Start.nh
{
    class ListyAutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.Namespace == "Listy.Data.Entities";
        }

        public override bool IsComponent(Type type)
        {
            return false;
            //return type == typeof(Location);
        }
    }
}