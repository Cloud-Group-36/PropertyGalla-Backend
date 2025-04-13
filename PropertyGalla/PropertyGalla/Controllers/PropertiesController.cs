using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyGalla.Data;
using PropertyGalla.DTOs.ProprtyDTOs;
using PropertyGalla.Models;
using PropertyGalla.Services;

namespace PropertyGalla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly PropertyGallaContext _context;
        private readonly IdGeneratorService _idGenerator;

        public PropertiesController(PropertyGallaContext context)
        {
            _context = context;
            _idGenerator = new IdGeneratorService(context);
        }

        // ✅ GET: api/Properties with pagination + filtering
        // ✅ GET: api/Properties with filtering by title, location, price range, and date range
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPropertyDto>>> GetProperties(
            [FromQuery] string? title = null,
            [FromQuery] string? location = null,
            [FromQuery] decimal? minPrice = null,
            [FromQuery] decimal? maxPrice = null,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null,
            [FromQuery] int? page = null,
            [FromQuery] int? pageSize = null)
        {
            var query = _context.Properties
                .Include(p => p.Images)
                .AsQueryable();

            if (!string.IsNullOrEmpty(title))
                query = query.Where(p => p.Title.Contains(title));

            if (!string.IsNullOrEmpty(location))
                query = query.Where(p => p.Location.Contains(location));

            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice);

            if (startDate.HasValue)
                query = query.Where(p => p.CreatedAt >= startDate);

            if (endDate.HasValue)
                query = query.Where(p => p.CreatedAt <= endDate);

            if (page.HasValue && pageSize.HasValue)
            {
                query = query
                    .Skip((page.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value);
            }

            var properties = await query.ToListAsync();

            return properties.Select(p => new GetPropertyDto
            {
                PropertyId = p.PropertyId,
                Title = p.Title,
                Description = p.Description,
                Location = p.Location,
                Price = p.Price,
                OwnerId = p.OwnerId,
                Status = p.Status,
                Images = p.Images.Select(i => i.ImageUrl).ToList()
            }).ToList();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<GetPropertyDto>> GetProperty(string id)
        {
            var property = await _context.Properties
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.PropertyId == id);

            if (property == null)
                return NotFound();

            return new GetPropertyDto
            {
                PropertyId = property.PropertyId,
                Title = property.Title,
                Description = property.Description,
                Location = property.Location,
                Price = property.Price,
                OwnerId = property.OwnerId,
                Status = property.Status,
                Images = property.Images.Select(i => i.ImageUrl).ToList()
            };
        }

        [HttpPost]
        [HttpPost]
        public async Task<ActionResult<Property>> PostProperty(CreatePropertyDto dto)
        {
            try
            {
                var ownerExists = await _context.Users.AnyAsync(u => u.UserId == dto.OwnerId);
                if (!ownerExists)
                    return BadRequest(new { message = "OwnerId does not exist in Users table" });

                var propertyId = await _idGenerator.GenerateIdAsync("properties");

                var property = new Property
                {
                    PropertyId = propertyId,
                    Title = dto.Title,
                    Description = dto.Description,
                    Location = dto.Location,
                    Price = dto.Price,
                    OwnerId = dto.OwnerId,
                    Status = "available",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _context.Properties.Add(property);
                await _context.SaveChangesAsync();

                if (dto.Images != null)
                {
                    foreach (var url in dto.Images)
                    {
                        _context.PropertyImages.Add(new PropertyImage
                        {
                            PropertyId = propertyId,
                            ImageUrl = url
                        });
                    }
                    await _context.SaveChangesAsync();
                }

                return CreatedAtAction("GetProperty", new { id = property.PropertyId }, property);
            }
            catch (DbUpdateException dbEx)
            {
                var innerMessage = dbEx.InnerException?.Message ?? "No inner exception";
                return StatusCode(500, new
                {
                    message = "Database update error",
                    error = dbEx.Message,
                    inner = innerMessage
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Unexpected server error",
                    error = ex.Message,
                    stack = ex.StackTrace
                });
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperty(string id, UpdatePropertyDto dto)
        {
            if (id != dto.PropertyId)
                return BadRequest(new { message = "Mismatched property ID." });

            var property = await _context.Properties
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.PropertyId == id);

            if (property == null)
                return NotFound();

            property.Title = dto.Title;
            property.Description = dto.Description;
            property.Location = dto.Location;
            property.Price = dto.Price;
            property.OwnerId = dto.OwnerId;
            property.UpdatedAt = DateTime.Now;

            _context.PropertyImages.RemoveRange(property.Images);

            if (dto.Images != null)
            {
                property.Images = dto.Images.Select(url => new PropertyImage
                {
                    ImageUrl = url,
                    PropertyId = id
                }).ToList();
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(string id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property == null)
                return NotFound();

            var images = _context.PropertyImages.Where(i => i.PropertyId == id);
            _context.PropertyImages.RemoveRange(images);

            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropertyExists(string id)
        {
            return _context.Properties.Any(e => e.PropertyId == id);
        }
    }
}