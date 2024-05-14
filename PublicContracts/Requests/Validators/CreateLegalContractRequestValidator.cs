using FluentValidation;

namespace PublicContracts.Requests.Validators;

public class CreateLegalContractRequestValidator : AbstractValidator<CreateLegalContractRequest>
{
    public CreateLegalContractRequestValidator()
    {
        RuleFor(x => x.Author)
            .NotEmpty()
            .MaximumLength(256);
        
        RuleFor(x => x.LegalEntity)
            .NotEmpty()
            .MaximumLength(256);
        
        RuleFor(x => x.Contract)
            .NotEmpty();
    }
}