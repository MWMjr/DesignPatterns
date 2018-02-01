﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWM.DesignPatterns.Adapter
{
    public class Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line(Point start, Point end)
        {
            if(start == null)
            {
                throw new ArgumentNullException(paramName: nameof(start));
            }

            if(end == null)
            {
                throw new ArgumentNullException(paramName: nameof(end));
            }

            Start = start;
            End = end;
        }
    }

    public class VectorObject: Collection<Line>
    {

    }

    public class VectorRectangle: VectorObject
    {
        public VectorRectangle(int x, int y, int width, int height)
        {
            Add(new Line(new Point(x, y), new Point(x + width, y)));
            Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
            Add(new Line(new Point(x, y), new Point(x, y + height)));
            Add(new Line(new Point(x, y + height), new Point(x + width, y + height)));
        }

    }


// Problem at this point (beofre the adapater class is written I have a program that only draws points
// Someone wants to draw rectanlges, which I cannot do the way things current stand, I need an adapter

 // So we will build an adapter that can convert a line into a set of points

// One problem with adapater is that it creates a lot of temporary information
    public class LineToPointAdapter : Collection<Point>
    {
        private static int count;

        public LineToPointAdapter(Line line)
        {
            System.Console.WriteLine($"{++count}: Generating points for line [{line.Start.X}, {line.Start.Y}]-[{line.End.X}, {line.End.Y}]");

            int left = Math.Min(line.Start.X, line.End.X);
            int right = Math.Max(line.Start.X, line.End.X);
            int top = Math.Min(line.Start.Y, line.End.Y);
            int bottom = Math.Max(line.Start.Y, line.End.Y);
            int dx = right - left;
            int dy = line.End.Y - line.Start.Y;

            if(dx == 0)
            {
                for  (int y = top; y <= bottom; ++y)
                {
                    Add(new Point(left, y));
                }
            }
            else if(dy == 0)
            {
                for(int x = left; x <= right; ++x)
                {
                    Add(new Point(x, top));
                }
            }

        }
    }



    public class Demo
    {
        private static readonly List<VectorObject> vectorObjects = new List<VectorObject>
        {
            new VectorRectangle(1,1,10,10),
            new VectorRectangle(3,3,6,6)
        };

        public static void DrawPoint(Point p)
        {
            System.Console.WriteLine(".");
        }

        static void MainBuilder(string[] args)
        {
            foreach(var vo in vectorObjects)
            {
                foreach(var line in vo)
                {
                    var adapter = new LineToPointAdapter(line);
                    foreach (var pt in adapter)
                    {
                        DrawPoint(pt);
                    }
                }
            }
        }
    }
}
