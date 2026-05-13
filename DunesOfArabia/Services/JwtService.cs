using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DunesOfArabia.Models;

namespace DunesOfArabia.Services
{
    // ─────────────────────────────────────────────
    // INTERFACE  (the "contract")
    // ─────────────────────────────────────────────
    public interface IJwtService
    {
        /// <summary>Creates a signed JWT token for the given user and roles.</summary>
        string GenerateToken(ApplicationUser user, IList<string> roles);

        /// <summary>Reads the token and returns the claims inside it.</summary>
        ClaimsPrincipal? ValidateToken(string token);
    }

    // ─────────────────────────────────────────────
    // IMPLEMENTATION
    // ─────────────────────────────────────────────
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;

        // IConfiguration lets us read appsettings.json values
        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        // ── GenerateToken ──────────────────────────
        public string GenerateToken(ApplicationUser user, IList<string> roles)
        {
            // 1. Read secret key from appsettings.json → Jwt:SecretKey
            var secretKey = _config["Jwt:SecretKey"]
                ?? throw new InvalidOperationException("JWT SecretKey missing in appsettings.json");

            // 2. Create signing credentials using HMAC-SHA256
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 3. Build claims (data stored INSIDE the token)
            //    Claims are like fields in an ID card
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),          // user's database ID
                new Claim(ClaimTypes.Email,           user.Email ?? ""), // email
                new Claim(ClaimTypes.Name,            user.FullName ?? user.UserName ?? ""), // display name
            };

            // 4. Add each role as a separate claim
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            // 5. Build the token object (expires in 7 days)
            var token = new JwtSecurityToken(
                issuer:             null,           // not validating issuer
                audience:           null,           // not validating audience
                claims:             claims,
                expires:            DateTime.UtcNow.AddDays(7),
                signingCredentials: creds
            );

            // 6. Serialize token to the three-part string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // ── ValidateToken ──────────────────────────
        public ClaimsPrincipal? ValidateToken(string token)
        {
            var secretKey = _config["Jwt:SecretKey"]
                ?? throw new InvalidOperationException("JWT SecretKey missing in appsettings.json");

            var handler = new JwtSecurityTokenHandler();

            try
            {
                // Returns the ClaimsPrincipal if the token is valid
                return handler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey         = new SymmetricSecurityKey(
                                                  Encoding.UTF8.GetBytes(secretKey)),
                    ValidateIssuer    = false,
                    ValidateAudience  = false,
                    ValidateLifetime  = true,           // reject expired tokens
                    ClockSkew         = TimeSpan.Zero   // no grace period
                }, out _);
            }
            catch
            {
                return null; // token invalid or expired
            }
        }
    }
}
