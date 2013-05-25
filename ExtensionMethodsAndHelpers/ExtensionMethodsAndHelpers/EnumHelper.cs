using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ExtensionMethodsAndHelpers
{
    public static class EnumHelper
    {
        public static string GetEnumStringValue(this Enum value)
        {
            string output = null;
            Type type = value.GetType();

            //Check first in our cached results...

            //Look for our 'StringValueAttribute' 

            //in the field's custom attributes

            FieldInfo fi = type.GetField(value.ToString());
            EnumStringValue[] attrs =
               fi.GetCustomAttributes(typeof(EnumStringValue),
                                       false) as EnumStringValue[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }

            return output;
        }
    }

    public class EnumStringValue : System.Attribute
    {
        private string _value;

        public EnumStringValue(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

    }
}
