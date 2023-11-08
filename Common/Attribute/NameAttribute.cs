using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Attribute
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                          System.AttributeTargets.Struct |
                          System.AttributeTargets.Property)
]
    public class NameOfAttribute : System.Attribute
    {
        public string Name;
        //public double Version;

        public NameOfAttribute(string name)//,double version=1.0)
        {
            Name = name;
            //Version = version;
        }
    }
}
