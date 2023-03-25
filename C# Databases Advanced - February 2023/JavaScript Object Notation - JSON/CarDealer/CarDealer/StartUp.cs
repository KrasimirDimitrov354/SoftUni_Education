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

        //1. Import Suppliers
        //string suppliersJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
        //Console.WriteLine(ImportSuppliers(context, suppliersJson));

        //2. Import Parts
        //string partsJson = File.ReadAllText(@"../../../Datasets/parts.json");
        //Console.WriteLine(ImportParts(context, partsJson));

        //3. Import Cars - 50/100
        //string carsJson = File.ReadAllText(@"../../../Datasets/cars.json");
        //Console.WriteLine(ImportCars(context, carsJson));

        //4. Import Customers
        //string customersJson = File.ReadAllText(@"../../../Datasets/customers.json");
        //Console.WriteLine(ImportCustomers(context, customersJson));

        //5. Import Sales
        //string salesJson = File.ReadAllText(@"../../../Datasets/sales.json");
        //Console.WriteLine(ImportSales(context, salesJson));

        //6. Export Ordered Customers
        //Console.WriteLine(GetOrderedCustomers(context));

        //7. Export Cars from Make Toyota
        //Console.WriteLine(GetCarsFromMakeToyota(context));

        //8. Export Local Suppliers
        //Console.WriteLine(GetLocalSuppliers(context));

        //9. Export Cars with Their List of Parts - TODO
        //Console.WriteLine(GetCarsWithTheirListOfParts(context));

        //10. Export Total Sales by Customer - TODO
        //Console.WriteLine(GetTotalSalesByCustomer(context));
    }

    private static IMapper CreateMapper()
    {
        IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));

        return mapper;
    }

    //1. Import Suppliers
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

    //2. Import Parts
    public static string ImportParts(CarDealerContext context, string inputJson)
    {
        var mapper = CreateMapper();

        var partDTOs = JsonConvert.DeserializeObject<ImportPartDTO[]>(inputJson);
        ICollection<Part> validParts = new HashSet<Part>();

        foreach (var partDTO in partDTOs!)
        {
            Part part = mapper.Map<Part>(partDTO);

            if (context.Suppliers.Any(s => s.Id == part.SupplierId))
            {
                validParts.Add(part);
            }
        }

        context.Parts.BulkInsert(validParts);

        return $"Successfully imported {validParts.Count}.";
    }

    //3. Import Cars - 50/100
    public static string ImportCars(CarDealerContext context, string inputJson)
    {
        var mapper = CreateMapper();

        var carDTOs = JsonConvert.DeserializeObject<ImportCarDTO[]>(inputJson);
        ICollection<Car> validCars = new HashSet<Car>();

        foreach (var carDTO in carDTOs!)
        {
            Car car = mapper.Map<Car>(carDTO);
            validCars.Add(car);
        }

        context.Cars.BulkInsert(validCars);

        //int dtoCounter = 0;
        //ICollection<PartCar> partsCars = new HashSet<PartCar>();
        //foreach (Car car in context.Cars)
        //{
        //    int currentCarId = car.Id;
        //    var currentCarDTO = carDTOs[dtoCounter];

        //    for (int i = 0; i < currentCarDTO.PartsIds.Length; i++)
        //    {
        //        int partId = currentCarDTO.PartsIds[i];
        //        partsCars.Add(new PartCar
        //        {
        //            CarId = partId,
        //            Car = car,
        //            PartId = partId,
        //            Part = context.Parts
        //                   .Where(p => p.Id == partId)
        //                   .First()
        //        });
        //    }

        //    dtoCounter++;
        //}

        //context.PartsCars.BulkInsert(partsCars);

        return $"Successfully imported {validCars.Count}.";
    }

    //4. Import Customers
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

    //5. Import Sales
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

        foreach (var sale in context.Sales)
        {
            if (sale.Customer.IsYoungDriver)
            {
                sale.Discount += 5;
            }
        }

        context.SaveChanges();

        return $"Successfully imported {validSales.Count}.";
    }

    //6. Export Ordered Customers
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

    //7. Export Cars from Make Toyota
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

    //8. Export Local Suppliers
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

    //9. Export Cars with Their List of Parts - TODO
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        //Get all cars along with their list of parts.
        //For the car get the make, model and traveled distance.
        //For the parts get the name and price, formatted to 2nd digit after the decimal point.
        //
        //Example:
        //"car": {
        //  "Make": "Opel",
        //  "Model": "Omega",
        //  "TraveledDistance": 176664996
        //},
        //"parts": [
        //  {
        //    "Name": "Rear Right Side Inner door handle",
        //    "Price": "79.99"
        //  },
        //  {
        //    "Name": "Door water-shield",
        //    "Price": "123.99"


        throw new NotImplementedException();
    }

    //10. Export Total Sales by Customer
    //public static string GetTotalSalesByCustomer(CarDealerContext context)
    //{
    //    var customersThatBoughtACar = context.Customers
    //        .Where(c => c.Sales.Count != 0)
    //        .Select(c => new
    //        {
    //            fullName = c.Name,
    //            boughtCars = c.Sales.Count,
    //            spentMoney = c.Sales.Sum(s => s.)
    //        })
    //}
}