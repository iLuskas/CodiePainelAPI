using Codie.Painel.Domain.Exceptions;
using Codie.Painel.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codie.Painel.Domain.Entities
{
    public class User : AggregateRoot
    {
        public string? Nome { get; private set; }
        public string? Login { get; private set; }
        public string? Email { get; private set; }
        public string? Password { get; private set; }
        public string? RoleGate { get; private set; }
        public string? Avatar { get; private set; }
        public string? Imagem { get; private set; }

        public User(string email, string password)
        {
            Validation(email, password);
        }

        public User(int id, string email, string password)
        {
            DomainValidationException.When(id < 0, "O Id deve ser informado maior que zero.");
            Id = id;
            Validation(email, password);
        }

        public void Validation(string email, string password)
        {
            DomainValidationException.When(string.IsNullOrEmpty(email), "O email deve ser informado.");
            DomainValidationException.When(string.IsNullOrEmpty(password), "A Senha deve ser informado.");

            Email = email;
            Password = password;
        }
    }
}
