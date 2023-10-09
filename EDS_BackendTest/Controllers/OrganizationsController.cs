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
    public class OrganizationsController : ControllerBase
    {
        private readonly DBContext _context;

        public OrganizationsController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Organization>> Get()
        {
            return await _context.Organizations.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Organization), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var organization = await _context.Organizations.FindAsync(id);
            return organization == null ? NotFound() : Ok(organization);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            organization.CreatedAt = DateTime.UtcNow;
            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = organization.OrgID }, organization);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, Organization updatedOrganization)
        {
            if (id != updatedOrganization.OrgID)
            {
                return BadRequest("ID mismatch");
            }

            var existingOrganization = await _context.Organizations.FindAsync(id);
            if (existingOrganization == null)
            {
                return NotFound();
            }
             
            existingOrganization.OrgName = updatedOrganization.OrgName; 
            existingOrganization.UpdatedAt = DateTime.UtcNow;
            existingOrganization.UpdatedBy = updatedOrganization.UpdatedBy;
            existingOrganization.Active = updatedOrganization.Active;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var organizationToDelete = await _context.Organizations.FindAsync(id);
            if (organizationToDelete == null)
            {
                return NotFound();
            }

            _context.Organizations.Remove(organizationToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
