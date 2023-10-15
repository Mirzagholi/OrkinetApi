using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public sealed class SpInfoAttribute : Attribute
    {
        public SpInfoAttribute (string spName)
        {
            SpName = spName;
        }
        public string SpName { get; }
    }

}
