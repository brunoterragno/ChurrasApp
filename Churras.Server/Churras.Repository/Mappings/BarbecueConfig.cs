using Churras.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BarbecueConfig : IEntityTypeConfiguration<Barbecue>
{
  public void Configure(EntityTypeBuilder<Barbecue> builder)
  {
    builder
      .HasMany(b => b.Participants)
      .WithOne("Barbecue")
      .HasForeignKey("BarbecueId")
      .OnDelete(DeleteBehavior.Cascade);
  }
}