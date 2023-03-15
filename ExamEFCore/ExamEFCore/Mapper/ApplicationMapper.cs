using AutoMapper;
using ExamEFCore.DTOs.Product;
using ExamEFCore.Models;

namespace ExamEFCore;

public class ApplicationMapper : Profile
{
    public ApplicationMapper()
    {
        CreateMap<CreateProductDto, Product>()
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
        .ForMember(dest => dest.Continue, opt => opt.MapFrom(src => src.Continue))
        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
        .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
        CreateMap<UpdateProductDto, Product>()
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
        .ForMember(dest => dest.Continue, opt => opt.MapFrom(src => src.Continue))
        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
        .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
        .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated));
    }
}
