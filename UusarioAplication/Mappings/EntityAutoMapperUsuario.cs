using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usuarioaplication.Domain.Models;
using UusarioAplication.Dto_s;

namespace UusarioAplication.Mappings
{
    public class EntityAutoMapperUsuario:Profile
    {

        public EntityAutoMapperUsuario()
        {
            CreateMap<UsuarioMigrationModels,DtoUsuario>().ReverseMap();
        }
    }
}
