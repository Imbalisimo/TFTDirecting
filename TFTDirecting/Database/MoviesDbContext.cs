using Microsoft.EntityFrameworkCore;
using System.Net;

namespace TFTDirecting.Database
{
    public class MoviesDbContext: DbContext
    {
        private IConfiguration _config;

        public MoviesDbContext(DbContextOptions<MoviesDbContext> options, IConfiguration config)
            : base(options)
        {
            _config = config;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TO-DO: add connection string to appsettings
            //optionsBuilder.UseSQL(_config["connectionString""server=localhost;database=library;user=user;password=password"]);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ActorMovieApplication> ActorMovieApplications { get; set; }
        public DbSet<Genre> Genres { get; set; }

    }
}
