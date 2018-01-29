using Churras.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Churras.Api.Utils
{
  public static class MetadataHelpers
  {
    public static void AddPaginationMetadataHeader(
      IUrlHelper urlHelper,
      HttpResponse response,
      PagedList<Barbecue> barbecues,
      BarbecueResourceFilters filter
    )
    {
      var previousPageLink = barbecues.HasPrevious ?
        CreateBarbecuesResourceUri(urlHelper, filter, ResourceUriType.PreviousPage) : null;
      var nextPageLink = barbecues.HasNext ?
        CreateBarbecuesResourceUri(urlHelper, filter, ResourceUriType.NextPage) : null;

      var paginationMetadata = new
      {
        totalCount = barbecues.TotalCount,
        pageSize = barbecues.PageSize,
        currentPage = barbecues.CurrentPage,
        totalPages = barbecues.TotalPages,
        previousPageLink = previousPageLink,
        nextPageLink = nextPageLink
      };

      response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));
    }

    public static string CreateBarbecuesResourceUri(IUrlHelper urlHelper, BarbecueResourceFilters pagination, ResourceUriType type)
    {
      int pageNumber = 0;
      string link = string.Empty;

      switch (type)
      {
        case ResourceUriType.PreviousPage:
          pageNumber = pagination.PageNumber - 1;
          break;
        case ResourceUriType.NextPage:
          pageNumber = pagination.PageNumber + 1;
          break;
        default:
          pageNumber = pagination.PageNumber;
          break;
      }

      return urlHelper.Link("GetBarbecues",
        new
        {
          title = pagination.Title,
            pageNumber = pageNumber,
            pageSize = pagination.PageSize
        });
    }
  }
}