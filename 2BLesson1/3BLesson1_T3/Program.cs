using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3BLesson1_T3
{
    //3. Реализуйте функцию вычисления числа Фибоначчи
    //Требуется реализовать рекурсивную версию и версию без рекурсии(через цикл).
    //ример чисел Фибоначчи:
    //(0) = 0,
    //F(1) = 1.
    //Для остальных чисел:
    //F(N) = F(N-2) + F(N-1).
    //То есть для F(2) будет F(2) = F(0) + F(1) = 0 + 1 = 1. 
    //F(3) будет F(3) = F(1) + F(2) = 1 + 1 = 2. 

    class Program
    {
        public class TestCase
        {
            public int X { get; set; }
            public int Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }

        public static int Fibonacci(int n)
        {
            int a = 0;
            int b = 1;
            int tmp;

            for (int i = 0; i < n; i++)
            {
                tmp = a;
                a = b;
                b += tmp;
            }

            return a;
        }

        

         static void TestFibonacci(TestCase testCase)
        {
            try
            {
                var actual = Fibonacci(testCase.X);
               

                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception ex )
            {
                if (testCase.ExpectedException != null         )
                {
                    //TODO add type exception tests;
                    Console.WriteLine(ex);
                    Console.WriteLine("VALID TEST");
                    
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                    
                }
            }
            
            }

        static void TestFibonacciRec(TestCase testCase)
        {
            try
            {
                var actual = FibonachiRek(testCase.X);


                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    //TODO add type exception tests;
                    //Console.WriteLine(ex);
                    Console.WriteLine("VALID TEST");
                    Console.WriteLine($"\n {ex}");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");

                }
            }

        }
        public static int FibonachiRek(int n)
        {
            {
                if ((n == 0) || (n == 1))
                {
                    return n;
                }
                if (n < 0)
                    throw new StackOverflowException("Число отрицательное");

                else
                {
                    return (FibonachiRek(n - 1) + FibonachiRek(n - 2));
                }
            }
        }


        static void Main(string[] args)
        {

            var testCase1 = new TestCase();
            testCase1.X = 0;
            testCase1.Expected = 0;
            testCase1.ExpectedException = null;

            var testCase2 = new TestCase();
            testCase2.X = 10;
            testCase2.Expected = 55;
            testCase2.ExpectedException = null;

            var testCase3 = new TestCase();
            testCase3.X = 20;
            testCase3.Expected = 33;
            testCase3.ExpectedException = null;

            var testCase4 = new TestCase();
            testCase4.X = -1;
            testCase4.ExpectedException = new Exception();

            TestFibonacci(testCase1);
            TestFibonacci(testCase2);
            TestFibonacci(testCase3);
            TestFibonacci(testCase4);

            Console.WriteLine();

            TestFibonacciRec(testCase1);
            TestFibonacciRec(testCase2);
            TestFibonacciRec(testCase3);
            TestFibonacciRec(testCase4);



            Console.ReadLine();

        }
    }
}
