﻿namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.SolidAngle"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(SolidAngleUnitTypeConverter))]
    public struct SolidAngleUnit : IUnit, IUnit<SolidAngle>, IEquatable<SolidAngleUnit>
    {
        /// <summary>
        /// The SolidAngleUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly SolidAngleUnit Steradians = new SolidAngleUnit(steradians => steradians, steradians => steradians, "sr");

        private readonly Func<double, double> toSteradians;
        private readonly Func<double, double> fromSteradians;
        internal readonly string symbol;

        public SolidAngleUnit(Func<double, double> toSteradians, Func<double, double> fromSteradians, string symbol)
        {
            this.toSteradians = toSteradians;
            this.fromSteradians = fromSteradians;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.SolidAngleUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.SolidAngleUnit"/>
        /// </summary>
        public SolidAngleUnit SiUnit => Steradians;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.SolidAngleUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Steradians;

        public static SolidAngle operator *(double left, SolidAngleUnit right)
        {
            return SolidAngle.From(left, right);
        }

        public static bool operator ==(SolidAngleUnit left, SolidAngleUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SolidAngleUnit left, SolidAngleUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="SolidAngleUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="SolidAngleUnit"/></returns>
        public static SolidAngleUnit Parse(string text)
        {
            return UnitParser<SolidAngleUnit>.Parse(text);
        }

        public static bool TryParse(string text, out SolidAngleUnit value)
        {
            return UnitParser<SolidAngleUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Steradians.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toSteradians(value);
        }

        /// <summary>
        /// Converts a value from steradians.
        /// </summary>
        /// <param name="steradians">The value in Steradians</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double steradians)
        {
            return this.fromSteradians(steradians);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new SolidAngle(<paramref name="value"/>, this)</returns>
        public SolidAngle CreateQuantity(double value)
        {
            return new SolidAngle(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Steradians
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(SolidAngle quantity)
        {
            return FromSiUnit(quantity.steradians);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public string ToString(string format)
        {
            SolidAngleUnit unit;
            var paddedFormat = UnitFormatCache<SolidAngleUnit>.GetOrCreate(format, out unit);
            if (unit != this)
            {
                return format;
            }

            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public string ToString(SymbolFormat format)
        {
            var paddedFormat = UnitFormatCache<SolidAngleUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(SolidAngleUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is SolidAngleUnit && Equals((SolidAngleUnit)obj);
        }

        /// <summary>
        /// Returns the hashcode for this <see cref="LengthUnit"/>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (this.symbol == null)
            {
                return 0; // Needed due to default ctor
            }

            return this.symbol.GetHashCode();
        }
    }
}