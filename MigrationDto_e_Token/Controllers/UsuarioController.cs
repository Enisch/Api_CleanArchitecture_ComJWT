using Microsoft.AspNetCore.Mvc;
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

        public UsuarioController(IServiceMapperAutomatico_Usuario _Usuario)
        {
           
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

        [HttpPost]
        public async Task<ActionResult> CadastrarNovoUsuario(DtoUsuario usuario)
        {
            

            var NovoUSuarioDto=await this._Usuario.CadastrarUsuario(usuario);

            if (NovoUSuarioDto!=null)
                return Ok("Cadastro realizado com sucesso.");

            else return BadRequest("Erro ao cadastrar usuario.");


        }
    }
}
