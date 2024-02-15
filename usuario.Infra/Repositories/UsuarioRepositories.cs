using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usuario.Infra.Data.Context;
using usuarioaplication.Domain.InterfacesParaRepositorio;
using usuarioaplication.Domain.Models;

namespace usuario.Infra.Data.Repositories
{
    public class UsuarioRepositories:IUsuario
    {
        ContextDb context;




        public UsuarioRepositories(ContextDb context) 
        { 

            this.context = context;
        }




        public   async Task<UsuarioMigrationModels> CadastrarUsuario(UsuarioMigrationModels usuario)
        {
            var NovoUsuario = await context.AddAsync(usuario);
            await context.SaveChangesAsync();
                   return usuario;
        }



        public async Task<bool> SalvarNobanco()
        {
            return await context.SaveChangesAsync() > 0;
            //Metodo inútil atualmente.
        }




        public async Task<UsuarioMigrationModels> SelecionarPorId(int Id)
        {
            var usuarioId = await context.Usuario.Where(x => x.id == Id).FirstOrDefaultAsync();
            return usuarioId!;

        }

        public Task<IEnumerable<UsuarioMigrationModels>> UsuarioNomes()
        {
            throw new NotImplementedException();
        }
    }
}
