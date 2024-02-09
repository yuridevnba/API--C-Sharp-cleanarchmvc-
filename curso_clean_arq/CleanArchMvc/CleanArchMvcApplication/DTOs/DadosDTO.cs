using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvcApplication.DTOs
{
    public class DadosDTO
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The InicialMae is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("InicialMae")]
        public string? InicialMae { get; set; }

        [Required(ErrorMessage = "The CPF is Required")]
        //[Column(TypeName = "decimal(18,2)")]
        //[DisplayFormat(DataFormatString = "{0:C2}")]
        //[DataType(DataType.Currency)]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "The Idade is Required")]
        [Range(1, 2024 )] // valor mínimo e máximo
        [DisplayName("Nascimento")]
        public int Nascimento { get; set; }

        [MaxLength(50)]
        [DisplayName("InicialPai")]
        public string? InicialPai { get; set; }

        public Pessoa? pessoa { get; set; }

        [DisplayName("Pessoa")]
        public int PessoaId { get; set; }
    }
}
//string name, string municipio, decimal idade, int cep, string image