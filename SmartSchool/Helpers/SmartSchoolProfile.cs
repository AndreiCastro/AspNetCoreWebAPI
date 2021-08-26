using AutoMapper;
using SmartSchool.Dto;
using SmartSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(
                dest => dest.Nome,
                opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                )
                .ForMember(
                dest => dest.Idade,
                opt => opt.MapFrom(src => src.DataNasc.CurretnAge())
                ); //Não usei reverse aqui, pois tem o ForMember, só da pra usar quando não tem. (igual Professor)

            CreateMap<AlunoDto, Aluno>();
            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();


            CreateMap<Professor, ProfessorDto>().ReverseMap();
            CreateMap<Professor, ProfessorRegistrarDto>().ReverseMap();
        }
    }
}
