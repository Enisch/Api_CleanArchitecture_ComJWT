using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using usuario.Infra.Data.Context;
using usuarioaplication.Domain.InterfacesParaRepositorio;
using usuarioaplication.Domain.Models;

namespace usuario.Infra.Data.Repositories
{
    public class UsuarioAuthenticationRepository : IUsuarioAuthentication
    {//Autentificação do usuario e geração de token
        private readonly ContextDb db;
        private readonly IConfiguration configuration;

        public UsuarioAuthenticationRepository(ContextDb db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
        }



        //Verifica se o Usuario existe.
        public async Task<bool> AuntenticarUsuario(string email, string senha)
        {
            var Usuario = await db.Usuario.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();

            if (Usuario != null)
            {
                return true;
            }

            //Verifica a senha do usuario
            using var Hmac = new HMACSHA512(Usuario.passwordSalt);
            var computeHash = Hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            for (int i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != Usuario.passwordHash[i])
                {
                    return false;
                }
            }

            return true;

        }

        //Checa se o Email esta cadastrado.
        public async Task<bool> ChecarEmailCadastrado(string email)
        {
            var Usuario = await db.Usuario.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();

            if (Usuario != null)
            {
                return true;
            }

            return false;
        }

        public async Task<UsuarioMigrationModels> GetEmail(string mail) 
        {
            var email = await db.Usuario.Where(x => x.Email.ToLower() == mail.ToLower()).FirstOrDefaultAsync();
            return email;
        
        
        }


        //Gera o Token JWT.
        public string GenerateToken(int id, string email)
        {
            var Claims = new[]
            {
                new Claim("id", id.ToString()),
                new Claim("email", email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));

            var Credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var Expiration = DateTime.UtcNow.AddMinutes(5);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                expires: Expiration,
                signingCredentials: Credentials,
                claims: Claims
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
