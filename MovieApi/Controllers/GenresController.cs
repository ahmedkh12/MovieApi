using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;
using MovieApi.Models.DTO;
using MovieApi.Repositers;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenresRepositery _moviesRepositery;

        public GenresController(IGenresRepositery moviesRepositery)
        {
            _moviesRepositery = moviesRepositery;
        }



        [HttpGet]
        [Route("GetGenres")]
        public async Task<IActionResult> Get()
        {
            var data = await _moviesRepositery.GetAllAsync();
            return Ok(data);
        }

        [HttpPost]
        [Route("CreateGenre")]

        public async Task<IActionResult> Create(AddGenreDTO addGenreDTO)
        {
            var genre = new Genre
            {
                Name = addGenreDTO.Name,
                Description = addGenreDTO.Description,
            };

            await _moviesRepositery.Create(genre);
            return Ok(genre);


        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _moviesRepositery.GetByID(id);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteGenre")]
        public async Task<IActionResult> Delete(int id)
        {
            await _moviesRepositery.Delete(id);
            return Ok($"Item with ID {id} is deleted ");
        }

        [HttpPut]
        [Route("UpdateGenre")]
        public async Task<IActionResult> update(int id, AddGenreDTO addGenreDTO)
        {
            var item = new Genre
            {
                Name = addGenreDTO.Name,
                Description = addGenreDTO.Description,
            };

            var outitem = new AddGenreDTO
            {
                Name = item.Name,
                Description = item.Description,
            };
            await _moviesRepositery.Update(id, item);
            return Ok(outitem);
        }
    }
}
