using Churras.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Churras.Repository
{
    public class ChurrasContext : DbContext
    {
        public ChurrasContext(DbContextOptions<ChurrasContext> options) : base(options) { }

        public DbSet<Barbecue> Barbecues { get; set; }

        public DbSet<Participant> Participants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new BarbecueConfig());
        }
    }
}