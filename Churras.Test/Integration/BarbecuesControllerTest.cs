using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Churras.Api;
using Churras.Domain.DTOs;
using Churras.Domain.Models;
using Churras.Test;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;
using static Churras.Test.AssertUtils;
using static Churras.Test.RequestUtils;

namespace Churras.Test.Integration
{
  public class BarbecuesControllerTest : TestDataBuilder
  {
    TestServer server;
    HttpClient client;

    const string BARBECUES = "api/barbecues";

    public BarbecuesControllerTest()
    {
      server = new TestServer(Program.CreateBuildWebHost(Array.Empty<string>()));
      client = server.CreateClient();
    }

    [Fact]
    public async Task Get_All_Barbecues()
    {
      // Arrange
      var expectedBarbecues = Mapper.Map<List<BarbecueDTO>>(GetAllDefaultBarbecues());

      // Act
      var response = await RequestGet<List<BarbecueDTO>>(client, BARBECUES);

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      Assert.Equal(expectedBarbecues.Count, response.Content.Count);
      AssertObjectAsJSON(expectedBarbecues, response.Content);
    }

    [Fact]
    public async Task Get_Specific_Barbecue()
    {
      // Arrange
      var expectedBarbecue = Mapper.Map<BarbecueDTO>(GetDefaultBarbecue());

      // Act
      var response = await RequestGet<BarbecueDTO>(client, $"{BARBECUES}/1");

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      AssertObjectAsJSON(expectedBarbecue, response.Content);
    }

    [Fact]
    public async Task Should_Send_Not_Found_When_Specific_Barbecue_Not_Exist()
    {
      // Arrange
      var expectedBarbecue = GetDefaultBarbecue();

      // Act
      var response = await RequestGet<BarbecueDTO>(client, $"{BARBECUES}/99");

      // Assert
      Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Should_Send_Bad_Request_When_Wrong_Data()
    {
      // Arrange
      var newBarbecue = new Barbecue("", DateTime.MinValue, "", 0, 0);
      var expectedValidationErrorResult = GetBarbecueBadRequestValidationErrorResult();

      // Act
      var response = await RequestPost<ValidationErrorResult>(client, BARBECUES, newBarbecue);

      // Assert
      Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
      AssertObjectAsJSON(expectedValidationErrorResult, response.Content);
    }

    [Fact]
    public async Task Create_New_Barbecue()
    {
      // Arrange
      var newBarbecue = GetDefaultBarbecue();

      // Act
      var response = await RequestPost<BarbecueDTO>(client, BARBECUES, newBarbecue);

      // Assert
      Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Add_Barbecue_Participant()
    {
      // Arrange
      var barbecue = GetDefaultBarbecue();
      var newParticipant = Mapper.Map<ParticipantDTO>(GetNewParticipantWithDrink(barbecue));

      // Act
      var response = await RequestPost<ParticipantDTO>(client, $"{BARBECUES}/1/participants", newParticipant);
      newParticipant.Id = 1;

      // Assert
      Assert.Equal(HttpStatusCode.Created, response.StatusCode);
      AssertObjectAsJSON(newParticipant, response.Content);
    }
  }
}