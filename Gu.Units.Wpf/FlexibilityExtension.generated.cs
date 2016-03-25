﻿namespace Gu.Units.Wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(Flexibility))]
    public class FlexibilityExtension : MarkupExtension
    {
        public FlexibilityExtension(Flexibility value)
        {
            this.Value = value;
        }

        public Flexibility Value { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}