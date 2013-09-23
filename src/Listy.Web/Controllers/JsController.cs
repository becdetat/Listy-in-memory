using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Listy.Core.Extensions;

namespace Listy.Web.Controllers
{
    public class JsController : Controller
    {
        private readonly Type[] _enumTypes;

        public JsController()
        {
            _enumTypes = new Type[]
                {
                    //typeof (QuestionType),
                };
        }

        public ActionResult Enums()
        {
            var sb = new StringBuilder();
            sb.AppendLine("var Enums = Enums || {};");

            foreach (var type in _enumTypes)
            {
                sb.AppendLine(CreateEnumJson(type));
            }

            return Content(sb.ToString(), "application/json");
        }

        static string CreateEnumJson(Type type)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Enums.{0} = {{".FormatWith(type.Name));

            var allValues = Enum.GetValues(type).Cast<object>()
                .ToArray()
                ;

            foreach (var value in allValues)
            {
                sb.AppendLine(
                    "\t\"{0}\": {{ name: \"{0}\", value: {1}, description: \"{2}\" }},".FormatWith(
                        value, (int)value, ((Enum)value).GetDescription()));
            }

            sb.AppendLine("};");
            sb.AppendFormat("Enums.{0}.allValues = [\r\n", type.Name);
            sb.AppendLine(
                string.Join(",\r\n", allValues
                    .Select(v => "\tEnums.{0}['{1}']".FormatWith(type.Name, v)))
                );
            sb.AppendLine("]");
            return sb.ToString();
        }
    }
}
