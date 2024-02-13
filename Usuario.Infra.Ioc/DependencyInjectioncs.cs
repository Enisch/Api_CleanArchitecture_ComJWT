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

namespace Usuario.Infra.Ioc
{
    public static class DependencyInjectioncs
    {


        public static IServiceCollection Infrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ContextDb>(options =>
            {
                var conexao = configuration.GetConnectionString("DefaultString");
                options.UseMySql(conexao, ServerVersion.AutoDetect(conexao),
                    x => x.MigrationsAssembly(typeof(ContextDb).Assembly.FullName));
            });

            return services;
        }

    }
}