using FluentValidation;

namespace PublicContracts.Requests.Validators;

public class UpdateLegalContractRequestValidator : AbstractValidator<UpdateLegalContractRequest>
{
    public UpdateLegalContractRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        
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