using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IPessoaRepository
    {

        // obter todas as pessoas
       Task<IEnumerable<Pessoa>> GetPessoas(); // defini uma operação assíncrona.

        Task<Pessoa> GetById(int? id);


        Task<Pessoa> Create(Pessoa pessoa);

        Task<Pessoa> Update(Pessoa pessoa);

        Task<Pessoa> Remove(Pessoa pessoa);

    }
}
// sendo possível acessar os dados do repositório usando a injeção de dependência e a inversão de controle.