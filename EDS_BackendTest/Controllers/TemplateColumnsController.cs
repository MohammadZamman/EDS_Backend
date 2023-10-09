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
    public class TemplateColumnsController : ControllerBase
    {
        private readonly DBContext _context;

        public TemplateColumnsController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<TemplateColumns>> Get()
        {
            return await _context.TemplateColumns.Include(tc => tc.Template).Include(tc => tc.Column).ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TemplateColumns), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var templateColumn = await _context.TemplateColumns
                .Include(tc => tc.Template)
                .Include(tc => tc.Column)
                .FirstOrDefaultAsync(tc => tc.TemplateID == id);

            return templateColumn == null ? NotFound() : Ok(templateColumn);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(TemplateColumns templateColumn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TemplateColumns.Add(templateColumn);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = templateColumn.TemplateID }, templateColumn);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, TemplateColumns updatedTemplateColumn)
        {
            if (id != updatedTemplateColumn.TemplateID)
            {
                return BadRequest("ID mismatch");
            }

            var existingTemplateColumn = await _context.TemplateColumns.FindAsync(id);
            if (existingTemplateColumn == null)
            {
                return NotFound();
            }

            // Update the existingTemplateColumn properties here
            existingTemplateColumn.TemplateID = updatedTemplateColumn.TemplateID;
            existingTemplateColumn.ColumnId = updatedTemplateColumn.ColumnId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var templateColumnToDelete = await _context.TemplateColumns.FindAsync(id);
            if (templateColumnToDelete == null)
            {
                return NotFound();
            }

            _context.TemplateColumns.Remove(templateColumnToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
