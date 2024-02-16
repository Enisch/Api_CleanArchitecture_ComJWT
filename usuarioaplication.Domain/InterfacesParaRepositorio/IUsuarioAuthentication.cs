using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usuarioaplication.Domain.Models;

namespace usuarioaplication.Domain.InterfacesParaRepositorio
{
    public  interface IUsuarioAuthentication
    {
        Task<bool> ChecarEmailCadastrado( string email);
        Task<bool> AuntenticarUsuario(string email, string senha);
        public string GenerateToken(int id, string email);

        public Task<UsuarioMigrationModels> GetEmail(string mail);


    }
}