﻿using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection; 
using Duperu.Infraestructure.Repository;
using Duperu.Application.Repository;

namespace Duperu.Infraestructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICommercialRepository, CommercialRepository>();
        }
    }
}