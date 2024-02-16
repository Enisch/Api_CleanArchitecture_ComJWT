using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using usuarioaplication.Domain.InterfacesParaRepositorio;
using usuarioaplication.Domain.Models;
using UusarioAplication.Dto_s;
using UusarioAplication.IServices_interfaces;

namespace UusarioAplication.Services
{
    public class ServiceMapperAutomatico_Usuario : IServiceMapperAutomatico_Usuario
    {

        private readonly IUsuario _usuario;
        private readonly IMapper mapper;

        public ServiceMapperAutomatico_Usuario(IUsuario _usuario, IMapper mapper)
        {
            this._usuario = _usuario;
            this.mapper = mapper;
        }

        
       



        public async Task<DtoUsuario> CadastrarUsuario(DtoUsuario usuario)
        {
            var NovoUsuario= mapper.Map<UsuarioMigrationModels>(usuario); 

            if(usuario.Password != null)
            {
                using var hmca= new HMACSHA512();
                byte[] PasswordHAsh = hmca.ComputeHash(Encoding.UTF8.GetBytes(usuario.Password));
                byte[] PasswordSalt = hmca.Key;

                NovoUsuario.alterarSenha(PasswordHAsh, PasswordSalt);

            }
            

            var USuarioCriado= await _usuario.CadastrarUsuario(NovoUsuario);
            return mapper.Map<DtoUsuario>(USuarioCriado);
        }

        public async Task<bool> SalvarNobanco()
        {
            return await _usuario.SalvarNobanco();
        }

        public async Task<DtoUsuario> SelecionarPorId(int id)
        {
           
                var Usuario = await _usuario.SelecionarPorId(id);
            return mapper.Map<DtoUsuario>(Usuario);
        }

        public Task<IEnumerable<DtoUsuario>> UsuarioNomes()
        {
            throw new NotImplementedException();
        }
    }
}
