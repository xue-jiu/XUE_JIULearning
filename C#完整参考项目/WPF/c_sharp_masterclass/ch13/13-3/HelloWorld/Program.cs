using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\windows";
            ShowLargestFiles(path);

            Console.WriteLine("*****************");

            ShowLargestFilesWithLinq(path);

            Console.Read();
        }

        private static void ShowLargestFilesWithLinq(string path)
        {
            //var query = from file in new DirectoryInfo(path).GetFiles()
            //            orderby file.Length descending
            //            select file;

            var query = new DirectoryInfo(path).GetFiles()
                .OrderByDescending(f => f.Length)
                .Where(f => f.Name.StartsWith("b"))
                .Take(5);

            foreach (var f in query)
            {
                Console.WriteLine($"{f.Name,-20} : {f.Length,10:N}");
            }
        }

        private static void ShowLargestFiles(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());
            
            //foreach(var f in files)
            //{
            //    Console.WriteLine($"{f.Name,-20} : {f.Length,10:N}");
            //}

            for(int i=0; i<5; i++)
            {
                var f = files[i];
                Console.WriteLine($"{f.Name,-20} : {f.Length,10:N}");
            }
        }
    }

    class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
