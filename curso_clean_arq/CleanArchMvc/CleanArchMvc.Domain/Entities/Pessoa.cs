using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Pessoa : Entity
    {

   
        public string? Email { get; private set; }

        public Pessoa(string email)
        {
            // Name = name ?? throw new ArgumentException("name is invalid");\\ se for nulo.

            ValidateDomain(email);
        }
        public Pessoa(int id, string email)
        {

            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(email);
        }

        public void Update(string email)
        {
            ValidateDomain(email);
        }





        public ICollection<Dados>? Dados { get;  set; }
        //public object Name { get; set; }

        private void ValidateDomain(string? email)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(email),
                "Invalid name is require.");

            DomainExceptionValidation.When(email.Length<3,
               "Invalid name, too short, minimum 3 charecters");
            Email = email;
        }

    }
}
