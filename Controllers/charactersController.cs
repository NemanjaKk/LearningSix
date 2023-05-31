using LearningSix.Data;
using LearningSix.Dto;
using LearningSix.Models;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningSix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class charactersController : ControllerBase
    {
        private readonly DataContext __context;

        public charactersController(DataContext context)
        {
            __context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Character>>> Index()
        {
            var characters = await __context.Characters
                .Include(c => c.Weapons)
                .Include(c => c.Skills)
                .ToListAsync();
            return Ok(characters);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Character>> Show(int id)
        {
            var character = await __context.Characters.FindAsync(id);
            if (character == null)
                return NotFound();
            return Ok(character);
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> Create(CharacterDto data)
        {
            var user = await __context.Users.FindAsync(data.UserId);
            if (user == null)
                return BadRequest();

            var character = data.Adapt<Character>();

            __context.Characters.Add(character);
            await __context.SaveChangesAsync();
            return Ok(character);
        }

        [HttpPut]
        public async Task<ActionResult<List<Character>>> Update(int characterId, CharacterDto data)
        {
            var character = __context.Characters.Find(characterId);
            if (character == null)
            {
                return NotFound();
            }

            character = data.Adapt<Character>();
            character.Id = characterId;

            __context.Characters.Update(character);
            await __context.SaveChangesAsync();
            return Ok(character);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Character>> Delete(int id)
        {
            var character = await __context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            __context.Characters.Remove(character);
            await __context.SaveChangesAsync();
            return Ok(character);
        }
    }
}
