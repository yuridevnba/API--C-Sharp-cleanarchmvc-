using CleanArchMvcApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvcApplication.Interfaces
{
    public interface IPessoaService
    {

        Task<IEnumerable<PessoaDTO>> GetPessoa(); // lista de categoriasDTO

        Task<PessoaDTO> GetById(int? id);

        Task Add(PessoaDTO pessoaDto);

        Task Update (PessoaDTO pessoaDto);

        Task Remove(int? id);

    }
}
