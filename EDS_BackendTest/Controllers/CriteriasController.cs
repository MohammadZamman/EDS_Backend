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
    public class CriteriasController : ControllerBase
    {
        private readonly DBContext _context;

        public CriteriasController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Criteria>> Get()
        {
            return await _context.Criterias.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Criteria), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var criteria = await _context.Criterias.FindAsync(id);
            return criteria == null ? NotFound() : Ok(criteria);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Criteria criteria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Criterias.AddAsync(criteria);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = criteria.CriteriaID }, criteria);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, Criteria updatedCriteria)
        {
            if (id != updatedCriteria.CriteriaID)
            {
                return BadRequest("ID mismatch");
            }

            var existingCriteria = await _context.Criterias.FindAsync(id);
            if (existingCriteria == null)
            {
                return NotFound();
            }

            // Update the existingCriteria properties here

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var criteriaToDelete = await _context.Criterias.FindAsync(id);
            if (criteriaToDelete == null)
            {
                return NotFound();
            }

            _context.Criterias.Remove(criteriaToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
