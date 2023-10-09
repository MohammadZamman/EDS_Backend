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
    public class CategoriesController : ControllerBase
    {
        private readonly DBContext _context;

        public CategoriesController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _context.Categories.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category == null ? NotFound() : Ok(category);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = category.CategoryId }, category);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, Category updatedCategory)
        {
            if (id != updatedCategory.CategoryId)
            {
                return BadRequest("ID mismatch");
            }

            var existingCategory = await _context.Categories.FindAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            // Update the existingCategory properties here

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var categoryToDelete = await _context.Categories.FindAsync(id);
            if (categoryToDelete == null)
            {
                return NotFound();
            }

            // Find and delete related jobs with the specified Template's CategoryId
            var relatedJobs = _context.Jobs.Where(job => job.Template.CategoryId == id).ToList();

            // Loop through related jobs and delete them
            foreach (var job in relatedJobs)
            {
                // Delete job logs associated with the job
                var jobLogs = _context.JobLogs.Where(jobLog => jobLog.JobID == job.JobID).ToList();
                _context.JobLogs.RemoveRange(jobLogs);

                // Remove the job from the context
                _context.Jobs.Remove(job);
            }

            // Now, you can safely delete the category
            _context.Categories.Remove(categoryToDelete);

            await _context.SaveChangesAsync();

            return NoContent();
        }



    }
}
