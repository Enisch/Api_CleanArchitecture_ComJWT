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
        [IgnoreDataMember]
        public int id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage= "O nome possui limite de 50 caracteres.") ]
        public string? nome { get; set; }

        
        [Required]
        [StringLength(50, ErrorMessage = "O email possui limite de 50 caracteres.")]
        public string? Email { get;  set; }
    }
}
