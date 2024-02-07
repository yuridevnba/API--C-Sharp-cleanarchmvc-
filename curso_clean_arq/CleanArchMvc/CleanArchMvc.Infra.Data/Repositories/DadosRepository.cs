using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class DadosRepository : IDadosRepository
    {
        ApplicationDbContext _dadosContext;

        // vai precisar injetar essas instância de repositorios na classe de serviços.
        //
        public DadosRepository(ApplicationDbContext context)
        {
            _dadosContext = context; 
        }

        public async Task<Dados> CreateAsync(Dados dados)
        {
          _dadosContext.Add(dados);
            await _dadosContext.SaveChangesAsync();
            return dados;
        }

        public async Task<Dados> GetByIdAsync(int? id)
        {
            return await _dadosContext.Dados.FindAsync(id);

        }

        public async Task<Dados> GetDadosPessoaAsync(int? id) // dados e pessoa relacionada.
        {
            return await _dadosContext.Dados.Include(c => c.Pessoas)
                .SingleOrDefaultAsync(p => p.Id == id); // recurso = carregamento adiantado, eager loading
        }

        public async Task<IEnumerable<Dados>> GetDadossAsync()
        {
            return await _dadosContext.Dados.ToListAsync();
        }

        public async Task<Dados> RemoveAsync(Dados dados)
        {
            _dadosContext.Remove(dados);
            await _dadosContext.SaveChangesAsync();
            return dados;
        }

        public async Task<Dados> UpdateAsync(Dados dados)
        {
            _dadosContext.Update(dados);
            await _dadosContext.SaveChangesAsync();
            return dados;
        }

      
    }    
}