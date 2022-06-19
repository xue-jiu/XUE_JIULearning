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

            Console.Read();
        }

        private static List<Car> ProcessCars(string v)
        {
            var result = File.ReadAllLines(v)
                .Skip(1)
                .Where(l => l.Length > 1)
                .Select(line =>
                {
                    var columns = line.Split(",");
                    return new Car
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
                });

            return result.ToList();
        }
    }
   
}
