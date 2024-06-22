using MovieApi.Models;

namespace MovieApi.Repositers
{
    public interface IMoviesRepositery
    {
        Task<List<Movie>> GetAllAsync();

        Task<Movie?> GetByID(int? id);

        Task<Movie> Create(Movie movie);

        Task<Movie> Update(int id, Movie movie);

        Task<Movie> Delete(int id);
    }
}
