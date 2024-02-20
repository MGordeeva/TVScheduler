using System.ComponentModel.DataAnnotations;

namespace TVScheduler.Business.Helpers
{
    public class DateLessThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonPropertyName;

        public DateLessThanAttribute(string comparisonProperty)
        {
            _comparisonPropertyName = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var currentValue = (DateTime)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonPropertyName);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = (DateTime)property.GetValue(validationContext.ObjectInstance)!;

            if (currentValue > comparisonValue)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success!;
        }
    }
}
