using EDS_BackendTest.DataContext;
using EDS_BackendTest.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_BackendTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupsController : ControllerBase
    {
        private readonly DBContext _context;

        public LookupsController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Lookups>> Get()
        {
            return await _context.Lookup.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Lookups), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var lookup = await _context.Lookup.FindAsync(id);
            return lookup == null ? NotFound() : Ok(lookup);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Lookups lookup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Lookup.AddAsync(lookup);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = lookup.LookUpID }, lookup);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, Lookups updatedLookup)
        {
            if (id != updatedLookup.LookUpID)
            {
                return BadRequest("ID mismatch");
            }

            var existingLookup = await _context.Lookup.FindAsync(id);
            if (existingLookup == null)
            {
                return NotFound();
            }

            // Update the existingLookup properties here

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var lookupToDelete = await _context.Lookup.FindAsync(id);
            if (lookupToDelete == null)
            {
                return NotFound();
            }

            _context.Lookup.Remove(lookupToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
