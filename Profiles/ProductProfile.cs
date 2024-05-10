using AutoMapper;
using Models;
using Models.Dtos;

namespace Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDetail, ResponseBuyProductDto>()
        .ForMember(
            dest => dest.ProductId,
            source => source.MapFrom(s => s.ProductDetailId)
        )
        .ForMember(
            dest => dest.ProductName,
            source => source.MapFrom(s => s.ProductDetailName)
        )
        .ForMember(
            dest => dest.CurrentQuantity,
            source => source.MapFrom(s => s.Quantity)
        );

        CreateMap<ProductDetail, ResponseUpdateProductDto>()
        .ForMember(
            dest => dest.ProductId,
            source => source.MapFrom(s => s.ProductDetailId)
        )
        .ForMember(
            dest => dest.ProductName,
            source => source.MapFrom(s => s.ProductDetailName)
        );
    }
}
