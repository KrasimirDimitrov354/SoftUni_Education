namespace CarDealer;

using System.IO;
using Microsoft.EntityFrameworkCore;

using Data;
using Models;
using Utilities;
using DTOs.Import;

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
}