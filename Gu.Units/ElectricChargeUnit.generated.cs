﻿namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.ElectricCharge"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(ElectricChargeUnitTypeConverter))]
    public struct ElectricChargeUnit : IUnit, IUnit<ElectricCharge>, IEquatable<ElectricChargeUnit>
    {
        /// <summary>
        /// The ElectricChargeUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly ElectricChargeUnit Coulombs = new ElectricChargeUnit(coulombs => coulombs, coulombs => coulombs, "C");

        /// <summary>
        /// The Nanocoulombs unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ElectricChargeUnit Nanocoulombs = new ElectricChargeUnit(nanocoulombs => nanocoulombs / 1000000000, coulombs => 1000000000 * coulombs, "nC");

        /// <summary>
        /// The Microcoulombs unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ElectricChargeUnit Microcoulombs = new ElectricChargeUnit(microcoulombs => microcoulombs / 1000000, coulombs => 1000000 * coulombs, "µC");

        /// <summary>
        /// The Millicoulombs unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ElectricChargeUnit Millicoulombs = new ElectricChargeUnit(millicoulombs => millicoulombs / 1000, coulombs => 1000 * coulombs, "mC");

        /// <summary>
        /// The Kilocoulombs unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ElectricChargeUnit Kilocoulombs = new ElectricChargeUnit(kilocoulombs => 1000 * kilocoulombs, coulombs => coulombs / 1000, "kC");

        /// <summary>
        /// The Megacoulombs unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ElectricChargeUnit Megacoulombs = new ElectricChargeUnit(megacoulombs => 1000000 * megacoulombs, coulombs => coulombs / 1000000, "MC");

        /// <summary>
        /// The Gigacoulombs unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ElectricChargeUnit Gigacoulombs = new ElectricChargeUnit(gigacoulombs => 1000000000 * gigacoulombs, coulombs => coulombs / 1000000000, "GC");

        private readonly Func<double, double> toCoulombs;
        private readonly Func<double, double> fromCoulombs;
        internal readonly string symbol;

        public ElectricChargeUnit(Func<double, double> toCoulombs, Func<double, double> fromCoulombs, string symbol)
        {
            this.toCoulombs = toCoulombs;
            this.fromCoulombs = fromCoulombs;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.ElectricChargeUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.ElectricChargeUnit"/>
        /// </summary>
        public ElectricChargeUnit SiUnit => Coulombs;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.ElectricChargeUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Coulombs;

        public static ElectricCharge operator *(double left, ElectricChargeUnit right)
        {
            return ElectricCharge.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.ElectricChargeUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricChargeUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ElectricChargeUnit"/>.</param>
	    public static bool operator ==(ElectricChargeUnit left, ElectricChargeUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.ElectricChargeUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricChargeUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ElectricChargeUnit"/>.</param>
        public static bool operator !=(ElectricChargeUnit left, ElectricChargeUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="ElectricChargeUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="ElectricChargeUnit"/></returns>
        public static ElectricChargeUnit Parse(string text)
        {
            return UnitParser<ElectricChargeUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ElectricChargeUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ElectricChargeUnit"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="ElectricChargeUnit"/></param>
        /// <returns>True if an instance of <see cref="ElectricChargeUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out ElectricChargeUnit value)
        {
            return UnitParser<ElectricChargeUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Coulombs.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toCoulombs(value);
        }

        /// <summary>
        /// Converts a value from coulombs.
        /// </summary>
        /// <param name="coulombs">The value in Coulombs</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double coulombs)
        {
            return this.fromCoulombs(coulombs);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new ElectricCharge(<paramref name="value"/>, this)</returns>
        public ElectricCharge CreateQuantity(double value)
        {
            return new ElectricCharge(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Coulombs
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(ElectricCharge quantity)
        {
            return FromSiUnit(quantity.coulombs);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public string ToString(string format)
        {
            ElectricChargeUnit unit;
            var paddedFormat = UnitFormatCache<ElectricChargeUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<ElectricChargeUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(ElectricChargeUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is ElectricChargeUnit && Equals((ElectricChargeUnit)obj);
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