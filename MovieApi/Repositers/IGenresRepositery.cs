using MovieApi.Models;

namespace MovieApi.Repositers
{
    public interface IGenresRepositery
    {
        Task <List<Genre>>  GetAllAsync();

        Task<Genre?> GetByID(int? id);

        Task<Genre> Create(Genre genre);

        Task<Genre> Update(int id, Genre genre);

        Task<Genre> Delete(int id);
    }
}
