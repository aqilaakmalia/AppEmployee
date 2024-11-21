using AppEmployee.Components;
using AppEmployee.Data;
using AppEmployee.Repositories;
using AppEmployee.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql("Server=localhost;Database=employee_db;User=root;Password=;", 
        new MySqlServerVersion(new Version(8, 0, 23)))); 

// Konfigurasi Dependency Injection untuk Repositori
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<IWorkUnitRepository, WorkUnitRepository>();
builder.Services.AddScoped<IEmploymentStatusRepository, EmploymentStatusRepository>();

// Add EmployeeService to DI
builder.Services.AddHttpClient<EmployeeService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5211/"); // Ganti dengan URL API Anda yang benar
});

// Tambahkan layanan controller
builder.Services.AddControllers(); // Ini penting untuk mengaktifkan controller

// Tambahkan Swagger untuk dokumentasi API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee API", Version = "v1" });
    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API V1");
    c.RoutePrefix = "swagger"; // Mengatur URL Swagger UI
});

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
