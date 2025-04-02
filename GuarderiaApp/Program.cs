using GuarderiaApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddDbContext<GuarderiaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GuarderiaDb")));

// Agregar controladores y vistas
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuración de la pipeline de solicitudes HTTP
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Niños}/{action=Index}/{id?}"); 

app.Run();
