using BlueBoard.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlueBoard.Persistence.Configurations
{
    public class TripCountryConfiguration : IEntityTypeConfiguration<TripCountry>
    {
        public void Configure(EntityTypeBuilder<TripCountry> builder)
        {
            builder.HasKey(i => new { i.TripId, i.CountryId });
            builder.HasOne(i => i.Trip).WithMany().HasForeignKey(i => i.TripId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(i => i.Country).WithMany().HasForeignKey(i => i.CountryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
