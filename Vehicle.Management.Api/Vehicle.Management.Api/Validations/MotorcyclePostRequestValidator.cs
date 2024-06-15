using FluentValidation;
using Vehicle.Management.Api.Requests.Motorcycle;

namespace Vehicle.Management.Api.Validations
{
    public class MotorcyclePostRequestValidator : AbstractValidator<MotorcyclePostRequest>
    {
        private const string InvalidData = "30";

        public MotorcyclePostRequestValidator()
        {
            RuleFor(request => request.LicensePlate)
                .NotEmpty().WithErrorCode(InvalidData).WithMessage("LicencePlate is required.")
                .Matches(@"^[A-Z]{3}[0-9][A-Z][0-9]{2}$").WithMessage("Invalid license plate format.");

        }
    }
}