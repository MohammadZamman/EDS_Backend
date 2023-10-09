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
    public class DataRecepientsController : ControllerBase
    {
        private readonly DBContext _context;

        public DataRecepientsController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<DataRecepient>> Get()
        {
            return await _context.DataRecepients.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DataRecepient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var dataRecepient = await _context.DataRecepients.FindAsync(id);
            return dataRecepient == null ? NotFound() : Ok(dataRecepient);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(DataRecepient dataRecepient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.DataRecepients.AddAsync(dataRecepient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = dataRecepient.DataRecipientID }, dataRecepient);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, DataRecepient updatedDataRecepient)
        {
            if (id != updatedDataRecepient.DataRecipientID)
            {
                return BadRequest("ID mismatch");
            }

            var existingDataRecepient = await _context.DataRecepients.FindAsync(id);
            if (existingDataRecepient == null)
            {
                return NotFound();
            }

            // Update the existingDataRecepient properties here

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var dataRecepientToDelete = await _context.DataRecepients.FindAsync(id);
            if (dataRecepientToDelete == null)
            {
                return NotFound();
            }

            _context.DataRecepients.Remove(dataRecepientToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
