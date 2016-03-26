﻿namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Time"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(TimeUnitTypeConverter))]
    public struct TimeUnit : IUnit, IUnit<Time>, IEquatable<TimeUnit>
    {
        /// <summary>
        /// The TimeUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly TimeUnit Seconds = new TimeUnit(seconds => seconds, seconds => seconds, "s");

        /// <summary>
        /// The Hours unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Hours = new TimeUnit(hours => 3600 * hours, seconds => seconds / 3600, "h");

        /// <summary>
        /// The Minutes unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Minutes = new TimeUnit(minutes => 60 * minutes, seconds => seconds / 60, "min");

        /// <summary>
        /// The Nanoseconds unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Nanoseconds = new TimeUnit(nanoseconds => nanoseconds / 1000000000, seconds => 1000000000 * seconds, "ns");

        /// <summary>
        /// The Microseconds unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Microseconds = new TimeUnit(microseconds => microseconds / 1000000, seconds => 1000000 * seconds, "µs");

        /// <summary>
        /// The Milliseconds unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TimeUnit Milliseconds = new TimeUnit(milliseconds => milliseconds / 1000, seconds => 1000 * seconds, "ms");

        private readonly Func<double, double> toSeconds;
        private readonly Func<double, double> fromSeconds;
        internal readonly string symbol;

        public TimeUnit(Func<double, double> toSeconds, Func<double, double> fromSeconds, string symbol)
        {
            this.toSeconds = toSeconds;
            this.fromSeconds = fromSeconds;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.TimeUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.TimeUnit"/>
        /// </summary>
        public TimeUnit SiUnit => Seconds;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.TimeUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Seconds;

        public static Time operator *(double left, TimeUnit right)
        {
            return Time.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.TimeUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.TimeUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.TimeUnit"/>.</param>
	    public static bool operator ==(TimeUnit left, TimeUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.TimeUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.TimeUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.TimeUnit"/>.</param>
        public static bool operator !=(TimeUnit left, TimeUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="TimeUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="TimeUnit"/></returns>
        public static TimeUnit Parse(string text)
        {
            return UnitParser<TimeUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.TimeUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.TimeUnit"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="TimeUnit"/></param>
        /// <returns>True if an instance of <see cref="TimeUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out TimeUnit value)
        {
            return UnitParser<TimeUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Seconds.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toSeconds(value);
        }

        /// <summary>
        /// Converts a value from seconds.
        /// </summary>
        /// <param name="seconds">The value in Seconds</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double seconds)
        {
            return this.fromSeconds(seconds);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Time(<paramref name="value"/>, this)</returns>
        public Time CreateQuantity(double value)
        {
            return new Time(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Seconds
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Time quantity)
        {
            return FromSiUnit(quantity.seconds);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public string ToString(string format)
        {
            TimeUnit unit;
            var paddedFormat = UnitFormatCache<TimeUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<TimeUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(TimeUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is TimeUnit && Equals((TimeUnit)obj);
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