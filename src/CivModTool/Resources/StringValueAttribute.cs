using System;

namespace CivModTool.Resources
{
    [AttributeUsage(AttributeTargets.All)]
    public class StringValueAttribute : Attribute
    {
        public StringValueAttribute(string value)
        {
            StringValue = value;
        }

        public string StringValue { get; protected set; }
    }
}