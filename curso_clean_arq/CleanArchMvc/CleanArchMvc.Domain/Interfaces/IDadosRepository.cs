
using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public  interface IDadosRepository
    {

        Task<IEnumerable<Dados>> GetDadossAsync(); // defini uma operação assíncrona.

        Task<Dados> GetByIdAsync(int? id);

        Task<Dados> GetDadosPessoaAsync(int? id); // dados relacionados a uma pessoa.


        Task<Dados> CreateAsync(Dados dados);

        Task<Dados> UpdateAsync(Dados dados);

        Task<Dados> RemoveAsync(Dados dados);
    }
}
// o repository vai ser colocado na camada de infra. repositorio é para encapsular as interações com o bd, por 
// de uma camada de abstração.