using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using DunesOfArabia.Components;
using DunesOfArabia.Components.Account;
using DunesOfArabia.Data;
using DunesOfArabia.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// =====================================================
// DATABASE
// =====================================================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// =====================================================
// IDENTITY
// =====================================================
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;

    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<AppDbContext>();

// =====================================================
// FIX: Tell Identity to use YOUR Blazor login page
// =====================================================
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

// =====================================================
// AUTHENTICATION
// =====================================================
builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        var jwtKey = builder.Configuration["Jwt:SecretKey"]
                     ?? throw new InvalidOperationException(
                         "JWT SecretKey is not configured. Add 'Jwt:SecretKey' to appsettings.json or user secrets.");

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey))
        };
    });

// =====================================================
// AUTHORIZATION
// =====================================================
builder.Services.AddAuthorization();

// =====================================================
// BLAZOR (.NET 8)
// =====================================================
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// =====================================================
// FIX: Register Identity helper services
// MUST be before builder.Build()
// =====================================================
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<IdentityUserAccessor>();

// =====================================================
// CONTROLLERS
// =====================================================
builder.Services.AddControllers();

// =====================================================
// SWAGGER
// =====================================================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =====================================================
// NOTHING GOES ABOVE THIS LINE AFTER REGISTERING SERVICES
// =====================================================
var app = builder.Build();

// =====================================================
// MIDDLEWARE
// =====================================================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

// =====================================================
// MAP CONTROLLERS
// =====================================================
app.MapControllers();

// =====================================================
// BLAZOR APP
// =====================================================
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// =====================================================
// FIX: Map Identity endpoints
// =====================================================
app.MapAdditionalIdentityEndpoints();

app.Run();