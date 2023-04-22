namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml.Serialization;

    /// <summary>
    /// An amount of a <see cref="IUnit"/>.
    /// 物理量.
    /// </summary>
    public interface IQuantity : IFormattable, IXmlSerializable
    {
        /// <summary>
        /// Gets the value in <see cref="SiUnit"/>.
        /// 国际单位的值.
        /// </summary>
        double SiValue { get; }

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>.
        /// 国际单位.
        /// </summary>
        IUnit SiUnit { get; }
        /// <summary>
        /// Returns a string with the <see cref="Length.SiValue"/> and <see cref="Length.SiUnit"/>.
        /// 将物理量的值格式化，支持实现了IFormatProvider接口的格式化机制，例如CultureInfo.
        /// </summary>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string rep
        /// resentation of the <see cref="Length"/>.</returns>
        string ToString(IFormatProvider formatProvider);

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??}爗unit: ??}.
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 m\".</param>
        /// <returns>The string representation of the <see cref="Length"/>.</returns>
        string ToString(string format);

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??}爗unit: ??}.
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2.</param>
        /// <param name="symbolFormat">For formatting of the unit ex m.</param>
        /// <returns>The string representation of the <see cref="Length"/>.</returns>
        string ToString(string valueFormat, string symbolFormat);

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??}爗unit: ??}.
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2.</param>
        /// <param name="symbolFormat">For formatting the unit ex m.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the <see cref="Length"/>.</returns>
        string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider);
    }
}
