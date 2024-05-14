using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using ContractManager.Server.Controllers;
using ContractManagerTests.Utilities;
using DataAccessLayer.Repositories.Interfaces;
using Domain.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PublicContracts.Responses;
using Serilog;
using Xunit;

namespace ContractManagerTests;

/// <summary>
/// Test class for the behavior of teh endpoints present at the <see cref="LegalContractsController"/>
/// </summary>
public class TestLegalContractsControllerBehavior
{
    private readonly Mock<ILogger> _loggerMock;
    private readonly Mock<ILegalContractRepository> _legalContractRepositoryMock;
    private readonly IMapper _mapper;
    private readonly IFixture _fixture;
    
    private LegalContractsController _contractsController;
    
    public TestLegalContractsControllerBehavior()
    {
        _fixture = new Fixture();
        _loggerMock = new Mock<ILogger>();
        _legalContractRepositoryMock = new Mock<ILegalContractRepository>();
        _mapper = AutomapperSetup.GetMapper();
    }
    
    [Fact]
    public async Task Get_Method_Should_Return_Record_When_Record_Is_Found()
    {
        // Arrange
        var id = Guid.NewGuid();
        var legalContract = _fixture.Build<LegalContract>()
            .With(i => i.Id, id)
            .Without(i => i.UpdatedAt)
            .Create();
        
        _legalContractRepositoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(legalContract);

        _loggerMock.Setup(x => x.ForContext<LegalContractsController>()).Returns(_loggerMock.Object);
        _loggerMock.Setup(l => l.Information(It.IsAny<string>(), It.IsAny<object[]>()));
        
        _contractsController = new LegalContractsController(_loggerMock.Object, _legalContractRepositoryMock.Object, _mapper);
        
        // Act
        var result = await _contractsController.Get(id);
        
        // Assert
        result.Result.Should().BeOfType<OkObjectResult>();
        var typedResult = (result.Result as OkObjectResult).Value as LegalContractResponse;
        typedResult.Should().BeEquivalentTo(legalContract, options => options.ExcludingMissingMembers());
    }
}