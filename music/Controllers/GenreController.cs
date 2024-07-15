using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using music.Models;
using music.Models.Dtos;
using music.Repositories;

namespace music.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenre _repository;
        private readonly IMapper _mapper;

        public GenreController(IGenre repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Genre
        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await _repository.GetAll();
            return Ok(genres);
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenre([FromRoute] Guid id)
        {
            var genre = await _repository.GetGenre(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        // POST: api/Songs
        [HttpPost]
        public async Task<IActionResult> PostGenre([FromBody] AddGenre genre)
        {
            var genreDomain = _mapper.Map<Genre>(genre);
            var genreCreated = await _repository.AddGenre(genreDomain);
            return CreatedAtAction(nameof(GetGenre), new { id = genreCreated.Id }, genreCreated);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre([FromRoute] Guid id, [FromBody] AddGenre genre)
        {
            var genreDomain = _mapper.Map<Genre>(genre);

            var genreUpdated = await _repository.UpdateGenre(id, genreDomain);
            if (genreUpdated == null)
            {
                return NotFound();
            }
            return Ok(genreUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre([FromRoute] Guid id)
        {
            var success = await _repository.DeleteGenre(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
