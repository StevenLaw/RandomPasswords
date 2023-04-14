using System.ComponentModel;

namespace RandomPasswords.Model
{
    /// <summary>
    /// Itemizes the types of seperators to use.
    /// </summary>
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum SeperatorsMode
    {
        [Description("Numbers & Special Characters")]
        NumbersAndSpecial,

        Special,
        Numbers
    }
}