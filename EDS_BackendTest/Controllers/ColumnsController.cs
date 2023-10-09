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
    public class ColumnsController : ControllerBase
    {
        private readonly DBContext _context;

        public ColumnsController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Columns>> Get()
        {
            return await _context.Columns.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Columns), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var column = await _context.Columns.FindAsync(id);
            return column == null ? NotFound() : Ok(column);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Columns column)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Columns.AddAsync(column);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = column.ColumnId }, column);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, Columns updatedColumn)
        {
            if (id != updatedColumn.ColumnId)
            {
                return BadRequest("ID mismatch");
            }

            var existingColumn = await _context.Columns.FindAsync(id);
            if (existingColumn == null)
            {
                return NotFound();
            }

            // Update the existingColumn properties here

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var columnToDelete = await _context.Columns.FindAsync(id);
            if (columnToDelete == null)
            {
                return NotFound();
            }

            _context.Columns.Remove(columnToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
