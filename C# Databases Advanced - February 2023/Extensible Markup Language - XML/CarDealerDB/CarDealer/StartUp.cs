namespace CarDealer;

using System.IO;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

using Data;
using Models;
using Utilities;
using DTOs.Import;
using DTOs.Export;

public class StartUp
{
    public static void Main()
    {
        using CarDealerContext context = new CarDealerContext();

        //Import Suppliers
        //string suppliersXml = File.ReadAllText(@"../../../Datasets/suppliers.xml");
        //Console.WriteLine(ImportSuppliers(context, suppliersXml));

        //Import Parts
        //string partsXml = File.ReadAllText(@"../../../Datasets/parts.xml");
        //Console.WriteLine(ImportParts(context, partsXml));

        //Import Cars
        //string carsXml = File.ReadAllText(@"../../../Datasets/cars.xml");
        //Console.WriteLine(ImportCars(context, carsXml));

        //Import Customers
        //string customersXml = File.ReadAllText(@"../../../Datasets/customers.xml");
        //Console.WriteLine(ImportCustomers(context, customersXml));

        //Import Sales
        //string salesXml = File.ReadAllText(@"../../../Datasets/sales.xml");
        //Console.WriteLine(ImportSales(context, salesXml));

        //Export Cars With Distance
        //Console.WriteLine(GetCarsWithDistance(context));

        //Export Cars from Make BMW
        //Console.WriteLine(GetCarsFromMakeBmw(context));

        //Export Local Suppliers
        //Console.WriteLine(GetLocalSuppliers(context));

        //Export Cars with Their List of Parts
        //Console.WriteLine(GetCarsWithTheirListOfParts(context));

        //Export Total Sales by Customer
        //Console.WriteLine(GetTotalSalesByCustomer(context));
    }

    //Import Suppliers
    public static string ImportSuppliers(CarDealerContext context, string inputXml)
    {
        var autoMapperHelper = new AutoMapperHelper();
        var xmlHelper = new XmlHelper();

        var supplierDTOs = xmlHelper.Deserialize<ImportSupplierDTO[]>(inputXml, "Suppliers");
        ICollection<Supplier> validSuppliers = new HashSet<Supplier>();

        foreach (var supplierDTO in supplierDTOs)
        {
            if (String.IsNullOrEmpty(supplierDTO.Name) == false)
            {
                Supplier supplier = autoMapperHelper.Initialize().Map<Supplier>(supplierDTO);
                validSuppliers.Add(supplier);
            }  
        }

        context.Suppliers.AddRange(validSuppliers);
        context.SaveChanges();

        return $"Successfully imported {validSuppliers.Count}";
    }

    //Import Parts
    public static string ImportParts(CarDealerContext context, string inputXml)
    {
        var autoMapperHelper = new AutoMapperHelper();
        var xmlHelper = new XmlHelper();

        var partDTOs = xmlHelper.Deserialize<ImportPartDTO[]>(inputXml, "Parts");
        ICollection<Part> validParts = new HashSet<Part>();

        IEnumerable<int> dbSuppliersIds = context.Suppliers
            .AsNoTracking()
            .Select(x => x.Id)
            .ToArray();

        foreach (var partDTO in partDTOs)
        {
            if (String.IsNullOrEmpty(partDTO.Name) == false)
            {
                if (partDTO.SupplierId.HasValue && dbSuppliersIds.Any(id => id == partDTO.SupplierId))
                {
                    Part part = autoMapperHelper.Initialize().Map<Part>(partDTO);
                    validParts.Add(part);
                }
            }
        }

        context.Parts.AddRange(validParts);
        context.SaveChanges();

        return $"Successfully imported {validParts.Count}";
    }

    //Import Cars
    public static string ImportCars(CarDealerContext context, string inputXml)
    {
        var autoMapperHelper = new AutoMapperHelper();
        var xmlHelper = new XmlHelper();

        var carDTOs = xmlHelper.Deserialize<ImportCarDTO[]>(inputXml, "Cars");
        ICollection<Car> validCars = new HashSet<Car>();

        IEnumerable<int> dbPartsIds = context.Parts
            .AsNoTracking()
            .Select(p => p.Id)
            .ToArray();

        foreach (var carDTO in carDTOs)
        {
            if (String.IsNullOrEmpty(carDTO.Make) == false && String.IsNullOrEmpty(carDTO.Model) == false)
            {
                Car car = autoMapperHelper.Initialize().Map<Car>(carDTO);

                foreach (var partCarDTO in carDTO.Parts.DistinctBy(p => p.PartId))
                {
                    if (dbPartsIds.Any(id => id == partCarDTO.PartId))
                    {
                        PartCar partCar = new PartCar
                        {
                            PartId = partCarDTO.PartId,
                        };
                        car.PartsCars.Add(partCar);
                    }
                }

                validCars.Add(car);
            }   
        }

        context.Cars.AddRange(validCars);
        context.SaveChanges();

        return $"Successfully imported {validCars.Count}";
    }

