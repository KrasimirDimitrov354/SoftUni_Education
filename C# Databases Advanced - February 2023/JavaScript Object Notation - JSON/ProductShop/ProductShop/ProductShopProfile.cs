namespace ProductShop;

using AutoMapper;

using Models;
using DTOs.Import;
using DTOs.Export;

public class ProductShopProfile : Profile
{
    public ProductShopProfile() 
    {
        CreateMap<ImportUserDTO, User>();
        CreateMap<ImportProductDTO, Product>();
        CreateMap<ImportCategoryDTOs, Category>();
        CreateMap<ImportCategoryProductDTO, CategoryProduct>();

        //CreateMap<Product, SoldProductDTO>()
        //    .ForMember(d => d.ProductName, opt => opt.MapFrom(s => s.Name))
        //    .ForMember(d => d.ProductPrice, opt => opt.MapFrom(s => Math.Round(s.Price, 2)));

        //CreateMap<SoldProductDTO[], SoldProductsTotalDTO>()
        //    .ForMember(d => d.ProductsCount, opt => opt.MapFrom(s => s.Length))
        //    .ForMember(d => d.soldProducts, opt => opt.MapFrom(s => s));

        //CreateMap<SoldProductsTotalDTO, SellerDTO>()
        //    .ForMember(d => d.SoldProductsTotal, opt => opt.MapFrom(s => s));

        //CreateMap<User, SellerDTO>()
        //    .ForMember(d => d.SellerLastName, opt => opt.MapFrom(s => s.LastName))
        //    .ForMember(d => d.Age, opt => opt.MapFrom(s => s.Age));

        //CreateMap<SellerDTO, (SoldProductDTO, User)>()
        //    .ForMember(d => d.Item1, opt => opt.MapFrom(s => s.SoldProductsTotal))
        //    .ForMember(d => d.ite)
    }
}
