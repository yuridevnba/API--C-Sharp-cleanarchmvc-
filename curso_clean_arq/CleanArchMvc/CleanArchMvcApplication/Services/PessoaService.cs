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
    public class PessoaService : IPessoaService
    {


        private IPessoaRepository _pessoaRepository;// receber os metódos.

        private readonly IMapper _mapper;

        public PessoaService(IPessoaRepository pessoaRepository, IMapper mapper) // injetando
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PessoaDTO>> GetPessoa()
        {
            var pessoasEntity = await _pessoaRepository.GetPessoas();
            // lista de objetos categorias
            return _mapper.Map<IEnumerable<PessoaDTO>>(pessoasEntity);
            //pega oq recebeu e mapeia com DTO.

        }

        public async Task<PessoaDTO> GetById(int? id)
        {

            var pessoasEntity = await _pessoaRepository.GetById(id);
            return _mapper.Map<PessoaDTO>(pessoasEntity);

          
            
        }

        public async Task Add(PessoaDTO pessoaDto)
        {
           var pessoaEntity = _mapper.Map<Pessoa>(pessoaDto);
            await _pessoaRepository.Create(pessoaEntity);
            // criar a entidade
        }

        public async Task Update(PessoaDTO pessoaDto)
        {
            var pessoaEntity = _mapper.Map<Pessoa>(pessoaDto);
            await _pessoaRepository.Update(pessoaEntity);
        }

        public async Task Remove(int? id)
        {
            var  pessoaEntity = _pessoaRepository.GetById(id).Result;// se deixar sem essa linha, só iria retornar uma task d categoria, com o result devolve uma categoria.
            await _pessoaRepository.Remove(pessoaEntity);
        }

       
    }
}
