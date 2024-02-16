using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MigrationDto_e_Token.Models;
using usuario.Infra.Data.Context;
using usuarioaplication.Domain.InterfacesParaRepositorio;
using usuarioaplication.Domain.Models;
using UusarioAplication.Dto_s;
using UusarioAplication.IServices_interfaces;

namespace MigrationDto_e_Token.Controllers
{
    [ApiController]
    [Route("api/(Controller)")]
    public class UsuarioController : Controller
    {
       
        private readonly IServiceMapperAutomatico_Usuario _Usuario;
        private readonly IUsuarioAuthentication authentication;

        public UsuarioController(IServiceMapperAutomatico_Usuario _Usuario, IUsuarioAuthentication authentication )
        {
           this.authentication = authentication;
            this._Usuario = _Usuario;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<DtoUsuario>>> UsuarioPorId(int id)
        {
            var IdUsuario= await _Usuario.SelecionarPorId(id);

            if(IdUsuario == null)
            {
                return NotFound();
            }
            else
            return Ok(IdUsuario);
        }

        [HttpPost("Cadastro")]
        //[Authorize] cadastrar usuario com senha antes de usar [Authorize]
        public async Task<ActionResult<TokenUser>> CadastrarNovoUsuario(DtoUsuario usuario)
        {
            if (usuario == null)
               return  BadRequest("Dados invalidos.");


            var emailExistente = await authentication.ChecarEmailCadastrado(usuario.Email);

            if (emailExistente)
                return BadRequest("E-mail Já cadastrado.\nInsira outro e-mail.");



            var NovoUSuarioDto=await this._Usuario.CadastrarUsuario(usuario);

            if (NovoUSuarioDto==null)
                return BadRequest("Erro ao cadastrar usuario.");

            var token = authentication.GenerateToken(usuario.id, usuario.Email);
            return new TokenUser
            {
                Token = token
            };


        }



        [HttpPost("Login")]
        public async Task<ActionResult<TokenUser>> LoginUsuario(LoginModel login)
        {
            var Confirmacao_um = await authentication.ChecarEmailCadastrado(login.Email);

            if (!Confirmacao_um)
                return Unauthorized("Usuario inexistente.");

            var confirmacao_dois = await authentication.AuntenticarUsuario(login.Email, login.Password);
            if (!confirmacao_dois)
                return Unauthorized("Usuario ou senha incorretos.");

            var userLogin= await authentication.GetEmail(login.Email);

            var token= authentication.GenerateToken(userLogin.id,userLogin.Email);

            return new TokenUser
            {
                Token= token
            };

        }
    }
}
//CTRL+F Seleciona uma palavra para substituir na solução toda.