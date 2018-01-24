using System;
using System.Collections.Generic;
using Microsoft.Azure.KeyVault.Models;
using Newtonsoft.Json;
using Xunit;

namespace Churras.Test
{
  public static class AssertUtils
  {
    public static void AssertObjectAsJSON<T>(T expectedObject, T actualObject)
    {
      JsonConvert.DefaultSettings = () => new JsonSerializerSettings
      {
        Formatting = Newtonsoft.Json.Formatting.Indented,
        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
      };

      Assert.Equal(
        JsonConvert.SerializeObject(expectedObject),
        JsonConvert.SerializeObject(actualObject)
      );
    }
  }
}