using System;
using System.ComponentModel;

namespace Listy.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var descriptionAttributeArray =
                (DescriptionAttribute[])
                value.GetType().GetField((value).ToString()).GetCustomAttributes(typeof (DescriptionAttribute), false);
            if (descriptionAttributeArray.Length <= 0)
                return (value).ToString();

            return descriptionAttributeArray[0].Description;
        }
    }
}