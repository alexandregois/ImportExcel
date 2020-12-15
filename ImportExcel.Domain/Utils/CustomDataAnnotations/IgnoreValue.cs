using System;

namespace ImportExcel.Domain.Utils.CustomDataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreValue : Attribute { }
}
