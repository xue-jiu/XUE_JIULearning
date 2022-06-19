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

            //var query = (from car in cars
            //             join manufacturer in manufacturers on car.Manufacturer equals manufacturer.Name
            //             orderby car.Combined descending, car.Model descending
            //             select new
            //             {
            //                 Manufacturer = car.Manufacturer,
            //                 Model = car.Model,
            //                 Combined = car.Combined,
            //                 Headquarters = manufacturer.Headquarters,
            //                 Phone = manufacturer.Phone
            //             })
            //             .Take(10);

            //var query2 = cars.Join(manufacturers, (c) => c.Manufacturer, (m) => m.Name, (c, m) => new
            //{
            //    Car = c,
            //    Manufacturer = m
            //}).OrderByDescending(joinData => joinData.Car.Combined)
            //.ThenBy(joinData => joinData.Car.Model)
            //.Select(joinData => new
            //{
            //    Manufacturer = joinData.Car.Manufacturer,
            //    Model = joinData.Car.Model,
            //    Combined = joinData.Car.Combined,
            //    Headquarters = joinData.Manufacturer.Headquarters,
            //    Phone = joinData.Manufacturer.Phone
            //}).Take(10);

            //foreach (var c in query2)
            //{
            //    Console.WriteLine($"{c.Manufacturer} {c.Model} {c.Combined} {c.Headquarters} {c.Phone}");
            //}


            //var query = from car in cars
            //            join 
            //            group car by car.Manufacturer into manufacturerGroup
            //            orderby manufacturerGroup.Key descending
            //            select manufacturerGroup;

            //var query2 = cars.GroupBy(c => c.Manufacturer).OrderByDescending(g => g.Key);

            //var query = from manufacturer in manufacturers
            //            join car in cars on manufacturer.Name equals car.Manufacturer into carGroup
            //            orderby manufacturer.Name descending
            //            select new
            //            {
            //                Manufacturer = manufacturer,
            //                Cars = carGroup
            //            };

            //var query2 = manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer, (m, carGroup) => new
            //{
            //    Manufacturer = m,
            //    Cars = carGroup
            //}).OrderByDescending(m => m.Manufacturer.Name);

            var query = from car in cars
                        group car by car.Manufacturer into carGroup
                        select new
                        {
                            Manufacturer = carGroup.Key,
                            Avg = carGroup.Average(c => c.Combined),
                            Max = carGroup.Max(c => c.Combined),
                            Min = carGroup.Min(c => c.Combined)
                        } into tempGroup
                        orderby tempGroup.Avg descending
                        select tempGroup;

            foreach (var group in query)
            {
                Console.WriteLine($"{group.Manufacturer} 油耗情况 ");
                Console.WriteLine($"\t 最高： {group.Max}");
                Console.WriteLine($"\t 最低： {group.Min}");
                Console.WriteLine($"\t 平均： {group.Avg}");
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
