using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add the DbContext service with the Connection String
builder.Services.AddDbContext<WebApplication1.Data.HrmanagementContext>(options =>
   options.UseSqlServer("Data Source=DESKTOP-3C87OGA;Initial Catalog=HRmanagement;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map the default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Create}/{id?}"); // เปลี่ยนค่าเริ่มต้นเป็น Employee และ Action Create

app.Run();
