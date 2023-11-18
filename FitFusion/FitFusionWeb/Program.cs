using Microsoft.AspNetCore.Authentication.Cookies;
using Models.User;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(120);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
}
);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.LoginPath = new PathString("/Authentification/Login");
        options.AccessDeniedPath = new PathString("/CustomPages/AccessDenied");
        options.Events = new CookieAuthenticationEvents
        {
            OnRedirectToAccessDenied = context =>
            {
                context.Response.StatusCode = 404; 
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization(options =>
{
    Dictionary<Role, string> roleMappings = new Dictionary<Role, string>
{
    { Role.Owner, "Owner" },
    { Role.Staff, "Staff" },
    { Role.Customer, "Customer" },
};
    options.AddPolicy("OwnerAccess", policy => policy.RequireRole(roleMappings[Role.Owner]));
    options.AddPolicy("StaffAccess", policy => policy.RequireRole(roleMappings[Role.Staff]));
    options.AddPolicy("CustomerAccess", policy => policy.RequireRole(roleMappings[Role.Customer]));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

//public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//{
//    app.UseAuthentication();
//    app.UseAuthorization();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
