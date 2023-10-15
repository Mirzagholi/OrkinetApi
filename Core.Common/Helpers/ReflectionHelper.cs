using Core.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Core.Common.Helpers
{
    public static class ReflectionHelper
    {
        //public static string GetAttrName(object objClass)
        //{
        //    Attribute[] propertyAttributes;
        //    foreach (var property in objClass.GetType().GetProperties())
        //    {
        //        propertyAttributes = Attribute.GetCustomAttributes(property);
        //    }

        //    return string.Empty;
        //}

        public static void GetAttr(object obj)
        {
            try
            {
                var r = obj.GetType().Name.GetType().GetProperties();

            var ee=    SpInfoAttribute.GetCustomAttribute(r.GetType(), obj.GetType().Name.GetType());

                System.Attribute[] attrs = System.Attribute.GetCustomAttributes(r.GetType());  // Reflection.  

                // Displaying output.  
                foreach (System.Attribute attr in attrs)
                {
                    if (attr is SpInfoAttribute)
                    {
                        SpInfoAttribute a = (SpInfoAttribute)attr;
                        var res = a.SpName;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            
            

        }


        public static SpInfoAttribute GetSpAttribute(Type t)
        {
            SpInfoAttribute[] attrs = (SpInfoAttribute[])Attribute.GetCustomAttributes(t, typeof(SpInfoAttribute));

            if (attrs.Length > 0)
            {
                return attrs[0];
            }
            return null;
        }

    }
}
