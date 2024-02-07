using CleanArchMvcApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvcApplication.Interfaces
{
    public  interface IDadosService
    {
        Task<IEnumerable<DadosDTO>> GetdadosDto();

        Task<DadosDTO> GetById(int? id);

        Task<DadosDTO> GetDadosPessoas(int? id); 

        Task Add(DadosDTO dadosDto);

        Task Update(DadosDTO dadosDto);

        Task Remove(int? id);
    }
}
