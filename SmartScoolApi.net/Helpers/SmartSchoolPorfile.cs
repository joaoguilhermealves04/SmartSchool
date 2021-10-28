using AutoMapper;
using SmartScoolApi.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartScoolApi.net.Helpers
{
    public class SmartSchoolPorfile: Profile
    {
        public SmartSchoolPorfile()
        {
            CreateMap<Aluno, Dtos.AlunoDto>()
                .ForMember(
                dest=>dest.Nome,
                ope=>ope.MapFrom(src=>$"{src.Nome}{src.Sobrenome}"))
                .ForMember(
                dest=>dest.Idade,
                ope=>ope.MapFrom(src=>src.DataNasc.GetCurrentAge()));
                
        }
    }
}
