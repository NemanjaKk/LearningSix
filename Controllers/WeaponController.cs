using LearningSix.Data;
using LearningSix.Dto;
using LearningSix.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningSix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly DataContext __context;
        public WeaponController(DataContext context)
        {
            __context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Weapon>>> Create(WeaponDto data)
        {
            var character = await __context.Characters.FindAsync(data.CharacterId);
            if (character == null)
                return BadRequest();

            var weapon = data.Adapt<Weapon>();

            __context.Weapons.Add(weapon);
            await __context.SaveChangesAsync();
            return Ok(weapon);
        }
    }
}
