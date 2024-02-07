using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvcApplication.DTOs
{
    public class PessoaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Email is Required")] // obrigar a informa um Email.
        // Data Annotations
        [MinLength(3)]
        [MaxLength(100)]

        public string Email { get; set; }




    }
}
