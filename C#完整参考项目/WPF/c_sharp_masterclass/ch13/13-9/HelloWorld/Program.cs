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
            //var query = cars
            //    .OrderByDescending(c => c.Combined)
            //    .ThenByDescending(c => c.Model);

            var query = (from car in cars
                         where car.Manufacturer == "BMW" && car.Year == "2016"
                         orderby car.Combined descending, car.Model descending
                         select new {
                             Model = car.Model,
                             Combined = car.Combined
                         })
                        //.First()
                        .FirstOrDefault()
                        ;

            //foreach (var c in query)
            //{
            Console.WriteLine($"{query.Model} {query.Combined}");
            //}

            // Any()
            var query2 = cars.All(c => c.Manufacturer == "Volkswagen");
            Console.WriteLine(query2);
            if (query2)
            {
                Console.WriteLine("有大众");
            }
            else
            {
                Console.WriteLine("没有大众");
            }

            var isCarsEmpty = cars.Any();

            // contains
            //var isReal = cars.Contains(query);

            // all
            var query3 = cars.SelectMany(c => c.Model);
            foreach(var c in query3)
            {
                Console.WriteLine(c);
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
    }

    public static class CarExtensions 
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach(var line in source)
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
