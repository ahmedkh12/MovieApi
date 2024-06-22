using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Models;

namespace MovieApi.Repositers
{
    public class MoviesRepositery : IMoviesRepositery
    {
        private readonly ApplicationDBContext _context;

        public MoviesRepositery(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Movie> Create(Movie movie)
        {
           await _context.AddAsync(movie);
            _context.SaveChanges();
            return movie;
        }

        public Task<Movie> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            var result = await _context.Movies.Include(m => m.genre)
                
                .ToListAsync();

            return result;
        }

        public async Task<Movie?> GetByID(int? id)
        {
           var movie = await _context.Movies.Include(m=>m.genre).FirstOrDefaultAsync(m=> m.id == id);
            return movie;
        }

        public Task<Movie> Update(int id, Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
