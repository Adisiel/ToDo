using Application.DTOs;
using Application.DTOs.CategoriaDTO;
using AutoMapper;
using Core.Entities;

namespace Application.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, DetailsCategoriaDTO>();
            CreateMap<DetailsCategoriaDTO, Categoria>();
            CreateMap<UpdateCategoriaDTO, Categoria>();
            CreateMap<AddCategoriaDTO, Categoria>();
        }
    }
}
