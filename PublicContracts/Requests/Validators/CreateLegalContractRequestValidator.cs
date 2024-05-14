using FluentValidation;

namespace PublicContracts.Requests.Validators;

/// <summary>
/// Class that validates the <see cref="CreateLegalContractRequest"/>
/// </summary>
public class CreateLegalContractRequestValidator : AbstractValidator<CreateLegalContractRequest>
{
    /// <summary>
    /// Instantiates a new instance of the <see cref="CreateLegalContractRequestValidator"/>
    /// </summary>
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