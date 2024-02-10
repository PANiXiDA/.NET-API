using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class StringRangeAttribute: ValidationAttribute
    {
        public string[]? AllowableValues { get; }

        public StringRangeAttribute(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException($"{nameof(enumType)} must be an Enum type");
            }

            AllowableValues = Enum.GetNames(enumType);
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            string strValue = value.ToString();
            return AllowableValues.Contains(strValue);
        }
    }
}
