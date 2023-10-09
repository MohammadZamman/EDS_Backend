using EDS_BackendTest.DataContext;
using EDS_BackendTest.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_BackendTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SublevelsController : ControllerBase
    {
        private readonly DBContext _context;

        public SublevelsController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Sublevel>> Get()
        {
            return await _context.Sublevels.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Sublevel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var sublevel = await _context.Sublevels.FindAsync(id);
            return sublevel == null ? NotFound() : Ok(sublevel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Sublevel sublevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sublevels.Add(sublevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = sublevel.SublevelID }, sublevel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, Sublevel updatedSublevel)
        {
            if (id != updatedSublevel.SublevelID)
            {
                return BadRequest("ID mismatch");
            }

            var existingSublevel = await _context.Sublevels.FindAsync(id);
            if (existingSublevel == null)
            {
                return NotFound();
            }

            existingSublevel.Name = updatedSublevel.Name;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var sublevelToDelete = await _context.Sublevels.FindAsync(id);
            if (sublevelToDelete == null)
            {
                return NotFound();
            }

            _context.Sublevels.Remove(sublevelToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
