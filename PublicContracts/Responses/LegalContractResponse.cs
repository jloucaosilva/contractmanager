using System;

namespace PublicContracts.Responses;

public class LegalContractResponse
{
    /// <summary>
    /// The contract unique identifier
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The name of the contract author
    /// </summary>
    public string Author { get; set; }

    /// <summary>
    /// The name of the legal entity
    /// </summary>
    public string LegalEntity { get; set; }
    
    /// <summary>
    /// The description of the legal entity
    /// </summary>
    public string Contract { get; set; }
    
    /// <summary>
    /// The contract creation date
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }
    
    /// <summary>
    /// The contract update date (if any)
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; set; }
}