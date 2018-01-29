using System;
using System.Collections.Generic;
using System.Linq;

namespace Churras.Domain.Models
{
  public enum ResourceUriType
  {
    PreviousPage,
    NextPage
  }

  public class PagedList<T> : List<T>
  {
    public int CurrentPage { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }

    public bool HasPrevious
    {
      get
      {
        return (CurrentPage > 1);
      }
    }

    public bool HasNext
    {
      get
      {
        return (CurrentPage < TotalPages);
      }
    }

    public PagedList(List<T> items, int count, int pageNumber, int pageSize)
    {
      TotalCount = count;
      PageSize = pageSize;
      CurrentPage = pageNumber;
      TotalPages = (int) Math.Ceiling(count / (double) pageSize);
      AddRange(items);
    }

    public static PagedList<T> Create(IQueryable<T> source, Pagination pagination)
    {
      var count = source.Count();
      var items = source.Skip((pagination.PageNumber - 1) *
        pagination.PageSize).Take(pagination.PageSize).ToList();

      return new PagedList<T>(items, count, pagination.PageNumber, pagination.PageSize);
    }
  }
}