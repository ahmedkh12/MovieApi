using Microsoft.EntityFrameworkCore;
using MovieApi.Models;

namespace MovieApi.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            var initData = new List<Genre>
            { 
             new Genre{
                 Id = 1,
             Name = "Movie1",
             Description = "Movie1 Description"
             },
              new Genre{
                  Id = 2,
             Name = "Movie2",
             Description = "Movie2 Description"
             },
               new Genre{

             Id = 3,
             Name = "Movie3",
             Description = "Movie3 Description"
             },
                new Genre{

             Id = 4,
             Name = "Movie4",
             Description = "Movie4 Description"
             },
                 new Genre{

             Id = 5,
             Name = "Movie5",
             Description = "Movie5 Description"
             },
            };
            modelBuilder.Entity<Genre>().HasData(initData);
        }
    }
}