    //Import Customers
    public static string ImportCustomers(CarDealerContext context, string inputXml)
    {
        var autoMapperHelper = new AutoMapperHelper();
        var xmlHelper = new XmlHelper();

        var customerDTOs = xmlHelper.Deserialize<ImportCustomerDTO[]>(inputXml, "Customers");
        ICollection<Customer> validCustomers = new HashSet<Customer>();

        foreach (var customerDTO in customerDTOs)
        {
            if (String.IsNullOrEmpty(customerDTO.Name) == false && 
                String.IsNullOrEmpty(customerDTO.BirthDate) == false)
            {
                Customer customer = autoMapperHelper.Initialize().Map<Customer>(customerDTO);
                validCustomers.Add(customer);
            }
        }

        context.Customers.AddRange(validCustomers);
        context.SaveChanges();

        return $"Successfully imported {validCustomers.Count}";
    }

    //Import Sales
    public static string ImportSales(CarDealerContext context, string inputXml)
    {
        var autoMapperHelper = new AutoMapperHelper();
        var xmlHelper = new XmlHelper();

        var saleDTOs = xmlHelper.Deserialize<ImportSaleDTO[]>(inputXml, "Sales");
        ICollection<Sale> validSales = new HashSet<Sale>();

        IEnumerable<int> dbCarIds = context.Cars
            .AsNoTracking()
            .Select(c => c.Id)
            .ToArray();

        IEnumerable<int> dbCustomers = context.Customers
            .AsNoTracking()
            .Select(c => c.Id)
            .ToArray();

        foreach (var saleDTO in saleDTOs)
        {
            if (saleDTO.CarId.HasValue && dbCarIds.Any(id => id == saleDTO.CarId))
            {
                Sale sale = autoMapperHelper.Initialize().Map<Sale>(saleDTO);

                //if (dbCustomers.Where(c => c.Id == saleDTO.CustomerId).First().IsYoungDriver)
                //{
                //    sale.Discount += 5;
                //}

                validSales.Add(sale);
            }
        }

        context.Sales.AddRange(validSales);
        context.SaveChanges();

        return $"Successfully imported {validSales.Count}";
    }

    //Export Cars With Distance
    public static string GetCarsWithDistance(CarDealerContext context)
    {
        var autoMapperHelper = new AutoMapperHelper();
        var xmlHelper = new XmlHelper();

        var carsOverTwoMillionDistance = context.Cars
            .Where(c => c.TraveledDistance > 2000000)
            .OrderBy(c => c.Make)
            .ThenBy(c => c.Model)
            .Take(10)
            .ProjectTo<ExportCarWithDistanceDTO>(autoMapperHelper.Initialize().ConfigurationProvider)
            .AsNoTracking()
            .ToArray();

        return xmlHelper.Serialize(carsOverTwoMillionDistance, "cars");
    }

    //Export Cars from Make BMW
    public static string GetCarsFromMakeBmw(CarDealerContext context)
    {
        var autoMapperHelper = new AutoMapperHelper();
        var xmlHelper = new XmlHelper();

        var bmwCars = context.Cars
            .Where(c => c.Make == "BMW")
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .ProjectTo<ExportBmwCarDTO>(autoMapperHelper.Initialize().ConfigurationProvider)
            .AsNoTracking()
            .ToArray();

        return xmlHelper.Serialize(bmwCars, "cars");
    }

    //Export Local Suppliers
    public static string GetLocalSuppliers(CarDealerContext context)
    {
        var autoMapperHelper = new AutoMapperHelper();
        var xmlHelper = new XmlHelper();

        var localSuppliers = context.Suppliers
            .Where(s => !s.IsImporter)
            .ProjectTo<ExportLocalSupplierDTO>(autoMapperHelper.Initialize().ConfigurationProvider)
            .AsNoTracking()
            .ToArray();

        return xmlHelper.Serialize(localSuppliers, "suppliers");
    }

    //Export Cars with Their List of Parts
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        var autoMapperHelper = new AutoMapperHelper();
        var xmlHelper = new XmlHelper();

        var carsWithParts = context.Cars
            .OrderByDescending(c => c.TraveledDistance)
            .ThenBy(c => c.Model)
            .Take(5)
            .ProjectTo<ExportCarWithPartsDTO>(autoMapperHelper.Initialize().ConfigurationProvider)
            .AsNoTracking()
            .ToArray();

        return xmlHelper.Serialize(carsWithParts, "cars");
    }

    //Export Total Sales by Customer
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        var autoMapperHelper = new AutoMapperHelper();
        var xmlHelper = new XmlHelper();

        var customersThatHaveBoughtCar = context.Customers
            .Where(c => c.Sales.Count > 0)
            .ProjectTo<ExportCustomerTotalSalesDTO>(autoMapperHelper.Initialize().ConfigurationProvider)
            .AsNoTracking()
            .ToArray();

        foreach (var cDTO in customersThatHaveBoughtCar)
        {
            cDTO.MoneySpent = (Math.Truncate(context.Customers
                .ToArray()
                .Where(c => c.Name == cDTO.Name)
                .Sum(c => c.Sales.Sum(s => s.CalculateSaleSum()) * 100.0m)) / 100.0m)
                .ToString();
        }

        return xmlHelper
                .Serialize(customersThatHaveBoughtCar
                            .OrderByDescending(c => decimal.Parse(c.MoneySpent))
                            .ToArray(), "customers");
    }
}
