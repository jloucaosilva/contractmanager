namespace DataAccessLayer.Context.Interfaces;

/// <summary>
/// Interface that defines the contract for the database context factory.
/// </summary>
public interface IContractManagerContextFactory
{
    /// <summary>
    /// Creates a new instance of the <see cref="ContractManagerDbContext"/> class.
    /// </summary>
    /// <returns></returns>
    ContractManagerDbContext CreateContext();
}