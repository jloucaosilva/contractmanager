using DataAccessLayer.Context.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context.Implementation;

/// <summary>
/// The database context factory implementation.
/// </summary>
public class ContractManagerContextFactory : IContractManagerContextFactory
{
    /// <summary>
    /// The options to be used when creating a new instance of the <see cref="ContractManagerDbContext"/> class.
    /// </summary>
    private readonly DbContextOptions<ContractManagerDbContext> _contextOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContractManagerContextFactory"/> class.
    /// </summary>
    /// <param name="contextOptions">The <see cref="DbContextOptions{TContext}"/> to be used in instantiating the <see cref="ContractManagerDbContext"/></param>
    public ContractManagerContextFactory(DbContextOptions<ContractManagerDbContext> contextOptions)
    {
        _contextOptions = contextOptions;
    }
    
    /// <inheritdoc cref="CreateContext"/>
    public ContractManagerDbContext CreateContext()
    {
        return new ContractManagerDbContext(_contextOptions);
    }
}