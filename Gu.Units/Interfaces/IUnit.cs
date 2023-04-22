namespace Gu.Units
{
    /// <summary>
    /// A unit of a quantity.
    /// 物理量的单位.
    /// </summary>
    public interface IUnit
    {
        /// <summary>
        /// Gets the default symbol.
        /// 单位的符号.
        /// </summary>
        string Symbol { get; }

        /// <summary>
        /// Gets the base unit.
        /// 其对应的国际单位（法语：Système International d'Unités 符号：SI）.
        /// </summary>
        IUnit SiUnit { get; }

        /// <summary>
        /// Converts a value to the base unit.
        /// 当前单位的值转换为国际单位的值.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The converted value.</returns>
        double ToSiUnit(double value);

        /// <summary>
        /// Converts a value from the base unit.
        /// 国际单位的值转化为当前单位的值.
        /// </summary>
        /// <param name="value">The value in base unit.</param>
        /// <returns>The converted value.</returns>
        double FromSiUnit(double value);

        /// <summary>
        /// Converts the unit to its string representation.
        /// 转化为字符串表示形式.
        /// </summary>
        /// <param name="format">How to format the return value.</param>
        /// <returns>The string representation of this instance.</returns>
        string ToString(SymbolFormat format);
    }
}
