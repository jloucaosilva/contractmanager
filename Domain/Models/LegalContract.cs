using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

/// <summary>
/// Class that represents a legal contract.
/// </summary>
public class LegalContract
{
    /// <summary>
    /// The contract unique identifier
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    /// <summary>
    /// The name of the contract author
    /// </summary>
    [MaxLength(256)]
    public string AuthorName { get; set; }

    /// <summary>
    /// The name of the legal entity
    /// </summary>
    [MaxLength(256)]
    public string LegalEntityName { get; set; }
    
    /// <summary>
    /// The description of the legal entity
    /// </summary>
    public string LegalEntityDescription { get; set; }
    
    /// <summary>
    /// The contract creation date
    /// </summary>
    [Required]
    public DateTimeOffset CreatedAt { get; set; }
    
    /// <summary>
    /// The contract update date (if any)
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; set; }
}