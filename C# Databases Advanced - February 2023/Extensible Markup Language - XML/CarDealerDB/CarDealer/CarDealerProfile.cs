namespace CarDealer;

using AutoMapper;
using System.Globalization;

using Models;
using DTOs.Import;
using DTOs.Export;

public class CarDealerProfile : Profile
{
    public CarDealerProfile()
    {
        this.CreateMap<ImportSupplierDTO, Supplier>();
        this.CreateMap<Supplier, ExportLocalSupplierDTO>()
            .ForMember(d => d.PartsCount, opt => opt.MapFrom(s => s.Parts.Count));

        this.CreateMap<ImportPartDTO, Part>()
            .ForMember(d => d.SupplierId, opt => opt.MapFrom(s => s.SupplierId!.Value));
        this.CreateMap<Part, ExportPartCarDTO>();

        this.CreateMap<ImportCarDTO, Car>()
            .ForSourceMember(s => s.Parts, opt => opt.DoNotValidate());
        this.CreateMap<Car, ExportCarWithDistanceDTO>();
        this.CreateMap<Car, ExportBmwCarDTO>();
        this.CreateMap<Car, ExportCarWithPartsDTO>()
            .ForMember(d => d.PartsCar, opt => opt.MapFrom(s => s.PartsCars
                                                                .OrderByDescending(pc => pc.Part.Price)
                                                                .Select(pc => pc.Part)));

        this.CreateMap<ImportCustomerDTO, Customer>()
            .ForMember(d => d.BirthDate, opt => opt.MapFrom(s => DateTime.Parse(s.BirthDate, CultureInfo.InvariantCulture)));
        this.CreateMap<Customer, ExportCustomerTotalSalesDTO>()
            .ForMember(d => d.CarsBought, opt => opt.MapFrom(s => s.Sales.Count))
            .ForMember(d => d.MoneySpent, opt => opt.Ignore());

        this.CreateMap<ImportSaleDTO, Sale>()
            .ForMember(d => d.CarId, opt => opt.MapFrom(s => s.CarId!.Value));
    }
}
