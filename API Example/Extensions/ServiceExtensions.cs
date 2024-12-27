using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SecuringWebApi.Data;

namespace SecuringWebApi.Extensions
{
    public static class ServiceExtensions
    {
        private const string SECURITY_SCHEME = "Bearer";

        public static void ProjectConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<ApiDbContext>();

            services.AddControllers();
            services.AddSwaggerWithAuth();
        }

        public static void AddSwaggerWithAuth(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API",
                    Version = "v1"
                });
                c.AddSecurityDefinition(SECURITY_SCHEME, new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = SECURITY_SCHEME,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer some_abc_token\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
        }
    }
}
