namespace CarDealer;

using AutoMapper;
using System.Globalization;

using Models;
using DTOs.Import;

public class CarDealerProfile : Profile
{
    public CarDealerProfile()
    {
        CreateMap<ImportSupplierDTO, Supplier>();

        CreateMap<ImportPartDTO, Part>()
            .ForMember(d => d.SupplierId, opt => opt.MapFrom(s => s.SupplierId!.Value));

        CreateMap<ImportCarDTO, Car>()
            .ForSourceMember(s => s.Parts, opt => opt.DoNotValidate());

        CreateMap<ImportCustomerDTO, Customer>()
            .ForMember(d => d.BirthDate, opt => opt.MapFrom(s => DateTime.Parse(s.BirthDate, CultureInfo.InvariantCulture)));

        CreateMap<ImportSaleDTO, Sale>()
            .ForMember(d => d.CarId, opt => opt.MapFrom(s => s.CarId!.Value));
    }
}
