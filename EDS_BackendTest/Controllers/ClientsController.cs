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
    public class ClientsController : ControllerBase
    {
        private readonly DBContext _context;

        public ClientsController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Client>> Get()
        {
            return await _context.Clients.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            return client == null ? NotFound() : Ok(client);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = client.ClientID }, client);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, Client updatedClient)
        {
            if (id != updatedClient.ClientID)
            {
                return BadRequest("ID mismatch");
            }

            var existingClient = await _context.Clients.FindAsync(id);
            if (existingClient == null)
            {
                return NotFound();
            }

            existingClient.ClientName = updatedClient.ClientName;
            existingClient.Organization = updatedClient.Organization;
            existingClient.Active = updatedClient.Active;
            existingClient.CreatedAt = updatedClient.CreatedAt;
            existingClient.CreatedBy = updatedClient.CreatedBy;
            existingClient.UpdatedAt = updatedClient.UpdatedAt;
            existingClient.UpdatedBy = updatedClient.UpdatedBy;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetNameById(int id, Client updatedClient)
        //{
        //    if (id != updatedClient.ClientID)
        //    {
        //        return BadRequest("ID mismatch");
        //    }

        //    var existingClient = await _context.Clients.FindAsync(id);
        //    if (existingClient == null)
        //    {
        //        return NotFound();
        //    }

        //    // Update the existingClient properties here

        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var clientToDelete = await _context.Clients.FindAsync(id);
            if (clientToDelete == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(clientToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //[HttpGet("{id}/name")]
        //[ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetNameById(int id)
        //{
        //    var client = await _context.Clients.FindAsync(id);
        //    if (client == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(client.ClientName);  
        //}

    }
}
