using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyGalla.Data;
using PropertyGalla.DTOs.ViewRequestDTOs;
using PropertyGalla.Models;
using PropertyGalla.Services;

namespace PropertyGalla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewRequestsController : ControllerBase
    {
        private readonly PropertyGallaContext _context;
        private readonly IdGeneratorService _idGenerator;

        public ViewRequestsController(PropertyGallaContext context)
        {
            _context = context;
            _idGenerator = new IdGeneratorService(context);
        }

        // ✅ GET: api/ViewRequests?userId=...&propertyId=...&startDate=...&endDate=...&page=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetViewRequests(
            [FromQuery] string? userId,
            [FromQuery] string? propertyId,
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            if (page <= 0 || pageSize <= 0)
                return BadRequest(new { message = "Page and pageSize must be positive integers." });

            var query = _context.ViewRequests.AsQueryable();

            if (!string.IsNullOrWhiteSpace(userId))
                query = query.Where(vr => vr.UserId == userId);

            if (!string.IsNullOrWhiteSpace(propertyId))
                query = query.Where(vr => vr.PropertyId == propertyId);

            if (startDate.HasValue)
                query = query.Where(vr => vr.CreatedAt >= startDate.Value.Date);

            if (endDate.HasValue)
                query = query.Where(vr => vr.CreatedAt < endDate.Value.Date.AddDays(1));

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var pagedResults = await query
                .OrderByDescending(vr => vr.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(new
            {
                currentPage = page,
                totalPages,
                totalCount,
                pageSize,
                results = pagedResults
            });
        }




        // ✅ POST: api/ViewRequests
        [HttpPost]
        public async Task<ActionResult<ViewRequest>> PostViewRequest([FromBody] CreateViewRequestDto dto)
        {
            var userExists = await _context.Users.AnyAsync(u => u.UserId == dto.UserId);
            var propertyExists = await _context.Properties.AnyAsync(p => p.PropertyId == dto.PropertyId);

            if (!userExists || !propertyExists)
                return BadRequest(new { message = "Invalid UserId or PropertyId" });

            // 🔍 Check for duplicate request that is not handled
            var existing = await _context.ViewRequests.FirstOrDefaultAsync(vr =>
                vr.UserId == dto.UserId &&
                vr.PropertyId == dto.PropertyId &&
                vr.Status != "handled");

            if (existing != null)
            {
                return Conflict(new { message = "A view request already exists for this user and property and is not handled yet." });
            }

            var id = await _idGenerator.GenerateIdAsync("viewrequests");

            var viewRequest = new ViewRequest
            {
                ViewRequestId = id,
                UserId = dto.UserId,
                PropertyId = dto.PropertyId,
                Text = dto.Text, 
                Status = "pending",
                CreatedAt = DateTime.UtcNow
            };


            _context.ViewRequests.Add(viewRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetViewRequests), new { userId = dto.UserId }, viewRequest);
        }

        // ✅ PATCH: api/ViewRequests/VRQ0001/status
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(string id, [FromBody] UpdateViewRequestStatusDto dto)
        {
            if (dto.Status != "pending" && dto.Status != "handled")
                return BadRequest(new { message = "Invalid status. Only 'pending' or 'handled' are allowed." });

            var request = await _context.ViewRequests.FindAsync(id);
            if (request == null)
                return NotFound(new { message = "View request not found" });

            request.Status = dto.Status;
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Status updated to {dto.Status}" });
        }


        // ✅ DELETE: api/ViewRequests/VRQ0001
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViewRequest(string id)
        {
            var request = await _context.ViewRequests.FindAsync(id);
            if (request == null)
                return NotFound(new { message = "View request not found" });

            _context.ViewRequests.Remove(request);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
