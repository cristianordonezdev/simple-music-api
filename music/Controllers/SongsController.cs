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
    public class SongsController : ControllerBase
    {
        private readonly ISong _repository;
        private readonly IMapper _mapper;

        public SongsController(ISong repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<IActionResult> GetSongs()
        {
            var songs = await _repository.GetAll();
            return Ok(songs);
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSong([FromRoute] Guid id)
        {
            var song = await _repository.GetSong(id);
            Console.Write(song);
            if (song == null)
            {
                return NotFound();
            }
            return Ok(song);
        }

        // POST: api/Songs
        [HttpPost]
        public async Task<IActionResult> PostSong([FromBody] AddSong song)
        {
            var songDomain = _mapper.Map<Song>(song);
            var createdSong = await _repository.AddSong(songDomain);
            return CreatedAtAction(nameof(GetSong), new { id = createdSong.Id }, createdSong);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong([FromRoute] Guid id, [FromBody] AddSong song)
        {
            var songDomain = _mapper.Map<Song>(song);

            var songUpdated = await _repository.UpdateSong(id, songDomain);
            if (songUpdated == null)
            {
                return NotFound();
            }
            return Ok(songUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong([FromRoute] Guid id)
        {
            var success = await _repository.DeleteSong(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
