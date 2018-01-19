using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Churras.Api;
using Churras.Api.Models;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;
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

    private void AssertProperties(List<Barbecue> expectedBarbecues, List<Barbecue> actualBarbecues)
    {
      for (int i = 0; i < actualBarbecues.Count; i++)
      {
        AssertProperties(expectedBarbecues[i], actualBarbecues[i]);
      }
    }

    private void AssertProperties(Barbecue expectedBarbecue, Barbecue actualBarbecue)
    {
      Assert.Equal(expectedBarbecue.CostWithDrink, actualBarbecue.CostWithDrink);
      Assert.Equal(expectedBarbecue.CostWithoutDrink, actualBarbecue.CostWithoutDrink);
      Assert.Equal(expectedBarbecue.Date, actualBarbecue.Date);
      Assert.Equal(expectedBarbecue.Description, actualBarbecue.Description);
      Assert.Equal(expectedBarbecue.Participants, actualBarbecue.Participants);
      Assert.Equal(expectedBarbecue.Title, actualBarbecue.Title);
      Assert.Equal(expectedBarbecue.TotalDough, actualBarbecue.TotalDough);
      Assert.Equal(expectedBarbecue.TotalParticipants, actualBarbecue.TotalParticipants);
      Assert.Equal(expectedBarbecue.TotalParticipantsWhoDontDrink, actualBarbecue.TotalParticipantsWhoDontDrink);
      Assert.Equal(expectedBarbecue.TotalParticipantsWhoDrink, actualBarbecue.TotalParticipantsWhoDrink);

      // in case of any property was missed
      AssertAllObject(expectedBarbecue, actualBarbecue);
    }

    private void AssertAllObject(Barbecue expectedBarbecue, Barbecue actualBarbecue)
    {
      Assert.Equal(
        JsonConvert.SerializeObject(expectedBarbecue),
        JsonConvert.SerializeObject(actualBarbecue)
      );
    }

    [Fact]
    public async Task Get_All_Barbecues()
    {
      // Arrange
      var expectedBarbecues = GetAllDefaultBarbecues();

      // Act
      var response = await RequestGet<List<Barbecue>>(server, BARBECUES);

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      Assert.Equal(expectedBarbecues.Count, response.Content.Count);
      AssertProperties(expectedBarbecues, response.Content);
    }

    [Fact]
    public async Task Get_Specific_Barbecue()
    {
      // Arrange
      var expectedBarbecue = GetDefaultBarbecue();

      // Act
      var response = await RequestGet<Barbecue>(server, $"{BARBECUES}/1");

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      AssertProperties(expectedBarbecue, response.Content);
    }

    [Fact]
    public async Task Should_Send_Not_Found_When_Specific_Barbecue_Not_Exist()
    {
      // Arrange
      var expectedBarbecue = GetDefaultBarbecue();

      // Act
      var response = await RequestGet<Barbecue>(server, $"{BARBECUES}/99");

      // Assert
      Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
  }
}