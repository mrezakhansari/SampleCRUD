﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleCRUD.Persistence.DatabaseContext;

namespace SampleCRUD.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SampleCRUDDatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SampleCRUDConnectionString"));
        });
        return services;
    }
}
