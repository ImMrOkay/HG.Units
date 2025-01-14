#nullable enable
namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Length"/>.
    /// Contains logic for conversion and formatting.
    /// 长度单位
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(LengthUnitTypeConverter))]
    public struct LengthUnit : IUnit, IUnit<Length>, IEquatable<LengthUnit>
    {
        /// <summary>
        /// The Metres unit
        /// Contains logic for conversion and formatting.
        /// 米
        /// </summary>
        public static readonly LengthUnit Metres = new LengthUnit(metres => metres, metres => metres, "m");

        /// <summary>
        /// The Inches unit
        /// Contains conversion logic to from and formatting.
        /// 英寸
        /// </summary>
        public static readonly LengthUnit Inches = new LengthUnit(inches => 0.0254 * inches, metres => metres / 0.0254, "in");

        /// <summary>
        /// The Miles unit
        /// Contains conversion logic to from and formatting.
        /// 英里
        /// </summary>
        public static readonly LengthUnit Miles = new LengthUnit(miles => 1609.344 * miles, metres => metres / 1609.344, "mi");

        /// <summary>
        /// The Yards unit
        /// Contains conversion logic to from and formatting.
        /// 码
        /// </summary>
        public static readonly LengthUnit Yards = new LengthUnit(yards => 0.9144 * yards, metres => metres / 0.9144, "yd");

        /// <summary>
        /// The NauticalMiles unit
        /// Contains conversion logic to from and formatting.
        /// 海里
        /// </summary>
        public static readonly LengthUnit NauticalMiles = new LengthUnit(nauticalMiles => 1852 * nauticalMiles, metres => metres / 1852, "nmi");

        /// <summary>
        /// The Feet unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LengthUnit Feet = new LengthUnit(feet => 0.3048 * feet, metres => metres / 0.3048, "ft");

        /// <summary>
        /// The Nanometres unit
        /// Contains conversion logic to from and formatting.
        /// 纳米
        /// </summary>
        public static readonly LengthUnit Nanometres = new LengthUnit(nanometres => nanometres / 1000000000, metres => 1000000000 * metres, "nm");

        /// <summary>
        /// The Micrometres unit
        /// Contains conversion logic to from and formatting.
        /// 微米
        /// </summary>
        public static readonly LengthUnit Micrometres = new LengthUnit(micrometres => micrometres / 1000000, metres => 1000000 * metres, "μm");

        /// <summary>
        /// The Millimetres unit
        /// Contains conversion logic to from and formatting.
        /// 毫米
        /// </summary>
        public static readonly LengthUnit Millimetres = new LengthUnit(millimetres => millimetres / 1000, metres => 1000 * metres, "mm");

        /// <summary>
        /// The Centimetres unit
        /// Contains conversion logic to from and formatting.
        /// 厘米
        /// </summary>
        public static readonly LengthUnit Centimetres = new LengthUnit(centimetres => centimetres / 100, metres => 100 * metres, "cm");

        /// <summary>
        /// The Decimetres unit
        /// Contains conversion logic to from and formatting.
        /// 分米
        /// </summary>
        public static readonly LengthUnit Decimetres = new LengthUnit(decimetres => decimetres / 10, metres => 10 * metres, "dm");

        /// <summary>
        /// The Kilometres unit
        /// Contains conversion logic to from and formatting.
        /// 千米
        /// </summary>
        public static readonly LengthUnit Kilometres = new LengthUnit(kilometres => 1000 * kilometres, metres => metres / 1000, "km");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.LengthUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toMetres;
        private readonly Func<double, double> fromMetres;

        /// <summary>
        /// Initializes a new instance of the <see cref="LengthUnit"/> struct.
        /// </summary>
        /// <param name="toMetres">The conversion to <see cref="Metres"/>
        /// 第一个参数：其他长度转为国际单位m的算法
        /// </param>
        /// <param name="fromMetres">The conversion to <paramref name="symbol"/>
        /// 第二个参数：国际单位m的长度转为当前单位的算法
        /// </param>
        /// <param name="symbol">The symbol for the <see cref="Metres"/>
        /// 第三个参数：当前单位的字符串符号
        /// </param>
        public LengthUnit(Func<double, double> toMetres, Func<double, double> fromMetres, string symbol)
        {
            this.toMetres = toMetres;
            this.fromMetres = fromMetres;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.LengthUnit"/>.
        /// 单位的符号
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.LengthUnit"/>
        /// 对应的国际单位：米
        /// </summary>
        public LengthUnit SiUnit => Metres;

        /// <summary>
        /// 国际单位：米
        /// </summary>
        IUnit IUnit.SiUnit => Metres;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Length"/> that is the result from the multiplication.</returns>
        public static Length operator *(double left, LengthUnit right)
        {
            return Length.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.LengthUnit"/> instances are equal.
        /// 单位相等
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.LengthUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.LengthUnit"/>.</param>
        public static bool operator ==(LengthUnit left, LengthUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.LengthUnit"/> instances are not equal.
        /// 单位不等
        /// </summary>
        /// <returns>
        /// true if the quantities of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.LengthUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.LengthUnit"/>.</param>
        public static bool operator !=(LengthUnit left, LengthUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="LengthUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="LengthUnit"/></returns>
        public static LengthUnit Parse(string text)
        {
            return UnitParser<LengthUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.LengthUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.LengthUnit"/></param>
        /// <param name="result">The parsed <see cref="LengthUnit"/></param>
        /// <returns>True if an instance of <see cref="LengthUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out LengthUnit result)
        {
            return UnitParser<LengthUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Metres.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toMetres(value);
        }

        /// <summary>
        /// Converts a value from metres.
        /// </summary>
        /// <param name="metres">The value in Metres</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double metres)
        {
            return this.fromMetres(metres);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Length(<paramref name="value"/>, this)</returns>
        public Length CreateQuantity(double value)
        {
            return new Length(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Metres
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(Length quantity)
        {
            return this.FromSiUnit(quantity.metres);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.symbol;
        }

        /// <summary>
        /// Converts the unit value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="format">The format to use when converting</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string format)
        {
            LengthUnit unit;
            var paddedFormat = UnitFormatCache<LengthUnit>.GetOrCreate(format, out unit);
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

        /// <summary>
        /// Converts the unit value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(SymbolFormat symbolFormat)
        {
            var paddedFormat = UnitFormatCache<LengthUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.LengthUnit"/> object.
        /// 单位相等：符号相等，则认为单位相等
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.LengthUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same LengthUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(LengthUnit other)
        {
            return this.symbol == other.symbol;
        }

        /// <summary>
        /// 单位相等
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            return obj is LengthUnit other && this.Equals(other);
        }

        /// <summary>
        /// 哈希值
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (this.symbol is null)
            {
                return 0; // Needed due to default constructor
            }

            return this.symbol.GetHashCode();
        }
    }
}
