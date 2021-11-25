using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2B_Lesson8
{
    public class BucketSort
    {

        public static List<int> Sort(params int[] x)
        {
            List<int> sortedArray = new List<int>();

            int numOfBuckets = 10;

            //Создаем bucket`ы
            List<int>[] buckets = new List<int>[numOfBuckets];
            for (int i = 0; i < numOfBuckets; i++)
            {
                buckets[i] = new List<int>();
            }

            //Перебираем переданный массив
            // и добавляем каждое целое число в соответствующее ведро bucket
            for (int i = 0; i < x.Length; i++)
            {
                int bucket = (x[i] / numOfBuckets);
                buckets[bucket].Add(x[i]);
            }

            //Отсортируем каждый bucket  и добавляем ее в список результатов
            for (int i = 0; i < numOfBuckets; i++)
            {
                List<int> temp = InsertionSort(buckets[i]);
                sortedArray.AddRange(temp);
            }
            return sortedArray;
        }

        //1. Вставка сортировки
        public static List<int> InsertionSort(List<int> input)
        {
            for (int i = 1; i < input.Count; i++)
            {
                //2. Сохранение текущего значение в переменной
                int currentValue = input[i];
                int pointer = i - 1;

                //3. Пока мы указываем на допустимое значение в массиве...
                while (pointer >= 0)
                {
                    //4. Если текущее значение меньше
                    // чем значение, на которое мы указываем...
                    if (currentValue < input[pointer])
                    {
                        //5. Перемещаем указанное значение на одну позицию вверх,
                        // и вставляем текущее значение
                        // в указанную позицию.
                        input[pointer + 1] = input[pointer];
                        input[pointer] = currentValue;
                    }
                    else break;
                }
            }

            return input;
        }
        public class TestCase
        {
        public int [] X { get; set; }
        public List<int> Expected { get; set; }
        public Exception ExpectedException { get; set; }

        public static void TestSort(TestCase testCase)
        {
            try
            {
                    List<int> actual = Sort(testCase.X);
                     


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
                    Console.WriteLine(ex);
                    Console.WriteLine("VALID TEST");

                }
                else
                {
                    Console.WriteLine("INVALID TEST");

                }
            }

        }
    }

    class Program
        {

            static void Main(string[] args)
            {
                int[] array = new int[] { 43, 17, 87, 92, 31, 6, 96, 13, 66, 62, 4 };
               

                Console.WriteLine("Bucket Sort");

                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(array[i]);
                }
                Console.WriteLine("----------");

                List<int> sorted = Sort(array);

                foreach (var sort in sorted)
                {
                    Console.WriteLine(sort);
                }

                var testCase = new TestCase()
                {

                    X = array, 
                    Expected = sorted,
                    ExpectedException = null,
                };

                TestCase.TestSort(testCase);



                Console.ReadLine();
            }
        }
    }
}

