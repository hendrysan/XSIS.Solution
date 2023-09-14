using Microsoft.EntityFrameworkCore;
using XSIS.Contexts;
using XSIS.Models.Entities;
using XSIS.Services.Interfaces;
using ZstdSharp.Unsafe;

namespace XSIS.Services.Implements
{
    public class MovieRepository : IMovie
    {
        private readonly DatabaseContext _context;


        public MovieRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Movie?> CreateAsync(Movie movie)
        {
            try
            {

                _context.Movies.Add(movie);
                var task = await _context.SaveChangesAsync();
                return task > 0 ? movie : null;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Movie?> DeleteAsync(int id)
        {
            try
            {
                var data = await _context.Movies.FindAsync(id);

                if (data == null)
                    return null;


                _context.Movies.Remove(data);
                var task = await _context.SaveChangesAsync();
                return task > 0 ? data : null;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Movie>?> GetAllAsync()
        {
            try
            {
                var list = await _context.Movies.ToListAsync();
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            try
            {
                var data = await _context.Movies.FirstOrDefaultAsync(i => i.Id == id);

                return data;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Movie?> UpdateAsync(Movie movie, int id)
        {
            try
            {
                var data = await _context.Movies.FirstOrDefaultAsync(i => i.Id == id);

                if (data == null)
                    return null;

                data.Title = movie.Title;
                data.Description = movie.Description;
                data.Rating = movie.Rating;
                data.Image = movie.Image;
                data.Updated_at = DateTime.Now;

                var task = await _context.SaveChangesAsync();

                return task > 0 ? data : null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
