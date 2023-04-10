using Microsoft.EntityFrameworkCore;
using StaffManagment.DataAccess;
using StaffManagment.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddScoped<IStaffRepository, SqlServerStaffRepository>();
builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StaffDb")));

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
    app.UseStatusCodePagesWithReExecute("/Error");
}

app.UseHttpsRedirection();
/*app.UseDefaultFiles();
app.UseStaticFiles();*/

app.UseFileServer();
app.UseMvcWithDefaultRoute();
//app.UseMvc(/*builder =>
//{
//    builder.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
//});

/*app.UseRouting();*/

//app.UseAuthorization();

//app.MapRazorPages();


/*app.UseEndpoints(async endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        throw new Exception();
        await context.Response.WriteAsync(builder.Configuration["Javobi"]);
    });
});
*/
app.Run();