using System;
using System.Reflection;
using ContractManager.Server.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PublicContracts.Responses;
using Xunit;

namespace ContractManagerTests;

/// <summary>
/// Test class for the definition of the <see cref="LegalContractsController"/>
/// </summary>
public class TestLegalContractsControllerDefinition
{
    private readonly Type _controllerType = typeof(LegalContractsController);
    
    [Fact]
    public void Controller_Must_Have_Correct_Annotations()
    {
        var routeAttribute = _controllerType.GetCustomAttribute<RouteAttribute>();
        
        routeAttribute.Should().NotBeNull();
        routeAttribute.Template.Should().Be("legalcontracts");  
        
        var apiControllerAttribute = _controllerType.GetCustomAttribute<ApiControllerAttribute>();
        apiControllerAttribute.Should().NotBeNull();
    }
    
    [Fact]
    public void Get_Endpoint_Must_Have_Correct_Annotations()
    {
        var method = nameof(LegalContractsController.Get);
        var getAttribute = _controllerType.GetMethod(method).GetCustomAttribute<HttpGetAttribute>();
        var producesResponseTypeAttribute = _controllerType.GetMethod(method).GetCustomAttributes<ProducesResponseTypeAttribute>();
        
        getAttribute.Should().NotBeNull();
        getAttribute.Template.Should().Be("{id}");
        producesResponseTypeAttribute.Should().HaveCount(2);
        producesResponseTypeAttribute.Should().ContainSingle(attr => attr.Type == typeof(LegalContractResponse));
        producesResponseTypeAttribute.Should().ContainSingle(attr => attr.StatusCode == 200);
        producesResponseTypeAttribute.Should().ContainSingle(attr => attr.StatusCode == 404);
    }
}