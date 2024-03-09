using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroWebApi.Data;
using SuperHeroWebApi.Entities;

namespace SuperHeroWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAll()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetOne(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero is null) return NotFound("Hero not found");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<SuperHero>> Add(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(hero);
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> Update(SuperHero hero)
        {
            var findHero = await _context.SuperHeroes.FindAsync(hero.Id);

            if (findHero is null) return NotFound("Hero not found");

            findHero.FullName = hero.FullName;
            findHero.HeroName = hero.HeroName;
            findHero.Place = hero.Place;
            await _context.SaveChangesAsync();

            return Ok(hero);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> Delete(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero is null) return NotFound("Hero not found");

            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();

            return Ok("Hero deleted");
        }
    }
}
