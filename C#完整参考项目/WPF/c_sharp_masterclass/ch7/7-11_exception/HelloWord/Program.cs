﻿using System;
using System.IO;

namespace HelloWord
{
    public class Calculator
    {
        public int Divde(int numerator, int denomenator)
        {
            return numerator / denomenator;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            StreamReader streamReader = null;

            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fullName = Path.Combine(desktopPath, "123.txt");
                streamReader = new StreamReader(fullName);
                var connect = streamReader.ReadToEnd();

                // 操作文件

                // 人为抛出异常
                throw new Exception("Oops");

                // 关闭文件，回收垃圾
                streamReader.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("系统异常");
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Dispose();
                    Console.WriteLine("文件回收");
                }
            }

            Console.Read();
        }
    }
}
