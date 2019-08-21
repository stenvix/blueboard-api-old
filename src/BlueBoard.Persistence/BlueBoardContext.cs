using BlueBoard.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlueBoard.Persistence
{
    public class BlueBoardContext : DbContext
    {
        #region DbSets

        public DbSet<Country> Countries { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripCountry> TripCountries { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion

        public BlueBoardContext(DbContextOptions<BlueBoardContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlueBoardContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
