namespace CarDealer;

using AutoMapper;

using Models;
using DTOs.Import;

public class CarDealerProfile : Profile
{
    public CarDealerProfile()
    {
        CreateMap<ImportSupplierDTO, Supplier>();
        CreateMap<ImportPartDTO, Part>();
        CreateMap<ImportCarDTO, Car>();
        CreateMap<ImportCustomerDTO, Customer>();
        CreateMap<ImportSaleDTO, Sale>();
    }
}
