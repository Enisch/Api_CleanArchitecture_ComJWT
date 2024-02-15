﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usuarioaplication.Domain.Models;
using UusarioAplication.Dto_s;

namespace UusarioAplication.IServices_interfaces
{
    public interface IServiceMapperAutomatico_Usuario
    {


        public Task<IEnumerable<DtoUsuario>> UsuarioNomes();
        public Task<DtoUsuario> SelecionarPorId(int id);
        public Task<DtoUsuario> CadastrarUsuario(DtoUsuario usuario);
        Task<bool> SalvarNobanco();
    }
}
