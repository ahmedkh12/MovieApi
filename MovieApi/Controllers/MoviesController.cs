using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Models.DTO;
using MovieApi.Models;
using MovieApi.Repositers;
using MovieApi.Data;
using Microsoft.EntityFrameworkCore;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesRepositery _moviesRepositery;
        private readonly ApplicationDBContext _context;

        public MoviesController(IMoviesRepositery moviesRepositery, ApplicationDBContext context)
        {
            _moviesRepositery = moviesRepositery;
            _context = context;
        }

        private new List<string> _allowedExtenstions = new List<string> { ".jpg", ".png" };
        private long _maxAllowedPosterSize = 1048576;
        [HttpPost]
        [Route("CreateMovie")]
        public async Task<IActionResult> CreateAsync([FromForm] MovieDto dto)
        {

            using var dataStream = new MemoryStream();
            await dto.Poster.CopyToAsync(dataStream);

            if (dto.Poster == null)
                return BadRequest("Poster is required!");

            if (!_allowedExtenstions.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                return BadRequest("Only .png and .jpg images are allowed!");

            if (dto.Poster.Length > _maxAllowedPosterSize)
                return BadRequest("Max allowed size for poster is 1MB!");

            var isValidaGenreId = await _context.Genres.AnyAsync(g => g.Id == dto.GenreId);
            if (!isValidaGenreId)
                return BadRequest("Invalid Genre Id");
            var movie = new Movie
            {
                title = dto.Title,
                year = dto.Year,
                genreid = dto.GenreId,
                rate = dto.Rate,
                storeline = dto.Storeline,
                poster = dataStream.ToArray(),
            };

            await _moviesRepositery.Create(movie);
            return Ok("Movies Added Successfully ");
        }


        [HttpGet]
        [Route("GetMovies")]
        public async Task<IActionResult> GetMovies() { 
        var result = await _moviesRepositery.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetMovieById")]
        public async Task<IActionResult> getById(int id) 
        {
          var result = await _moviesRepositery.GetByID(id);
            return Ok(result);
        }
    }
}
