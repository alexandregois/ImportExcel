using System;

namespace ImportExcel.Domain.Utils.CustomDataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class Row : Attribute
    {
        public int Value { get; private set; }
        public Row(int value)
        {
                this.Value = value;
        }
    }
}
