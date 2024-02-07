using AutoMapper;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvcApplication.DTOs;
using CleanArchMvcApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvcApplication.Services
{
    public  class DadosService : IDadosService
    {
        private IDadosRepository _dadosRepository;

        private readonly IMapper _mapper;
        public DadosService(IMapper mapper, IDadosRepository dadosRepository)
        {
            _dadosRepository = dadosRepository ?? 
                throw new ArgumentNullException(nameof(dadosRepository));
            // se o productRepository for nulo lança uma excessão\

            _mapper = mapper;
        }

        public async Task<IEnumerable<DadosDTO>> GetdadosDto()
        {
            var dadosEntity = await _dadosRepository.GetDadossAsync();
            return _mapper.Map<IEnumerable<DadosDTO>>(dadosEntity);
        }

        public async Task<DadosDTO> GetById(int? id)
        {
            var dadosEntity = await _dadosRepository.GetByIdAsync(id);
            return _mapper.Map < DadosDTO > (dadosEntity);
        }

        public async Task<DadosDTO> GetDadosPessoas(int? id)
        {
            var dadosEntity = await _dadosRepository.GetDadosPessoaAsync(id);
            return _mapper.Map<DadosDTO>(dadosEntity);

        }

        public async Task Add(DadosDTO dadoDto)
        {
            var dadosEntity = _mapper.Map<Dados>(dadoDto);
            await _dadosRepository.CreateAsync(dadosEntity);

        }

        public async Task Update(DadosDTO dadosDto)
        {
            var dadosEntity = _mapper.Map<Dados>(dadosDto);
            await _dadosRepository.UpdateAsync(dadosEntity);
        }

        public async Task Remove(int? id)
        {
            var dadoEntity = _dadosRepository.GetByIdAsync(id).Result;
            await _dadosRepository.RemoveAsync(dadoEntity);
        }

       

       
    }
}
