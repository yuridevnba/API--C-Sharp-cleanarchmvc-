using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace CleanArchMvc.Domain.Entities

  
{
    public sealed class Dados : Entity
    {
        public Pessoa Pessoas;

        public int PessoaId { get; set; }

        public string? Name { get; private set; }
        public string? InicialMae { get; private set; }
        public int Nascimento { get; private set; }
        public string CPF { get; private set; }
        public string? InicialPai { get; private set; }
        //public object Pessoas { get; set; }
        
        public Dados()
        {

        }

        public Dados(string? name, string? InicialMae, int Nascimento, string cpf, string? InicialPai)
        {
            ValedateDomain( name, InicialMae,  Nascimento, cpf, InicialPai);
        }

        public Dados(int id , string? name, string? InicialMae, int Nascimento, string cpf, string? InicialPai)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValedateDomain( name, InicialMae, Nascimento, cpf, InicialPai);
        }


        public void Update (string? name, string? InicialMae, int Nascimento, string cpf, string? InicialPai, int pessoaId)
        {
            ValedateDomain( name, InicialMae, Nascimento, cpf, InicialPai);
            PessoaId = pessoaId;
        }

        private void ValedateDomain(string? name, string? InicialMae, int Nascimento, string cpf, string? InicialPai)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                  "Invalid name is require.");


            DomainExceptionValidation.When(name.Length < 3,
               "Invalid name , too short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(InicialMae),
                "Invalid description. Description is required");

            DomainExceptionValidation.When(InicialMae.Length < 3,
              "Invalid description , too short, minimum 5 characters");

            //DomainExceptionValidation.When(cpf < 0,
            // "Invalid cpf value");


            DomainExceptionValidation.When(Nascimento < 0,
             "Invalid idade value");



            DomainExceptionValidation.When(InicialPai?.Length > 250,
             "Invalid image name, too long, maximum 250 characters");
            // se for null ele lança null, se não for ele faz a comparação.

            Name = name;
            this.InicialMae = InicialMae;
            this.Nascimento = Nascimento;
            CPF = cpf;
            this.InicialPai = InicialPai;

        }

    }
}


