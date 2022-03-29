using Application.DTOs.TarefaDTO;
using AutoMapper;
using Core.Entities;

namespace Application.Profiles
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {
            CreateMap<Tarefa, DetailsTarefaDTO>();
            CreateMap<DetailsTarefaDTO, Tarefa>();
            CreateMap<UpdateTarefaDTO, Tarefa>();
            CreateMap<AddTarefaDTO, Tarefa>();
        }
    }
}
