using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyGalla.Data;
using PropertyGalla.DTOs.SavedPropertyDTOs;
using PropertyGalla.Models;

namespace PropertyGalla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavedPropertiesController : ControllerBase
    {
        private readonly PropertyGallaContext _context;

        public SavedPropertiesController(PropertyGallaContext context)
        {
            _context = context;
        }

        // ✅ GET: api/SavedProperties?userId=USR0001
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SavedPropertyDto>>> GetSavedProperties([FromQuery] string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return BadRequest(new { message = "UserId is required" });

            var saved = await _context.SavedProperties
                .Where(sp => sp.UserId == userId)
                .Select(sp => new SavedPropertyDto
                {
                    UserId = sp.UserId,
                    PropertyId = sp.PropertyId
                }).ToListAsync();

            return Ok(saved);
        }

        // ✅ POST: api/SavedProperties
        [HttpPost]
        public async Task<IActionResult> PostSavedProperty([FromBody] SavedPropertyDto dto)
        {
            if (await _context.SavedProperties.AnyAsync(sp => sp.UserId == dto.UserId && sp.PropertyId == dto.PropertyId))
                return Conflict(new { message = "Property is already saved by this user." });

            var saved = new SavedProperty
            {
                UserId = dto.UserId,
                PropertyId = dto.PropertyId
            };

            _context.SavedProperties.Add(saved);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSavedProperties), new { userId = dto.UserId }, dto);
        }

        // ✅ DELETE: api/SavedProperties/USR0001/PRO0012
        [HttpDelete("{userId}/{propertyId}")]
        public async Task<IActionResult> DeleteSavedProperty(string userId, string propertyId)
        {
            var entry = await _context.SavedProperties
                .FirstOrDefaultAsync(sp => sp.UserId == userId && sp.PropertyId == propertyId);

            if (entry == null)
                return NotFound(new { message = "Saved property not found" });

            _context.SavedProperties.Remove(entry);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
