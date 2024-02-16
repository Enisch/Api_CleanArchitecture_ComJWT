using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using usuario.Infra.Data.Context;
using usuario.Infra.Data.Repositories;
using usuarioaplication.Domain.InterfacesParaRepositorio;
using UusarioAplication.IServices_interfaces;
using UusarioAplication.Mappings;
using UusarioAplication.Services;

namespace Usuario.Infra.Ioc
{
    public static class DependencyInjectioncs
    {

        //Conexão com o banco de dados
        public static IServiceCollection Infrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ContextDb>(options =>
            {
                var conexao = configuration.GetConnectionString("DefaultString");
                options.UseMySql(conexao, ServerVersion.AutoDetect(conexao),
                    x => x.MigrationsAssembly(typeof(ContextDb).Assembly.FullName));
            });

            //Configuração inicial JWT Token
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"])),
                    ClockSkew = TimeSpan.Zero,

                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true

                };


            });

            //Configuração do AutoMapper
            services.AddAutoMapper(typeof(EntityAutoMapperUsuario));

            //Repositories
       
            services.AddScoped<IUsuario, UsuarioRepositories>();
            services.AddScoped<IUsuarioAuthentication, UsuarioAuthenticationRepository>();

            //Services
            services.AddScoped<IServiceMapperAutomatico_Usuario, ServiceMapperAutomatico_Usuario>();

            return services;
        }

    }
}