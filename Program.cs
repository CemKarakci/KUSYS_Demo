using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KUSYS_Demo.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<KUSYS_DemoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KUSYS_DemoContext") ?? throw new InvalidOperationException("Connection string 'KUSYS_DemoContext' not found.")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
/*
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<KUSYS_DemoContext>();
    //context.Database.EnsureCreated(); --- commented out due to enable migration history
    SeedData.Initialize(context);
}
*/
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
