using Microsoft.EntityFrameworkCore;
using WildlifeProject.Repository;
using WildlifeProject.Services.AdminUserServices;
using WildlifeProject.Services.AnimalDescription;
using WildlifeProject.Services.Catalouge;
using WildlifeProject.Services.CommentService;
using WildlifeProject.Services.Home;
using WildlifeProject.Services.Login;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<AdminContext>(options => options.UseSqlite($"Data Source=Collection.db"));
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IServiceHome, ServiceHome>();
builder.Services.AddTransient<IAdminUserService, AdminUserService>();
builder.Services.AddTransient<IAnimalDescriptionService, AnimalDescriptionService>();
builder.Services.AddTransient<ICatalougeService, CatalougeService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddSingleton<ILoginService, LoginService>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AdminContext>();
}
app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Home", "{controller=Home}/{action=Index}");
});


app.Run();



