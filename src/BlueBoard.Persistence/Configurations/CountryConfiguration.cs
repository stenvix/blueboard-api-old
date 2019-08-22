using BlueBoard.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlueBoard.Persistence.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Name).IsRequired();
            builder.Property(i => i.Iso).IsRequired();
            builder.HasIndex(i => i.Name).IsUnique();
        }
    }
}
