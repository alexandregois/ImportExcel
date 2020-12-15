using System;

namespace ImportExcel.Domain.Utils.CustomDataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class Column : Attribute
    {
        public int Value { get; private set; }
        public Column(int value)
        {
            this.Value = value;
        }
    }
}
