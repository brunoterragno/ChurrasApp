using System.IO;
using Churras.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ChurrasContext>
{
  public ChurrasContext CreateDbContext(string[] args)
  {
    var builder = new DbContextOptionsBuilder<ChurrasContext>();
    builder.UseSqlite("Data Source=churras_db");

    return new ChurrasContext(builder.Options);
  }
}