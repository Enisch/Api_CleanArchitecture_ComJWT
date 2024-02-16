using System.ComponentModel.DataAnnotations;

namespace MigrationDto_e_Token.Models
{
    //Classe que será utilizada no [HttpPost("Login")]
    public class LoginModel
    {


        [Required(ErrorMessage ="O E-mail não pode ser nulo.")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage ="A senha não pode ser nula.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }


    }
}
