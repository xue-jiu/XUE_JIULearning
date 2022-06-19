using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = ProcessCars("fuel.csv");
            List<Manufacturer> manufacturers = ProcessManufacturers("manufacturers.csv");

            var query = (from car in cars
                         orderby car.Combined descending, car.Model descending
                         select new
                         {
                             Manufacturer = car.Manufacturer,
                             Model = car.Model,
                             Combined = car.Combined
                         })
                         .Take(10);

            foreach (var c in query)
            {
                Console.WriteLine($"{c.Manufacturer} {c.Model} {c.Combined}");
            }


            Console.Read();
        }

        private static List<Car> ProcessCars(string v)
        {
            var result = File.ReadAllLines(v)
                .Skip(1)
                .Where(l => l.Length > 1)
                .ToCar()
                //.Select(line =>
                //{
                //    var columns = line.Split(",");
                //    return new Car
                //    {
                //        Year = columns[0],
                //        Manufacturer = columns[1],
                //        Model = columns[2],
                //        Displacement = double.Parse(columns[3]),
                //        CylindersCount = int.Parse(columns[4]),
                //        City = int.Parse(columns[5]),
                //        Highway = int.Parse(columns[6]),
                //        Combined = int.Parse(columns[7])
                //    };
                //})
                ;

            return result.ToList();
        }

        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query = File.ReadAllLines(path)
                .Where(l => l.Length > 1)
                .Select(l =>
                {
                    var columns = l.Split(',');
                    return new Manufacturer
                    {
                        Name = columns[0],
                        Headquarters = columns[1],
                        Phone = columns[2]
                    };
                });
            return query.ToList();
        }
    }

    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(",");
                yield return new Car
                {
                    Year = columns[0],
                    Manufacturer = columns[1],
                    Model = columns[2],
                    Displacement = double.Parse(columns[3]),
                    CylindersCount = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7])
                };
            }
        }
    }

}
