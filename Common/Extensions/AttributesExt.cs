using Common.Attribute;
using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Common.Extensions
{
    public static class AttributesExt
    {
        public static string DisplayName(this object en,string? fieldName)
        {
            //return "";
            //if(fieldName is null)
            //{
            //   return ((NameOfAttribute)en.GetType().GetCustomAttribute(typeof(NameOfAttribute))).Name;
            //}

            return ((NameOfAttribute)en.GetType().GetProperty(fieldName).GetCustomAttribute(typeof(NameOfAttribute))).Name ?? "";
        }

        public static string Description(this object en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return en.ToString();
        }
    }
}
