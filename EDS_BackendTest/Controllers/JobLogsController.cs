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
    public class JobLogsController : ControllerBase
    {
        private readonly DBContext _context;

        public JobLogsController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<JobLog>> Get()
        {
            return await _context.JobLogs.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(JobLog), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var jobLog = await _context.JobLogs.FindAsync(id);
            return jobLog == null ? NotFound() : Ok(jobLog);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(JobLog jobLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.JobLogs.AddAsync(jobLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = jobLog.JobLogID }, jobLog);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, JobLog updatedJobLog)
        {
            if (id != updatedJobLog.JobLogID)
            {
                return BadRequest("ID mismatch");
            }

            var existingJobLog = await _context.JobLogs.FindAsync(id);
            if (existingJobLog == null)
            {
                return NotFound();
            }

            // Update the existingJobLog properties here

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var jobLogToDelete = await _context.JobLogs.FindAsync(id);
            if (jobLogToDelete == null)
            {
                return NotFound();
            }

            _context.JobLogs.Remove(jobLogToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
