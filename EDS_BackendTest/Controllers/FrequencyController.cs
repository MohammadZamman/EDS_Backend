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
    public class FrequenciesController : ControllerBase
    {
        private readonly DBContext _context;

        public FrequenciesController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Frequency>> Get()
        {
            return await _context.Frequencies.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Frequency), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var frequency = await _context.Frequencies.FindAsync(id);
            return frequency == null ? NotFound() : Ok(frequency);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Frequency frequency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Frequencies.AddAsync(frequency);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = frequency.FrequencyID }, frequency);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, Frequency updatedFrequency)
        {
            if (id != updatedFrequency.FrequencyID)
            {
                return BadRequest("ID mismatch");
            }

            var existingFrequency = await _context.Frequencies.FindAsync(id);
            if (existingFrequency == null)
            {
                return NotFound();
            }

            // Update the existingFrequency properties here

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var frequencyToDelete = await _context.Frequencies.FindAsync(id);
            if (frequencyToDelete == null)
            {
                return NotFound();
            }

            _context.Frequencies.Remove(frequencyToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
