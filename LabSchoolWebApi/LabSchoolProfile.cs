using AutoMapper;
using LabSchoolWebApi.DTOs;
using LabSchoolWebApi.Models;
using System.Collections.Generic;

namespace LabSchoolWebApi
{
    public class LabSchoolProfile : Profile
    {
        public LabSchoolProfile()
        {
            CreateMap<Aluno, AlunoDTO>()
            .ForMember(x => x.DataNascimento, act => act.MapFrom(act => act.DataNascimento.ToString("yyyy-MM-dd"))).ReverseMap();
            CreateMap<Aluno, AlunoRespostaDto>()
                .ForMember(x => x.DataNascimento, act => act.MapFrom(act => act.DataNascimento.ToString("yyyy-MM-dd")));
            CreateMap<AlunoDTO, AlunoRespostaDto>().ReverseMap();
            CreateMap<AlunoSituacaoDTO, AlunoRespostaDto>().ReverseMap();
            CreateMap<AlunoDTO, AlunoSituacaoDTO>().ReverseMap();
            CreateMap<Aluno, AlunoSituacaoDTO>().ReverseMap();
            CreateMap<Professor, ProfessorRespostaDTO>().ReverseMap();
            CreateMap<Pedagogo, PedagogoRespostaDTO>().ReverseMap();
            CreateMap<Pedagogo, PedagogoRespostaDTO>()
                .ForMember(x => x.DataNascimento, act => act.MapFrom(act => act.DataNascimento.ToString("yyyy-MM-dd")));
            CreateMap<Aluno, AtendimentoRequisicaoDto>().ReverseMap();
            CreateMap<Pedagogo, AtendimentoRequisicaoDto>().ReverseMap();
            CreateMap<AlunoRespostaDto, PedagogoRespostaDTO>().ReverseMap();

        }
    }
}
