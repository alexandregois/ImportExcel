using System;

namespace ImportExcel.Domain.Utils.CustomDataAnnotations
{
    public sealed class Round : Attribute
    {
        public int Value { get; private set; }

        public Round(int value)
        {
            this.Value = value;
        }
    }
}
