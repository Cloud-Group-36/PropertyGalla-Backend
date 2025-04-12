using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyGalla.Data;
using PropertyGalla.DTOs.UserDTOs;
using PropertyGalla.Models;
using PropertyGalla.Services;

namespace PropertyGalla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly PropertyGallaContext _context;
        private readonly IdGeneratorService _idGenerator;

        public UsersController(PropertyGallaContext context)
        {
            _context = context;
            _idGenerator = new IdGeneratorService(context);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(
            [FromQuery] string? name = null,
            [FromQuery] string? email = null,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 5)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(u => u.Name.Contains(name));

            if (!string.IsNullOrEmpty(email))
                query = query.Where(u => u.Email.Contains(email));

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var users = await query
                .OrderBy(u => u.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(u => new UserResponseDto
                {
                    UserId = u.UserId,
                    Name = u.Name,
                    Email = u.Email,
                    Phone = u.Phone,
                    Role = u.Role,
                    CreatedAt = u.CreatedAt
                }).ToListAsync();

            return Ok(new
            {
                currentPage = page,
                totalPages,
                totalCount,
                pageSize,
                users
            });
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDto>> GetUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found" });

            return new UserResponseDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserResponseDto>> Login([FromBody] LoginDto loginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
            if (user == null || !PasswordService.VerifyPassword(loginDto.Password, user.Password))
                return Unauthorized(new { message = "Invalid email or password" });

            return new UserResponseDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            };
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == changePasswordDto.Email);
            if (user == null)
                return NotFound(new { message = "User not found" });

            if (!PasswordService.VerifyPassword(changePasswordDto.OldPassword, user.Password))
                return Unauthorized(new { message = "Incorrect old password" });

            user.Password = PasswordService.HashPassword(changePasswordDto.NewPassword);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Password changed successfully" });
        }


        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> PostUser([FromBody] RegisterDto registerDto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == registerDto.Email))
                return BadRequest(new { message = "Email is already taken" });

            var user = new User
            {
                UserId = await _idGenerator.GenerateIdAsync("users"),
                Name = registerDto.Name,
                Email = registerDto.Email,
                Password = PasswordService.HashPassword(registerDto.Password),
                Phone = registerDto.Phone,
                Role = registerDto.Role,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, new UserResponseDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, [FromBody] UpdateUserDto userDto)
        {
            if (id != userDto.UserId)
                return BadRequest(new { message = "Mismatched user ID" });

            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found" });

            if (!PasswordService.VerifyPassword(userDto.Password, user.Password))
                return Unauthorized(new { message = "Incorrect password" });

            user.Name = userDto.Name;
            user.Phone = userDto.Phone;
            user.Email = userDto.Email;
            user.Role = userDto.Role;

            await _context.SaveChangesAsync();

            return Ok(new { message = "User updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found" });

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
