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
    public class NotificationRecipientsController : ControllerBase
    {
        private readonly DBContext _context;

        public NotificationRecipientsController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<NotificationRecepient>> Get()
        {
            return await _context.notificationRecepients.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(NotificationRecepient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var notificationRecepient = await _context.notificationRecepients.FindAsync(id);
            return notificationRecepient == null ? NotFound() : Ok(notificationRecepient);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(NotificationRecepient notificationRecepient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.notificationRecepients.AddAsync(notificationRecepient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = notificationRecepient.NotificationRecipientID }, notificationRecepient);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, NotificationRecepient updatedNotificationRecepient)
        {
            if (id != updatedNotificationRecepient.NotificationRecipientID)
            {
                return BadRequest("ID mismatch");
            }

            var existingNotificationRecepient = await _context.notificationRecepients.FindAsync(id);
            if (existingNotificationRecepient == null)
            {
                return NotFound();
            }

            // Update the existingNotificationRecepient properties here

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var notificationRecepientToDelete = await _context.notificationRecepients.FindAsync(id);
            if (notificationRecepientToDelete == null)
            {
                return NotFound();
            }

            _context.notificationRecepients.Remove(notificationRecepientToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
