using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usuarioaplication.Domain.Models;


namespace usuario.Infra.Data.EntitiesConfiguration
{
    internal class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioMigrationModels>
    {
        public void Configure(EntityTypeBuilder<UsuarioMigrationModels> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.nome).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
        }



    }
}
