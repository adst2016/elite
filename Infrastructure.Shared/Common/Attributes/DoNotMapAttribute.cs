using System;

namespace Infrastructure.Shared.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DoNotMapAttribute : Attribute
    {
    }
}
