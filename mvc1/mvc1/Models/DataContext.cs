namespace mvc.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Stadium> Stadiums { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasMany(e => e.Game)
                .WithRequired(e => e.Team)
                .HasForeignKey(e => e.Team1_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Game1)
                .WithRequired(e => e.Team1)
                .HasForeignKey(e => e.Team2_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
