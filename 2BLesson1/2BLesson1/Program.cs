using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2BLesson1
{
    // 1.Требуется реализовать на C# функцию согласно блок-схеме. Блок-схема описывает алгоритм проверки, простое число или нет.
    //Написать консольное приложение.
    //Алгоритм реализовать отдельно в функции согласно блок - схеме.
    //Написать проверочный код в main функции .
    //Код выложить на GitHub.
    class Program
    {
        public class TestCase
        {
            public int N { get; set; }
            public bool Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }



        public static void SimpleNumber (int n)
        {
            int d = 0;
            int i = 2;
            
            while (i < n)
            {
                if (n % i == 0)
                {
                    d++;
                    i++;
                }
                else
                {
                    i++;
                }
            }
            
            if (d == 0)
            {
                
                Console.WriteLine("Простое");
            } 
            else
            {
                
                Console.WriteLine("Не простое");
            }
        }
        static void TestSimple(TestCase testCase)
        {
            try
            {

                SimpleNumber(testCase.N);
                
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    //TODO add type exception tests;
                    Console.WriteLine("VALID TEST");
                    Console.WriteLine(ex);
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }


        static void Main(string[] args)
        {

          

            var testCase1 = new TestCase();
            testCase1.N = 200;
            testCase1.ExpectedException = new Exception();

            var testCase2 = new TestCase();
            testCase2.N = 3;
            testCase2.ExpectedException = new Exception();

            var testCase3 = new TestCase();
            testCase3.N = -2345678;
            testCase3.ExpectedException = new Exception();


            TestSimple(testCase1);
            TestSimple(testCase2);
            TestSimple(testCase3);

            Console.ReadLine();


        }
    }
}
