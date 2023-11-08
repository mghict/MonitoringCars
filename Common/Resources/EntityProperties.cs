using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Resources
{

    public class EntityProperties
    {
        public static string GetPropertyName(string key)
        {
            return values[key] ?? "";
        }

        private static Dictionary<string, string> values = new Dictionary<string, string>
        {
            ["DeviceId"]="کد دستگاه",
            ["OperationCode"] ="کد عملیات",
            ["ExecutiveOperationCode"] ="کد اجرایی عملیات"
        };
    }
}
