using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace UusarioAplication.Dto_s
{
    public class DtoUsuario
    {
        
        public int id { get; set; }

        [Required(ErrorMessage ="O Nome é obrigatório.")]
        [StringLength(50, ErrorMessage= "O nome possui limite de 50 caracteres.") ]
        public string? nome { get; set; }

        
        [Required(ErrorMessage ="O E-mail é obrigatório.")]
        [StringLength(50, ErrorMessage = "O email possui limite de 50 caracteres.")]
        public string? Email { get;  set; }


        [Required(ErrorMessage ="A senha é obrigatória.")]
        [MaxLength(20,ErrorMessage = "A senha deve conter no máximo 20 caracteres.")]
        [MinLength(6,ErrorMessage =("a senha deve conter no minimo 6 caracteres"))]
        [NotMapped]
        public string? Password { get; set; }
    }
}
