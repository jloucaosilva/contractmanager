using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Context.Interfaces;
using DataAccessLayer.Repositories.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DataAccessLayer.Repositories.Implementation;

/// <summary>
/// The legal contract repository implementation.
/// </summary>
public class LegalContractRepository : ILegalContractRepository
{
    private readonly IContractManagerContextFactory _contextFactory;
    private readonly ILogger _logger;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="LegalContractRepository"/> class.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> instance to be used in his class</param>
    /// <param name="context">The <see cref="IContractManagerContextFactory"/> database context factory to be used in this class</param>
    public LegalContractRepository(ILogger logger, IContractManagerContextFactory context)
    {
        _contextFactory = context;
        _logger = logger.ForContext<LegalContractRepository>();
    }
    
    /// <inheritdoc cref="InsertAsync(LegalContract)"/>
    public async Task<LegalContract> InsertAsync(LegalContract legalContract)
    {
        _logger.Information("{Tracer}|Inserting a legal contract", "53A130D1-CBAD-47BC-93BD-D44BB1B0CBC7");
        await using (var context = this._contextFactory.CreateContext())
        {
            legalContract.CreatedAt = DateTimeOffset.UtcNow;
            var inserted = await context.LegalContracts.AddAsync(legalContract);
            await context.SaveChangesAsync();
            return inserted.Entity;
        }
    }

    /// <inheritdoc cref="UpdateAsync(LegalContract)"/>
    public async Task<LegalContract> UpdateAsync(LegalContract legalContract)
    {
        _logger.Information("{Tracer}|Updating a legal contract", "12A6CDEB-7EC5-4D71-BE97-D7C77727700E");
        await using(var context = this._contextFactory.CreateContext())
        {
            legalContract.UpdatedAt = DateTimeOffset.UtcNow;
            var updated = context.LegalContracts.Update(legalContract);
            await context.SaveChangesAsync();
            return updated.Entity;
        }
    }

    /// <inheritdoc cref="DeleteAsync(Guid)"/>
    public async Task DeleteAsync(Guid id)
    {
        _logger.Information("{Tracer}|Deleting a legal contract", "C3D3D3D3-3D3D-3D3D-3D3D-3D3D3D3D3D3D");
        await using(var context = this._contextFactory.CreateContext())
        {
            var toDelete = await context.LegalContracts.FirstOrDefaultAsync(i => i.Id.Equals(id));
            if(toDelete == null)
            {
                // if the record no longer exists there's nothing to do and we can safely return
                return;
            }
            
            context.LegalContracts.Remove(toDelete);
            await context.SaveChangesAsync();
        }
    }

    /// <inheritdoc cref="GetAllAsync()"/>
    public async Task<IEnumerable<LegalContract>> GetAllAsync()
    {
        _logger.Information("{Tracer}|Retrieving all legal contracts", "D3D3D3D3-3D3D-3D3D-3D3D-3D3D3D3D3D3D");
        await using(var context = this._contextFactory.CreateContext())
        {
            return await context.LegalContracts.ToListAsync();
        }
    }

    /// <inheritdoc cref="GetByIdAsync(Guid)"/>
    public async Task<LegalContract> GetByIdAsync(Guid id)
    {
        _logger.Information("{Tracer}|Retrieving a legal contract", "25DA07C8-5D45-4754-BA3F-6A2FF7820E92");
        await using(var context = this._contextFactory.CreateContext())
        {
            return await context.LegalContracts.FirstOrDefaultAsync(i => i.Id.Equals(id));
        }
    }
}