using DokumentuTvirtinimoSistema;
using DokumentuTvirtinimoSistema.Interfaces;
using DokumentuTvirtinimoSistema.Services;
using DokumentuTvirtinimoSistema.Components;
using Microsoft.EntityFrameworkCore;
using DokumentuTvirtinimoSistema.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IDepartment, DepartmentService>();
builder.Services.AddScoped<IRoles, RolesService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<DocumentReviewService>();
builder.Services.AddScoped<DocumentCorrectionService>();
builder.Services.AddScoped<WorkflowService>();
builder.Services.AddScoped<AuditService>();
builder.Services.AddScoped<RolesService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<DocumentTemplate>();
builder.Services.AddScoped<TemplateService>();
builder.Services.AddScoped<IAudit,AuditService>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
  .AddCookie(options =>
  {
      options.Cookie.Name = "auth_token";
      options.LoginPath = "/login";
      options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
      options.AccessDeniedPath = "/access-denied";
  });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

