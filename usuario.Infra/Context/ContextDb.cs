using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using usuarioaplication.Domain.Models;

namespace usuario.Infra.Data.Context
{
     public class ContextDb:DbContext
    {

        //Deu erro na migration pelo fato da classe ter o nome semelhante ao namespace.Evitar isso das proximas vezes.
        public ContextDb(DbContextOptions<ContextDb> options):base(options)
        {
            
        }


        public  DbSet<UsuarioMigrationModels> Usuario { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ContextDb).Assembly);

        }


    }
}
