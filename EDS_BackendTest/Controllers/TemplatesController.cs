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
    public class TemplatesController : ControllerBase
    {
        private readonly DBContext _context;

        public TemplatesController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Template>> Get()
        {
            return await _context.Templates.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Template), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var template = await _context.Templates.FindAsync(id);
            return template == null ? NotFound() : Ok(template);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Template template)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Templates.AddAsync(template);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = template.TemplateID }, template);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, Template updatedTemplate)
        {
            if (id != updatedTemplate.TemplateID)
            {
                return BadRequest("ID mismatch");
            }

            var existingTemplate = await _context.Templates.FindAsync(id);
            if (existingTemplate == null)
            {
                return NotFound();
            }

            // Update the existingTemplate properties here

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var templateToDelete = await _context.Templates.FindAsync(id);
            if (templateToDelete == null)
            {
                return NotFound();
            }

            _context.Templates.Remove(templateToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
