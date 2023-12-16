
using Npgsql;
using System.Data;
using Duperu.Infraestructure.Repository;
using System.Collections.Concurrent;

namespace Duperu.API
{
    public static class ServiceExtension
    {

        public static void ConfigureCors(this IServiceCollection services, IConfiguration _configuration)
        {
            string[] origins = _configuration.GetValue<string>("Origins").Split(",");
         
            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyCors", builderCors =>
                        {
                            builderCors
                                .WithOrigins(origins)
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        });
            });
        }

        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration _configuration) 
        {
            services.AddScoped<IDbConnection>(x => new NpgsqlConnection(_configuration.GetConnectionString("DB_CONN_STR")));
        }
         
    }
}
