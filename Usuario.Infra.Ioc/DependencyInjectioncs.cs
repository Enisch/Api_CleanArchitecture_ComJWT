using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            services.AddAutoMapper(typeof(EntityAutoMapperUsuario));

            //Repositories
       
            services.AddScoped<IUsuario, UsuarioRepositories>();

            //Services
            services.AddScoped<IServiceMapperAutomatico_Usuario, ServiceMapperAutomatico_Usuario>();

            return services;
        }

    }
}