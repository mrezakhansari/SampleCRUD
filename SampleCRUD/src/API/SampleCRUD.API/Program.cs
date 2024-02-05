using Microsoft.EntityFrameworkCore;
using SampleCRUD.API;
using SampleCRUD.Identity;
using SampleCRUD.Identity.DbContext;
using SampleCRUD.Persistence;
using SampleCRUD.Persistence.DatabaseContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddApiServices();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<SampleCRUDDatabaseContext>();
    if (context != null)
    {
        await context.Database.MigrateAsync();
        await context.Database.EnsureCreatedAsync();
    }
    var contextIdentity = serviceScope.ServiceProvider.GetService<SampleCRUDIdentityDbContext>();
    if (contextIdentity != null)
    {
        await contextIdentity.Database.MigrateAsync();
        await contextIdentity.Database.EnsureCreatedAsync();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
