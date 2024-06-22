using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Models;

namespace MovieApi.Repositers
{
    public class GenresRepositery : IGenresRepositery
    {
        private readonly ApplicationDBContext _context;

        public GenresRepositery(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Genre> Create(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> Delete(int id)
        {
           var item =  await _context.Genres.FindAsync(id);
            if (item != null) 
            {
                _context.Genres.Remove(item);
               await _context.SaveChangesAsync();
            }
            return item;
        }

        public async Task<List<Genre>> GetAllAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre?> GetByID(int? id)
        {
            return await _context.Genres.FindAsync(id); 
        }

        public async Task<Genre> Update(int id, Genre genre)
        {
            var item = await _context.Genres.FindAsync(id);

            item.Name = genre.Name;
            item.Description = genre.Description;

             await _context.SaveChangesAsync();
            return item;

        }
    }
}
