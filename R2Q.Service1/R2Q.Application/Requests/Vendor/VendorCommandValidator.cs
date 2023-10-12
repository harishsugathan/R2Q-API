using FluentValidation;

namespace R2Q.Application.Requests.Vendor
{
    public class VendorCommandValidator: AbstractValidator<VendorCommand>
    {
        public VendorCommandValidator()
        {
            // 1. Check fields are not empty,not null
            RuleFor(x => x.VendorName)
                   .NotEmpty().WithMessage(MessageKeys.FirstNameMandatory)
                   .MaximumLength(100).WithMessage(MessageKeys.FirstNameLimitExceeds);
        }
    }
}
