using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Infra.Ioc
{
    public static class DependencyInjectionSwagger
    {
        public static IServiceCollection JwtToken(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    BearerFormat = "JWt",
                    In= Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description= "Teste Token Json"
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                             {
                                 Type=ReferenceType.SecurityScheme,
                                    Id= "Bearer"

                             }
                            
                         },
                        new string[] {}



                    }
                    
                    
                
                });


            });
            
            


            return services;
        }




    }
}
