using BlueBoard.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlueBoard.Persistence.Configurations
{
    public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.HasKey(i => new { i.UserId, i.TripId });
            builder.HasOne(i => i.User)
                .WithMany()
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Trip)
                .WithMany(i => i.Participants)
                .HasForeignKey(i => i.TripId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
