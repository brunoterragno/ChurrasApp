using System;
using System.Collections.Generic;
using Microsoft.Azure.KeyVault.Models;
using Newtonsoft.Json;
using Xunit;

namespace Churras.Test
{
  public static class AssertUtils
  {
    public static void AssertObject<T>(List<T> expectedObjects, List<T> actualObjects, Action<T, T> assertProperties)
    {
      for (int i = 0; i < actualObjects.Count; i++)
      {
        AssertObject(expectedObjects[i], actualObjects[i], assertProperties);
      }
    }

    public static void AssertObject<T>(T expectedObject, T actualObject, Action<T, T> assertProperties)
    {
      assertProperties(expectedObject, actualObject);
      // in case of any property was missed
      AssertObjectAsJSON(expectedObject, actualObject);
    }

    public static void AssertObjectAsJSON<T>(T expectedObject, T actualObject)
    {
      Assert.Equal(
        JsonConvert.SerializeObject(expectedObject),
        JsonConvert.SerializeObject(actualObject)
      );
    }
  }
}