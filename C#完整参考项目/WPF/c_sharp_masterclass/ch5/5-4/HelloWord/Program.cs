﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapeList = new List<Shape>();
            shapeList.Add(new Circle());
            shapeList.Add(new Rectangle());
            shapeList.Add(new Circle());
            shapeList.Add(new Trangle());

            var canvas = new Canvas();
            canvas.DrawShapes(shapeList);

            //var shape = new Shape();

            Console.Read();
        }
    }
}
