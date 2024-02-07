using AutoMapper;
using CleanArchMvc.Domain.Entities;
using CleanArchMvcApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvcApplication.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Pessoa, PessoaDTO>().ReverseMap();
            CreateMap<Dados, DadosDTO>().ReverseMap();
        }
    }
}
