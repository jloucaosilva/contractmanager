using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccessLayer.Repositories.Interfaces;

/// <summary>
/// Interface for the legal contract repository.
/// </summary>
public interface ILegalContractRepository
{
    /// <summary>
    /// Stores a new <see cref="LegalContract"/> in the database in order to persist it.
    /// </summary>
    /// <param name="legalContract">The legal contract to be stored</param>
    /// <returns>The persisted version of the <see cref="LegalContract"/></returns>
    Task<LegalContract> InsertAsync(LegalContract legalContract);
    
    /// <summary>
    /// Updates an existing <see cref="LegalContract"/> in the database.
    /// </summary>
    /// <param name="legalContract">The legal contract that has been modified</param>
    /// <returns>The modified version of the <see cref="LegalContract"/></returns>
    Task<LegalContract> UpdateAsync(LegalContract legalContract);
    
    /// <summary>
    /// Deletes an existing <see cref="LegalContract"/> from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the contract to be deleted.</param>
    Task DeleteAsync(Guid id);
    
    /// <summary>
    /// Retrieves all the <see cref="LegalContract"/> instances from the database.
    /// </summary>
    /// <returns>A <see cref="IEnumerable{T}"/> where T is <see cref="LegalContract"/> containing all existing records</returns>
    Task<IEnumerable<LegalContract>> GetAllAsync();
    
    /// <summary>
    /// Retrieves a specific <see cref="LegalContract"/> instance from the database.
    /// </summary>
    /// <param name="id">The unique identifier that references the target legal contract</param>
    /// <returns>The <see cref="LegalContract"/> identifid by the unique identifier</returns>
    Task<LegalContract> GetByIdAsync(Guid id);
}