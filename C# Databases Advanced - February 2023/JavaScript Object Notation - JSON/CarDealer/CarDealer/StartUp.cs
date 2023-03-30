namespace CarDealer;

using System.IO;
using AutoMapper;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Data;
using Models;
using DTOs.Import;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new CarDealerContext();

        //Import Suppliers
        //string suppliersJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
        //Console.WriteLine(ImportSuppliers(context, suppliersJson));

        //Import Parts
        //string partsJson = File.ReadAllText(@"../../../Datasets/parts.json");
        //Console.WriteLine(ImportParts(context, partsJson));

        //Import Cars
        //string carsJson = File.ReadAllText(@"../../../Datasets/cars.json");
        //Console.WriteLine(ImportCars(context, carsJson));

        //Import Customers
        //string customersJson = File.ReadAllText(@"../../../Datasets/customers.json");
        //Console.WriteLine(ImportCustomers(context, customersJson));

        //Import Sales
        //string salesJson = File.ReadAllText(@"../../../Datasets/sales.json");
        //Console.WriteLine(ImportSales(context, salesJson));

        //Export Ordered Customers
        //Console.WriteLine(GetOrderedCustomers(context));

        //Export Cars from Make Toyota
        //Console.WriteLine(GetCarsFromMakeToyota(context));

        //Export Local Suppliers
        //Console.WriteLine(GetLocalSuppliers(context));

        //Export Cars with Their List of Parts
        //Console.WriteLine(GetCarsWithTheirListOfParts(context));

        //Export Total Sales by Customer - 1/2
        //Console.WriteLine(GetTotalSalesByCustomer(context));

        //Export Sales with Applied Discount
        //Console.WriteLine(GetSalesWithAppliedDiscount(context));
    }

    private static IMapper CreateMapper()
    {
        IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));

        return mapper;
    }

    //Import Suppliers
    public static string ImportSuppliers(CarDealerContext context, string inputJson)
    {
        var mapper = CreateMapper();

        var supplierDTOs = JsonConvert.DeserializeObject<ImportSupplierDTO[]>(inputJson);
        ICollection<Supplier> validSuppliers = new HashSet<Supplier>();

        foreach (var supplierDTO in supplierDTOs!)
        {
            Supplier supplier = mapper.Map<Supplier>(supplierDTO);
            validSuppliers.Add(supplier);
        }

        context.Suppliers.BulkInsert(validSuppliers);

        return $"Successfully imported {validSuppliers.Count}.";
    }

    //Import Parts
    public static string ImportParts(CarDealerContext context, string inputJson)
    {
        var mapper = CreateMapper();

        var partDTOs = JsonConvert.DeserializeObject<ImportPartDTO[]>(inputJson);
        ICollection<Part> validParts = new HashSet<Part>();

        IEnumerable<int> dbSupplierIds = context.Suppliers
            .AsNoTracking()
            .Select(x => x.Id)
            .ToArray();

        foreach (var partDTO in partDTOs!)
        {
            Part part = mapper.Map<Part>(partDTO);

            if (dbSupplierIds.Any(id => id == part.SupplierId))
            {
                validParts.Add(part);
            }
        }

        context.Parts.AddRange(validParts);
        context.SaveChanges();

        return $"Successfully imported {validParts.Count}.";
    }

    //Import Cars
    public static string ImportCars(CarDealerContext context, string inputJson)
    {
        var mapper = CreateMapper();

        var carDTOs = JsonConvert.DeserializeObject<ImportCarDTO[]>(inputJson);
        ICollection<Car> validCars = new HashSet<Car>();

        foreach (var carDTO in carDTOs!)
        {
            Car car = mapper.Map<Car>(carDTO);

            foreach (var partId in carDTO.PartsIds.DistinctBy(p => p))
            {
                PartCar partCar = new PartCar
                {
                    PartId = partId
                };

                car.PartsCars.Add(partCar);
            }

            validCars.Add(car);
        }

        context.Cars.AddRange(validCars);
        context.SaveChanges();

        return $"Successfully imported {validCars.Count}.";
    }

    //Import Customers
    public static string ImportCustomers(CarDealerContext context, string inputJson)
    {
        var mapper = CreateMapper();

        var customerDTOs = JsonConvert.DeserializeObject<ImportCustomerDTO[]>(inputJson);
        ICollection<Customer> validCustomers = new HashSet<Customer>();

        foreach (var customerDTO in customerDTOs!)
        {
            Customer customer = mapper.Map<Customer>(customerDTO);
            validCustomers.Add(customer);
        }

        context.Customers.BulkInsert(validCustomers);

        return $"Successfully imported {validCustomers.Count}.";
    }

    //Import Sales
    public static string ImportSales(CarDealerContext context, string inputJson)
    {
        var mapper = CreateMapper();

        var saleDTOs = JsonConvert.DeserializeObject<ImportSaleDTO[]>(inputJson);
        ICollection<Sale> validSales = new HashSet<Sale>();

        foreach (var saleDTO in saleDTOs!)
        {
            Sale sale = mapper.Map<Sale>(saleDTO);
            validSales.Add(sale);
        }

        context.Sales.BulkInsert(validSales);

        return $"Successfully imported {validSales.Count}.";
    }

    //Export Ordered Customers
    public static string GetOrderedCustomers(CarDealerContext context)
    {
        var customers = context.Customers
            .OrderBy(c => c.BirthDate)
            .ThenBy(c => c.IsYoungDriver)
            .Select(c => new
            {
                c.Name,
                BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                c.IsYoungDriver
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(customers, Formatting.Indented);
    }

    //Export Cars from Make Toyota
    public static string GetCarsFromMakeToyota(CarDealerContext context)
    {
        var toyotaCars = context.Cars
            .Where(c => c.Make == "Toyota")
            .Select(c => new
            {
                c.Id,
                c.Make,
                c.Model,
                c.TraveledDistance
            })
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
    }

    //Export Local Suppliers
    public static string GetLocalSuppliers(CarDealerContext context)
    {
        var localSuppliers = context.Suppliers
            .Where(s => s.IsImporter == false)
            .Select(s => new
            {
                s.Id,
                s.Name,
                PartsCount = s.Parts.Count
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
    }

    //Export Cars with Their List of Parts
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        var carsAndParts = context.Cars
            .Select(c => new
            {
                car = new
                {
                    c.Make,
                    c.Model,
                    c.TraveledDistance
                },
                parts = c.PartsCars.Select(p => new
                {
                    p.Part.Name,
                    Price = p.Part.Price.ToString("f2")
                })
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(carsAndParts, Formatting.Indented);
    }

    //Export Total Sales by Customer - 1/2
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        var customersThatBoughtACar = context.Customers
            .Where(c => c.Sales.Count > 0)
            .ToArray()
            .Select(c => new
            {
                fullName = c.Name,
                boughtCars = c.Sales.Count,
                spentMoney = Math.Round(c.Sales.Sum(s => s.Car.PartsCars.Sum(p => p.Part.Price)), 2)
            })
            .OrderByDescending(c => c.spentMoney)
            .ThenByDescending(c => c.boughtCars)
            .ToArray();

        return JsonConvert.SerializeObject(customersThatBoughtACar, Formatting.Indented);
    }

    //Export Sales with Applied Discount
    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    {
        var firstTenSales = context.Sales
            .Take(10)
            .Select(c => new
            {
                car = new
                {
                    c.Car.Make,
                    c.Car.Model,
                    c.Car.TraveledDistance
                },
                customerName = c.Customer.Name,
                discount = c.Discount.ToString("f2"),
                price = c.Car.PartsCars.Sum(pc => pc.Part.Price).ToString("f2"),
                priceWithDiscount = (c.Car.PartsCars.Sum(pc => pc.Part.Price) - 
                (c.Discount / 100 * c.Car.PartsCars.Sum(pc => pc.Part.Price))).ToString("f2")
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(firstTenSales, Formatting.Indented);
    }
}