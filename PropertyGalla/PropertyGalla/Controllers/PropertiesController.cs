﻿using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
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

        // 🟢 PUBLIC GET: /api/Properties?filters...
        // 🟢 PUBLIC GET: /api/Properties?filters...
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPropertyDto>>> GetProperties(
            [FromQuery] string? title = null,
            [FromQuery] string? state = null,
            [FromQuery] string? city = null,
            [FromQuery] int? rooms = null,
            [FromQuery] int? bathrooms = null,
            [FromQuery] int? parking = null,
            [FromQuery] double? minArea = null,
            [FromQuery] double? maxArea = null,
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
            if (!string.IsNullOrEmpty(state))
                query = query.Where(p => p.State.Contains(state));
            if (!string.IsNullOrEmpty(city))
                query = query.Where(p => p.City.Contains(city));
            if (rooms.HasValue)
                query = query.Where(p => p.Rooms == rooms);
            if (bathrooms.HasValue)
                query = query.Where(p => p.Bathrooms == bathrooms);
            if (parking.HasValue)
                query = query.Where(p => p.Parking == parking);
            if (minArea.HasValue)
                query = query.Where(p => p.Area >= minArea);
            if (maxArea.HasValue)
                query = query.Where(p => p.Area <= maxArea);
            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice);
            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice);
            if (startDate.HasValue)
                query = query.Where(p => p.CreatedAt >= startDate);
            if (endDate.HasValue)
                query = query.Where(p => p.CreatedAt <= endDate);
            if (page.HasValue && pageSize.HasValue)
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);

            var properties = await query.ToListAsync();

            return properties.Select(p => new GetPropertyDto
            {
                PropertyId = p.PropertyId,
                Title = p.Title,
                Description = p.Description,
                Rooms = p.Rooms,
                Bathrooms = p.Bathrooms,
                Parking = p.Parking,
                Area = p.Area,
                State = p.State,
                City = p.City,
                Neighborhood = p.Neighborhood,
                Price = p.Price,
                OwnerId = p.OwnerId,
                Status = p.Status,
                Images = p.Images.Select(i => $"/api/Properties/image/{i.Id}").ToList()
            }).ToList();
        }

        // 🟢 PUBLIC GET: /api/Properties/PRO0001
        [HttpGet("{id}")]
        public async Task<ActionResult<GetPropertyDto>> GetProperty(string id)
        {
            try
            {
                var property = await _context.Properties
                    .Include(p => p.Images)
                    .FirstOrDefaultAsync(p => p.PropertyId == id);

                if (property == null)
                    return NotFound(new { message = $"Property with ID {id} not found." });

                return new GetPropertyDto
                {
                    PropertyId = property.PropertyId,
                    Title = property.Title,
                    Description = property.Description,
                    Rooms = property.Rooms,
                    Bathrooms = property.Bathrooms,
                    Parking = property.Parking,
                    Area = property.Area,
                    State = property.State,
                    City = property.City,
                    Neighborhood = property.Neighborhood,
                    Price = property.Price,
                    OwnerId = property.OwnerId,
                    Status = property.Status,
                    Images = property.Images.Select(i => $"/api/Properties/image/{i.Id}").ToList()
                };
            }
            catch (Exception ex)
            {
                // 👇 Debug log to console and return proper CORS-friendly error
                Console.WriteLine($"[ERROR GET /properties/{id}] {ex.Message}");

                HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                return StatusCode(500, new
                {
                    message = "❌ Server error while retrieving property.",
                    error = ex.Message,
                    inner = ex.InnerException?.Message
                });
            }
        }


        [HttpGet("image/{imageId}")]
        public async Task<IActionResult> GetImage(int imageId)
        {
            var image = await _context.PropertyImages.FindAsync(imageId);
            if (image == null) return NotFound();
            return File(image.ImageData, image.ContentType);
        }

        [HttpPost("with-files")]
        [Authorize]
        public async Task<ActionResult<Property>> PostPropertyWithFiles([FromForm] CreatePropertyWithFilesDto dto)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (dto.OwnerId != currentUserId) return Forbid("You can only post properties as yourself.");

            var propertyId = await _idGenerator.GenerateIdAsync("properties");

            var property = new Property
            {
                PropertyId = propertyId,
                Title = dto.Title,
                Description = dto.Description,
                Rooms = dto.Rooms,
                Bathrooms = dto.Bathrooms,
                Parking = dto.Parking,
                Area = dto.Area,
                State = dto.State,
                City = dto.City,
                Neighborhood = dto.Neighborhood,
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
                foreach (var file in dto.Images)
                {
                    using var ms = new MemoryStream();
                    await file.CopyToAsync(ms);
                    _context.PropertyImages.Add(new PropertyImage
                    {
                        PropertyId = propertyId,
                        ImageData = ms.ToArray(),
                        ContentType = file.ContentType
                    });
                }
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction(nameof(GetProperty), new { id = property.PropertyId }, property);
        }


        // 🔐 PUT: Only property owner can update
        // PUT: /api/Properties/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutProperty(string id, [FromForm] UpdatePropertyDto dto)
        {
            if (id != dto.PropertyId)
                return BadRequest("Property ID mismatch.");

            var property = await _context.Properties.Include(p => p.Images).FirstOrDefaultAsync(p => p.PropertyId == id);
            if (property == null)
                return NotFound();

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (property.OwnerId != currentUserId)
                return Forbid("Only the owner can update this property.");

            property.Title = dto.Title;
            property.Description = dto.Description;
            property.Rooms = dto.Rooms;
            property.Bathrooms = dto.Bathrooms;
            property.Parking = dto.Parking;
            property.Area = dto.Area;
            property.State = dto.State;
            property.City = dto.City;
            property.Neighborhood = dto.Neighborhood;
            property.Price = dto.Price;
            property.UpdatedAt = DateTime.Now;

            // Handle image deletions
            var removeImageUrls = dto.RemoveImageUrls ?? new List<string>();
            var idsToRemove = removeImageUrls
                .Select(url => int.TryParse(url.Split("/").Last(), out var id) ? id : (int?)null)
                .Where(id => id.HasValue)
                .Select(id => id.Value)
                .ToList();

            var toDelete = property.Images.Where(i => idsToRemove.Contains(i.Id)).ToList();
            _context.PropertyImages.RemoveRange(toDelete);

            // Handle new image uploads
            if (dto.Images != null && dto.Images.Any())
            {
                foreach (var file in dto.Images)
                {
                    using var ms = new MemoryStream();
                    await file.CopyToAsync(ms);
                    _context.PropertyImages.Add(new PropertyImage
                    {
                        PropertyId = id,
                        ImageData = ms.ToArray(),
                        ContentType = file.ContentType
                    });
                }
            }

            // Make sure at least one image remains
            var remainingImageCount = property.Images.Count - toDelete.Count + (dto.Images?.Count ?? 0);
            if (remainingImageCount == 0)
            {
                return BadRequest(new { message = "At least one image must remain after update." });
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }


        // 🔐 DELETE: Only owner or admin
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProperty(string id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property == null) return NotFound();

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = User.IsInRole("admin");

            if (property.OwnerId != currentUserId && !isAdmin)
                return Forbid("Only the owner or admin can delete this property.");

            var images = _context.PropertyImages.Where(i => i.PropertyId == id);
            _context.PropertyImages.RemoveRange(images);
            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
