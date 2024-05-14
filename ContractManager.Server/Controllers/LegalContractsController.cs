using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Repositories.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using PublicContracts.Requests;
using PublicContracts.Responses;
using Serilog;

namespace ContractManager.Server.Controllers;

/// <summary>
/// Controller for managing legal contracts
/// </summary>
[ApiController]
[Route("[controller]")]
public class LegalContractsController : Controller
{
    private readonly ILogger _logger;
    private readonly ILegalContractRepository _legalContractRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="LegalContractsController"/> class.
    /// </summary>
    /// <remarks>
    ///     Usually the business logic layer would be used here, but for the sake of simplicity, the repository is used directly
    ///     Business logic layer would be used to handle the business rules and the repository would be used to interact with the database
    /// </remarks>
    /// <param name="logger">The <see cref="ILogger"/> instance to be used in his class</param>
    /// <param name="legalContractRepository">The <see cref="ILegalContractRepository"/> instance</param>
    /// <param name="mapper">The <see cref="IMapper"/> instance used to translate public contracts ino domain model and vice versa</param>
    public LegalContractsController(ILogger logger, ILegalContractRepository legalContractRepository, IMapper mapper)
    {
        _logger = logger.ForContext<LegalContractsController>();
        
        // Usually a business logic layer would be used here, but for the sake of simplicity, the repository is used directly
        _legalContractRepository = legalContractRepository;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Retrieves a legal contract by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier corresponding to th target record</param>
    /// <returns>The <see cref="LegalContract"/></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(LegalContractResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<LegalContractResponse>> Get([FromRoute]Guid id)
    {
        _logger.Information("{Tracer}|Retrieving a legal contract", "85B572ED-78E8-439B-893C-60EAFD9C9DE8");
        var legalContract = await _legalContractRepository.GetByIdAsync(id);
        if (legalContract == null)
        {
            return NotFound();
        }
        
        return Ok(_mapper.Map<LegalContractResponse>(legalContract));
    }

    /// <summary>
    /// Retrieves all the legal contracts from the database
    /// </summary>
    /// <returns>A list of <see cref="LegalContract"/></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<LegalContractResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<LegalContractResponse>>> Get()
    {
        _logger.Information("{Tracer}|Retrieving all legal contracts", "CC9ECCA4-7F52-4EF9-8DF8-4700C811A81B");
        var legalContracts = await _legalContractRepository.GetAllAsync();
        
        var response = legalContracts.Any() ? _mapper.Map<List<LegalContractResponse>>(legalContracts) : new List<LegalContractResponse>();
        
        return Ok(response);
    }
    
    /// <summary>
    /// Creates a new legal contract
    /// </summary>
    /// <param name="request">The <see cref="LegalContract"/> to be stored</param>
    /// <returns>The new <see cref="LegalContract"/> stored in the database</returns>
    [HttpPost]
    [ProducesResponseType(typeof(LegalContractResponse), (int)HttpStatusCode.Created)]
    public async Task<ActionResult<LegalContractResponse>> Post([FromBody]CreateLegalContractRequest request)
    {
        _logger.Information("{Tracer}|Creating a legal contract", "0C7B982C-B99B-477B-9DFA-7D84690785E3");
        var inserted = await _legalContractRepository.InsertAsync(_mapper.Map<LegalContract>(request));
        
        return CreatedAtAction(nameof(Post), new { id = inserted.Id }, _mapper.Map<LegalContractResponse>(inserted));
    }
    
    
    /// <summary>
    /// Updates an existing legal contract
    /// </summary>
    /// <param name="request">The <see cref="LegalContract"/> to be modified</param>
    /// <returns>The modified <see cref="LegalContract"/></returns>
    [HttpPut]
    [ProducesResponseType(typeof(LegalContractResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<LegalContract>> Put([FromBody]UpdateLegalContractRequest request)
    {
        _logger.Information("{Tracer}|Updating a legal contract", "12A6CDEB-7EC5-4D71-BE97-D7C77727700E");
        var updated = await _legalContractRepository.UpdateAsync(_mapper.Map<LegalContract>(request));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok(_mapper.Map<LegalContractResponse>(updated));
    }
    
    /// <summary>
    /// Deletes a legal contract by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the resource to be deleted</param>
    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Delete([FromRoute]Guid id)
    {
        _logger.Information("{Tracer}|Deleting a legal contract", "EFF65A89-2149-4930-A101-E188D6A18D67");
        await _legalContractRepository.DeleteAsync(id);
        
        return NoContent();
    }
}