using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace _2B_Lesson3
{
    public class PointClass
    {
        public int X;
        public int Y;

        public PointClass(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public struct PointStruct
    {
        public int X;
        public int Y;
        public PointStruct(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public class Program
    {

        public class BechmarkClass
        {

            public static int Random (int min, int max)
            {
                var rnd = new Random();
                 
                return rnd.Next(min,max);
            }

            public static float PointDistanceClassFloat(PointClass pointOne, PointClass pointTwo)
            {
                float x = pointOne.X - pointTwo.X;
                float y = pointOne.Y - pointTwo.Y;
                return (float)Math.Sqrt((x * x) + (y * y));
            }

            public static float PointDistanceStructFloat(PointStruct pointOne, PointStruct pointTwo)
            {
                float x = pointOne.X - pointTwo.X;
                float y = pointOne.Y - pointTwo.Y;
                return (float)Math.Sqrt((x * x) + (y * y));
            }

            public static double PointDistanceStruchtDouble(PointStruct pointOne, PointStruct pointTwo)
            {
                double x = pointOne.X - pointTwo.X;
                double y = pointOne.Y - pointTwo.Y;
                return Math.Sqrt((x * x) + (y * y));
            }

            public static float PointDistanceStructFloatSimple(PointStruct pointOne, PointStruct pointTwo)
            {
                float x = pointOne.X - pointTwo.X;
                float y = pointOne.Y - pointTwo.Y;
                return (x * x) + (y * y);
            }
            [Benchmark]
            public void TestPointDistanceClassFloat()
            {
                var pointOne = new PointClass(Random(2, 100), Random(2, 100));
                var pointTwo = new PointClass(Random(2, 100), Random(2, 100));
                PointDistanceClassFloat(pointOne, pointTwo);
            }

            [Benchmark]
            public void TestPointDistanceStructFloat()
            {
                var pointOne = new PointStruct(Random(2, 100), Random(2, 100));
                var pointTwo = new PointStruct(Random(2, 100), Random(2, 100));
                PointDistanceStructFloat(pointOne, pointTwo);
            }

            [Benchmark]
            public void TestPointDistanceStructDouble()
            {
                var pointOne = new PointStruct(Random(2, 100), Random(2, 100));
                var pointTwo = new PointStruct(Random(2, 100), Random(2, 100));
                PointDistanceStruchtDouble(pointOne, pointTwo);
            }

            [Benchmark]
            public void TestDistanceStructFloatSimple()
            {
                var pointOne = new PointStruct(Random(2, 100), Random(2, 100));
                var pointTwo = new PointStruct(Random(2, 100), Random(2, 100));
                PointDistanceStructFloatSimple(pointOne, pointTwo);
            }
        }



        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            Console.ReadLine();
            
        }

    }
      
    
 }
    


 
