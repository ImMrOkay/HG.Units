﻿namespace Gu.Units.Generator
{
    public class CustomConversionVm
    {
        public CustomConversionVm()
            : this(new CustomConversion("Unknown", "??", "??", "??"))
        {

        }
        public CustomConversionVm(CustomConversion conversion)
        {
            this.Conversion = conversion;
        }

        public CustomConversion Conversion { get; }
    }
}