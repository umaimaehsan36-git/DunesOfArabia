using Microsoft.AspNetCore.Identity;
using DunesOfArabia.Models;

namespace DunesOfArabia.Services
{
    // ─────────────────────────────────────────────
    // DTOs  (Data Transfer Objects)
    // Small classes just for carrying data in/out
    // ─────────────────────────────────────────────

    public class RegisterRequest
    {
        public string FullName { get; set; } = string.Empty;
        public string Email    { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginRequest
    {
        public string Email    { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class AuthResult
    {
        public bool    Success  { get; set; }
        public string? Token    { get; set; }   // JWT token (null if failed)
        public string? Error    { get; set; }   // Error message (null if success)
        public string? UserName { get; set; }
        public string? Role     { get; set; }
    }

    // ─────────────────────────────────────────────
    // INTERFACE
    // ─────────────────────────────────────────────
    public interface IAuthService
    {
        Task<AuthResult> RegisterAsync(RegisterRequest request, string role = "User");
        Task<AuthResult> LoginAsync(LoginRequest request);
    }

    // ─────────────────────────────────────────────
    // IMPLEMENTATION
    // ─────────────────────────────────────────────
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser>  _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole>     _roleManager;
        private readonly IJwtService                   _jwtService;

        public AuthService(
            UserManager<ApplicationUser>  userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole>     roleManager,
            IJwtService                   jwtService)
        {
            _userManager   = userManager;
            _signInManager = signInManager;
            _roleManager   = roleManager;
            _jwtService    = jwtService;
        }

        // ── REGISTER ──────────────────────────────
        public async Task<AuthResult> RegisterAsync(RegisterRequest req, string role = "User")
        {
            // 1. Check email not already taken
            if (await _userManager.FindByEmailAsync(req.Email) != null)
                return new AuthResult { Success = false, Error = "Email already registered." };

            // 2. Create user object
            var user = new ApplicationUser
            {
                UserName = req.Email,
                Email    = req.Email,
                FullName = req.FullName
            };

            // 3. Save user with hashed password (Identity handles hashing)
            var result = await _userManager.CreateAsync(user, req.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return new AuthResult { Success = false, Error = errors };
            }

            // 4. Create role if it doesn't exist, then assign it
            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));

            await _userManager.AddToRoleAsync(user, role);

            // 5. Generate JWT token
            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtService.GenerateToken(user, roles);

            return new AuthResult
            {
                Success  = true,
                Token    = token,
                UserName = user.FullName ?? user.Email,
                Role     = role
            };
        }

        // ── LOGIN ─────────────────────────────────
        public async Task<AuthResult> LoginAsync(LoginRequest req)
        {
            // 1. Find user by email
            var user = await _userManager.FindByEmailAsync(req.Email);
            if (user == null)
                return new AuthResult { Success = false, Error = "Invalid email or password." };

            // 2. Check password (false = don't lock out on failure)
            var result = await _signInManager.CheckPasswordSignInAsync(user, req.Password, false);
            if (!result.Succeeded)
                return new AuthResult { Success = false, Error = "Invalid email or password." };

            // 3. Get user roles and generate token
            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtService.GenerateToken(user, roles);

            return new AuthResult
            {
                Success  = true,
                Token    = token,
                UserName = user.FullName ?? user.Email,
                Role     = roles.FirstOrDefault() ?? "User"
            };
        }
    }
}
