﻿using System;

namespace CivModTool.Common
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