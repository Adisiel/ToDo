using Application.DTOs.TarefaDTO;
using AutoMapper;
using Core.Entities;

namespace Application.Profiles
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {
            CreateMap<Tarefa, DetailsTarefaDTO>()
                .ForMember(tDTO => tDTO.Prioridade, options => options.MapFrom(t => t.Prioridade.ToString()))
                .ForMember(tDTO => tDTO.Status, options => options.MapFrom(t => t.Status.ToString()))
                .ForMember(tDTO => tDTO.DataCriacao, options => options.MapFrom(t => t.DataCriacao.Date))
                .ForMember(tDTO => tDTO.DataEntrega, options => options.MapFrom(t => t.DataEntrega.Date));

            CreateMap<DetailsTarefaDTO, Tarefa>();

            CreateMap<UpdateTarefaDTO, Tarefa>()
                .ForMember(tDTO => tDTO.DataEntrega, options => options.MapFrom(t => t.DataEntrega.Date));

            CreateMap<AddTarefaDTO, Tarefa>()
                .ForMember(tDTO => tDTO.DataEntrega, options => options.MapFrom(t => t.DataEntrega.Date));
        }
    }
}
