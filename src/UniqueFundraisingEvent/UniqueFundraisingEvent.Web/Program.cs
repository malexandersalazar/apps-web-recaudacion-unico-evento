using System.Reflection;
using UniqueFundraisingEvent.Web;
using UniqueFundraisingEvent.Web.Persistence;
using UniqueFundraisingEvent.Web.Settings;

var builder = WebApplication.CreateBuilder(args);

var metadataSettings = new MetadataSettings();
builder.Configuration.Bind(nameof(MetadataSettings), metadataSettings);
builder.Services.AddSingleton(metadataSettings);

builder.Services.AddPersistenceServices(builder.Configuration);

var mvcBuilder = builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Guests");
});

if (builder.Environment.IsDevelopment())
    mvcBuilder.AddRazorRuntimeCompilation();

builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/Identity/Account/Login");

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

await app.Services.Seed();

app.Run();