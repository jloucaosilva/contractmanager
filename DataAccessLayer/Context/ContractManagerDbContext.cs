using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context;

/// <summary>
/// The database context for the contract manager application.
/// </summary>
public class ContractManagerDbContext : DbContext
{
    /// <summary>
    /// The legal contracts table
    /// </summary>
    public DbSet<LegalContract> LegalContracts { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ContractManagerDbContext"/> class.
    /// </summary>
    public ContractManagerDbContext()
    {
    }

    /// <summary>
    ///  Initializes a new instance of the <see cref="ContractManagerDbContext"/> class.
    /// </summary>
    /// <param name="options">The <see cref="DbContextOptions{TContext}"/> where T is <see cref="ContractManagerDbContext"/></param>
    public ContractManagerDbContext(DbContextOptions<ContractManagerDbContext> options)
        : base(options)
    {
    }
    
    /// <summary>
    /// Configures the database context to use an in-memory database.
    /// </summary>
    /// <param name="optionsBuilder">The <see cref="DbContextOptionsBuilder"/> to be used in setting up the database instance</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "ContractManagerDb");
        base.OnConfiguring(optionsBuilder);
    }
}