using Microsoft.AspNetCore.Authorization;
using WebApp_UnderTheHood.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication("MyCookieAuth")
    .AddCookie("MyCookieAuth", opt =>
    {
        opt.Cookie.Name = "MyCookieAuth";
        opt.LoginPath = "/Account/Login";
        opt.AccessDeniedPath = "/Account/AccessDenied";
        opt.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    });

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("Admin", policy =>
    {
        policy.RequireRole("Admin");

    });
    opt.AddPolicy("HRPolicy", policy =>
    {
        policy.RequireClaim("Department", "HR");

    });
    opt.AddPolicy("HRManager", policy =>
    {
        policy.RequireRole("HRManager");
        policy.Requirements.Add(new HrManagerRequirement(3));

    });
});

builder.Services.AddSingleton<IAuthorizationHandler, HrManagerProbationRequirementHandler>();

builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
