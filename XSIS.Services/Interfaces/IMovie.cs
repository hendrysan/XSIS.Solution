using XSIS.Models.Entities;

namespace XSIS.Services.Interfaces
{
    public interface IMovie
    {
        Task<List<Movie>?> GetAllAsync();

        Task<Movie?> GetByIdAsync(int id);

        Task<Movie?> CreateAsync(Movie movie);

        Task<Movie?> UpdateAsync(Movie movie, int id);

        Task<Movie?> DeleteAsync(int id);


    }
}
