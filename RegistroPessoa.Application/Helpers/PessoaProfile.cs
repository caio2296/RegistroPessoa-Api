using AutoMapper;
using RegistroPessoa.Application.Dtos;
using RegistroPessoa.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroPessoa.Application.Helpers
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<Pessoa, PessoaDto>().ReverseMap();
        }
    }
}
