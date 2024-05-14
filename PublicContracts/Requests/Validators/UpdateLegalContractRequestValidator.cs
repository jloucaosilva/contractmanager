using FluentValidation;

namespace PublicContracts.Requests.Validators;

/// <summary>
/// Class that validates the <see cref="UpdateLegalContractRequest"/>
/// </summary>
public class UpdateLegalContractRequestValidator : AbstractValidator<UpdateLegalContractRequest>
{
    /// <summary>
    /// Instantiates a new instance of the <see cref="UpdateLegalContractRequestValidator"/>
    /// </summary>
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