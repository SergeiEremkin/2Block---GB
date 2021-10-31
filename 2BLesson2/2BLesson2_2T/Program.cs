using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2BLesson2_2T
{
    //2. Двоичный поиск
    //Требуется написать функцию бинарного поиска, посчитать его асимптотическую сложность и проверить работоспособность функции.

    class Program
    {
        public class TestCase
        {
            public int[] inputArray { get; set; }
            public int searchValue { get; set; }
            public int Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }


        static void BinarySearch(TestCase testCase)
        {
            try
            {
                var actual = BinarySearch(testCase.inputArray, testCase.searchValue);

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
                    Console.WriteLine("VALID TEST");
                    Console.WriteLine(ex);
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }
        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }


        static void Main(string[] args)
        {

            // Ассимпотическая сложность O(log N)


            var testCase = new TestCase();
            testCase.inputArray = new int[] { 3, 4, 5, 6, 7 };
            testCase.searchValue = 6;
            testCase.Expected = 3;
            testCase.ExpectedException = null;
            BinarySearch(testCase);
            

            var testCase1 = new TestCase();
            testCase1.inputArray = new int[] { 3, 4, 5, 6, 7 };
            testCase1.searchValue = 8;
            testCase1.Expected = -1;
            testCase1.ExpectedException = null;
            BinarySearch(testCase1);


            var testCase2 = new TestCase();
            testCase2.inputArray = new int[] { 3, 4, 5, 6, 7, 56, 67, 45,78 };
            testCase2.searchValue = 456;
            testCase2.Expected = -1;
            testCase2.ExpectedException = new Exception();
            BinarySearch(testCase2);



            Console.ReadLine();

        }
    }
}


