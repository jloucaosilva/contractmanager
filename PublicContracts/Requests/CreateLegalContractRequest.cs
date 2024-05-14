using System.ComponentModel.DataAnnotations;

namespace PublicContracts.Requests;

/// <summary>
/// Public contract request to create a legal contract
/// </summary>
public class CreateLegalContractRequest
{
    /// <summary>
    /// The name of the contract author
    /// </summary>
    [MaxLength(256)]
    [Required]
    public string Author { get; set; }

    /// <summary>
    /// The name of the legal entity
    /// </summary>
    [MaxLength(256)]
    [Required]
    public string LegalEntity { get; set; }
    
    /// <summary>
    /// The description of the legal entity
    /// </summary>
    [Required]
    public string Contract { get; set; }
}