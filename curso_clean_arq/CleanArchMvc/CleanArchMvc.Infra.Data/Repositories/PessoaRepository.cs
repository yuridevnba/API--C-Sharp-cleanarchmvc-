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
    public class PesssoaRepository : IPessoaRepository
    {
        ApplicationDbContext _pessoaContext;

        // construtor
        public PesssoaRepository(ApplicationDbContext contex)
        {
            _pessoaContext = contex;

        }

        public async Task<Pessoa> Create(Pessoa pessoa)
        {
            _pessoaContext.Add(pessoa); // apenas na memória.
            await _pessoaContext.SaveChangesAsync(); // persiste no bd
            return pessoa;

        }

        public async Task<Pessoa> GetById(int? id)
        {
            return await _pessoaContext.Pessoas.FindAsync(id);
        }

        public async Task<IEnumerable<Pessoa>> GetPessoas()
        {
           return await _pessoaContext.Pessoas.ToListAsync();
        }



       

        public async Task<Pessoa> Remove(Pessoa category)
        {
            _pessoaContext.Remove(category); 
            await _pessoaContext.SaveChangesAsync(); 
            return category;

        }

        public async Task<Pessoa> Update(Pessoa pessoa)
        {
            _pessoaContext.Update(pessoa);
            await _pessoaContext.SaveChangesAsync();
            return pessoa;
        }
    }
}
