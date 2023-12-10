using Microsoft.EntityFrameworkCore;
using System.Net;

namespace TFTDirecting.Database
{
    public class MoviesDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ActorMovieApplication> ActorMovieApplications { get; set; }
        public DbSet<Genre> Genres { get; set; }


        private IConfiguration _config;

        public MoviesDbContext(IConfiguration config)
            : base()
        {
            _config = config;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:connectionString"]);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasOne(e => e.Director)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Genres)
                .WithMany(e => e.Movies);

            base.OnModelCreating(modelBuilder);
        }
    }
}
