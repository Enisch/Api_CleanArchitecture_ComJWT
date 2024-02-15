using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usuarioaplication.Domain.Models;

namespace usuarioaplication.Domain.InterfacesParaRepositorio
{
    public interface IUsuario
    {

        public Task<IEnumerable<UsuarioMigrationModels>> UsuarioNomes();
         public Task<UsuarioMigrationModels> SelecionarPorId(int id);
        public Task<UsuarioMigrationModels> CadastrarUsuario(UsuarioMigrationModels usuario);
        Task<bool> SalvarNobanco();

    }
}
