using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Churras.Api;
using Churras.Domain.Dtos;
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
      var expectedBarbecues = Mapper.Map<List<BarbecueDto>>(GetAllDefaultBarbecues());

      // Act
      var response = await RequestGet<List<BarbecueDto>>(client, BARBECUES);

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      Assert.Equal(expectedBarbecues.Count, response.Content.Count);
      AssertObjectAsJSON(expectedBarbecues.OrderByDescending(x => x.Date).ToList(), response.Content);
    }

    [Fact]
    public async Task Get_Specific_Barbecue()
    {
      // Arrange
      var expectedBarbecue = Mapper.Map<BarbecueDto>(GetDefaultBarbecue());

      // Act
      var response = await RequestGet<BarbecueDto>(client, $"{BARBECUES}/1");

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      AssertObjectAsJSON(expectedBarbecue, response.Content);
    }

    [Fact]
    public async Task Get_All_Participants_From_A_Specific_Barbecue()
    {
      // Arrange
      var expectedBarbecue = Mapper.Map<BarbecueDto>(GetDefaultBarbecue());

      // Act
      var response = await RequestGet<List<ParticipantDto>>(client, $"{BARBECUES}/1/participants");

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      AssertObjectAsJSON(expectedBarbecue.Participants, response.Content);
    }

    [Fact]
    public async Task Send_Not_Found_When_Get_All_Participants_From_An_Unexisting_Barbecue()
    {
      // Arrange
      var expectedBarbecue = Mapper.Map<BarbecueDto>(GetDefaultBarbecue());

      // Act
      var response = await RequestGet<List<ParticipantDto>>(client, $"{BARBECUES}/1/participants");

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      AssertObjectAsJSON(expectedBarbecue.Participants, response.Content);
    }

    [Fact]
    public async Task Send_Not_Found_When_Specific_Barbecue_Not_Exist()
    {
      // Arrange
      var expectedBarbecue = GetDefaultBarbecue();

      // Act
      var response = await RequestGet<BarbecueDto>(client, $"{BARBECUES}/99");

      // Assert
      Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Send_Bad_Request_When_Send_Invalid_Data()
    {
      // Arrange
      var newBarbecue = new Barbecue("", DateTime.MinValue, "", 0, 0);
      var expectedValidationErrorResult = GetBarbecuePostBadRequestValidationErrorResult();

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
      var newBarbecue = Mapper.Map<CreateEditBarbecueDto>(GetDefaultBarbecue());

      // Act
      var response = await RequestPost<BarbecueDto>(client, BARBECUES, newBarbecue);

      // Assert
      Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Edit_An_Existing_Barbecue()
    {
      // Arrange
      var existingBarbecue = Mapper.Map<BarbecueDto>(GetDefaultBarbecue());
      existingBarbecue.Title = "Test1";
      existingBarbecue.Description = "Test2";
      existingBarbecue.CostWithDrink = 100;
      existingBarbecue.CostWithoutDrink = 0;

      // Act
      var response = await RequestPut<BarbecueDto>(client, $"{BARBECUES}/1", existingBarbecue);

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      AssertObjectAsJSON(existingBarbecue, response.Content);
    }

    [Fact]
    public async Task Not_Edit_An_Existing_Barbecue_With_Invalid_Data()
    {
      // Arrange
      var expectedValidationErrorResult = GetBarbecuePutBadRequestValidationErrorResult();
      var existingBarbecue = Mapper.Map<CreateEditBarbecueDto>(GetDefaultBarbecue());
      existingBarbecue.Title = null;
      existingBarbecue.Date = default(DateTime);
      existingBarbecue.CostWithDrink = -1;

      // Act
      var response = await RequestPut<ValidationErrorResult>(client, $"{BARBECUES}/1", existingBarbecue);

      // Assert
      Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
      AssertObjectAsJSON(expectedValidationErrorResult, response.Content);
    }

    [Fact]
    public async Task Delete_An_Existing_Barbecue()
    {
      // Act
      var deleteResponse = await RequestDelete<string>(client, $"{BARBECUES}/1");
      var getResponse = await RequestGet<ValidationErrorResult>(client, $"{BARBECUES}/1");

      // Assert
      Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
      Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
    }

    [Fact]
    public async Task Send_Not_Found_When_Delete_An_Unexisting_Barbecue()
    {
      // Act
      var response = await RequestDelete<ValidationErrorResult>(client, $"{BARBECUES}/99");

      // Assert
      Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Create_Barbecue_Participant()
    {
      // Arrange
      var barbecue = GetDefaultBarbecue();
      var newParticipant = Mapper.Map<ParticipantDto>(GetNewParticipantWithDrink(barbecue));

      // Act
      var response = await RequestPost<ParticipantDto>(client, $"{BARBECUES}/1/participants", newParticipant);
      newParticipant.Id = 2;

      // Assert
      Assert.Equal(HttpStatusCode.Created, response.StatusCode);
      AssertObjectAsJSON(newParticipant, response.Content);
    }

    [Fact]
    public async Task Not_Add_Barbecue_Participant_With_Wrong_Data()
    {
      // Arrange
      var expectedValidationErrorResult = GetParticipantPostBadRequestValidationErrorResult();
      var barbecue = GetDefaultBarbecue();
      var newParticipant = Mapper.Map<ParticipantDto>(GetNewParticipantWithDrink(barbecue));
      newParticipant.Name = null;

      // Act
      var response = await RequestPost<ValidationErrorResult>(client, $"{BARBECUES}/2/participants", newParticipant);

      // Assert
      Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
      AssertObjectAsJSON(expectedValidationErrorResult, response.Content);
    }

    [Fact]
    public async Task Edit_An_Existing_Barbecue_Participant()
    {
      // Arrange
      var barbecue = GetDefaultBarbecue();
      var participant = Mapper.Map<ParticipantDto>(GetNewParticipantWithDrink(barbecue));
      participant.Id = 1;
      participant.Name = "Teste1";
      participant.IsGoingToDrink = !participant.IsGoingToDrink;
      participant.Dough = 1000;

      // Act
      var response = await RequestPut<ParticipantDto>(client, $"{BARBECUES}/2/participants/1", participant);

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      AssertObjectAsJSON(participant, response.Content);
    }

    [Fact]
    public async Task Not_Edit_An_Existing_Barbecue_Participant_With_Invalid_Data()
    {
      // Arrange
      var expectedValidationErrorResult = GetParticipantPutBadRequestValidationErrorResult();
      var barbecue = GetDefaultBarbecue();
      var participant = Mapper.Map<ParticipantDto>(GetNewParticipantWithDrink(barbecue));
      participant.Id = 1;
      participant.Name = null;

      // Act
      var response = await RequestPut<ValidationErrorResult>(client, $"{BARBECUES}/2/participants/1", participant);

      // Assert
      Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
      AssertObjectAsJSON(expectedValidationErrorResult, response.Content);
    }

    [Fact]
    public async Task Delete_Barbecue_Participant()
    {
      // Act
      var deleteResponse = await RequestDelete<string>(client, $"{BARBECUES}/2/participants/1");
      var getResponse = await RequestGet<BarbecueDto>(client, $"{BARBECUES}/2");

      // Assert
      Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
      Assert.Equal(0, getResponse.Content.Participants.Count);
    }

    [Fact]
    public async Task Send_Not_Found_When_Delete_An_Unexisting_Barbecue_Participant()
    {
      // Act
      var response = await RequestDelete<ValidationErrorResult>(client, $"{BARBECUES}/1/participants/99");

      // Assert
      Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
  }
}