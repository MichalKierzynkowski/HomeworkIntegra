using FluentValidation;

namespace FirstExerciseWebMinimalApi;

public class PersonValidator : AbstractValidator<Person.Person>
{
    public PersonValidator()
    {
        RuleFor(t => t.Name).NotEmpty().WithMessage("Field Name can't be null")
            .Must(Name => IsStringContainsNumbers(Name)).WithMessage("Field Name cant' contains numbers!");

        RuleFor(t => t.City).NotEmpty().WithMessage("Field City can't be null")
            .Must(City => IsStringContainsNumbers(City)).WithMessage("Field City cant' contains numbers!");

        RuleFor(t => t.Street).NotEmpty().WithMessage("Field Street can't be null")
            .Must(Street => IsStringContainsNumbers(Street)).WithMessage("Field Street cant' contains numbers!");
        RuleFor(t => t.Surname).NotEmpty().WithMessage("Field Surname can't be null")
            .Must(Surname => IsStringContainsNumbers(Surname)).WithMessage("Field Surname cant' contains numbers!");
        

        RuleFor(t => t.HouseNumber).NotEmpty().WithMessage("Field House Number can't be null")
            .Must(HouseNumber => IsIntContainsDigits(HouseNumber))
            .WithMessage("Field House Number can't contains characters!");

        RuleFor(t => t.PostalCode).NotEmpty().WithMessage("Field Postal Code  can't be null")
            .Must(PostalCode => IsIntContainsDigits(PostalCode))
            .WithMessage("Field Postal COde can't contains characters!").Must(PostalCode=>IsPostalCodeHave5Digits(PostalCode)).WithMessage("Postal code must have 5 digitis!");

        RuleFor(t => t.BirthDate).NotEmpty().WithMessage("Field Birth Date  can't be null");

    }

    private bool IsStringContainsNumbers(string value)
    {
        if (!value.All(char.IsLetter)) return false;

        return true;
    }

    private bool IsIntContainsDigits(int value)
    {
        string valueAfterCasting = value.ToString();
        if (!valueAfterCasting.All(char.IsDigit))
        {
            return false;
        }

        return true;
    }

    private bool IsPostalCodeHave5Digits(int value)
    {
        string postalCode = value.ToString();
        if (postalCode.Length!=5)
        {
            return false;
        }

        return true;
    }
}