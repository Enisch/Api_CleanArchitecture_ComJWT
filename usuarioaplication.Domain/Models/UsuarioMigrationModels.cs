using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usuarioaplication.Domain.DomainValidationException;

namespace usuarioaplication.Domain.Models
{
     public class UsuarioMigrationModels
    {
        public int id { get; private set; }
        public string? nome { get; private set; }
        public string? Email { get; private set; }

       public byte[]? passwordHash { get; private set; }

        public byte[]? passwordSalt { get; private set; }


        

        public UsuarioMigrationModels(int id, string nome, string email)
          {
            ValidationException.When(id <0, "O id não pode ser menor que 0.");
            this.id = id;
            Validation(nome, email);
        }



          public UsuarioMigrationModels(string nome, string email)
          {
           
            Validation(nome, email);
          }


         public void alterarSenha(byte[] passwordHash, byte[] passwordSalt)
          {
              this.passwordHash = passwordHash;
              this.passwordSalt = passwordSalt;
          }


        public void Validation(string nome,string email)
        {

            ValidationException.When(nome.Length > 50, "O nome não pode possuir mais de 50 caracteres.");
            ValidationException.When(nome.Length == 0, "O nome deve conter ao menos um caractere.");
            ValidationException.When(email.Length == 0,"O email deve conter ao menos um caractere.");
            ValidationException.When(email.Length > 50,"O email não deve possuir mais de 50 caracteres.");

            this.nome = nome;
            this.Email = email;
        }
    }
}
