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
      Assert.Equal(
        JsonConvert.SerializeObject(expectedObject),
        JsonConvert.SerializeObject(actualObject)
      );
    }
  }
}