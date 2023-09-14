using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XSIS.Models.Entities;
using XSIS.Services.Interfaces;

namespace XSIS.WebApi.Controllers
{
    [Route("Movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovie _movie;

        public MovieController(IMovie movie)
        {
            _movie = movie;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var res = await _movie.GetAllAsync();
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var res = await _movie.GetByIdAsync(id);

                if (res == null)
                    return BadRequest("Data not found");

                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            try
            {
                var res = await _movie.CreateAsync(movie);
                if (res == null)
                    return BadRequest("Save failed");

                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Movie movie, int id)
        {
            try
            {
                var res = await _movie.UpdateAsync(movie, id);


                if (res == null)
                    return BadRequest("Update failed");

                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _movie.DeleteAsync(id);

                if (res == null)
                    return BadRequest("Delete failed");

                return Ok(res);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
