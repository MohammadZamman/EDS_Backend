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
    public class OrganizationLevelsController : ControllerBase
    {
        private readonly DBContext _context;

        public OrganizationLevelsController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<OrganizationLevel>> Get()
        {
            return await _context.OrganizationLevels.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrganizationLevel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var organizationLevel = await _context.OrganizationLevels.FindAsync(id);
            return organizationLevel == null ? NotFound() : Ok(organizationLevel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(OrganizationLevel organizationLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrganizationLevels.Add(organizationLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = organizationLevel.LevelID }, organizationLevel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, OrganizationLevel updatedOrganizationLevel)
        {
            if (id != updatedOrganizationLevel.LevelID)
            {
                return BadRequest("ID mismatch");
            }

            var existingOrganizationLevel = await _context.OrganizationLevels.FindAsync(id);
            if (existingOrganizationLevel == null)
            {
                return NotFound();
            }

            existingOrganizationLevel.Name = updatedOrganizationLevel.Name;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var organizationLevelToDelete = await _context.OrganizationLevels.FindAsync(id);
            if (organizationLevelToDelete == null)
            {
                return NotFound();
            }

            _context.OrganizationLevels.Remove(organizationLevelToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
