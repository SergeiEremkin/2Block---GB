using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2B_Lessob8_2
{


    class Program
    {

        public class ExternalSort
        {
            public static int[] ReadFromFile(string path)
            {
                try
                {
                    string fileContent = File.ReadAllText(path);
                    string[] intStr = fileContent.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    int[] array = new int[intStr.Length];
                    for (int i = 0; i < intStr.Length; i++)
                    {
                        array[i] = int.Parse(intStr[i]);
                    }
                    return array;
                }
                catch
                {
                    throw new Exception("Файл не найден");
                }

            }

            public static void WriteInFile(List<int> sortedArray, string path)
            {
                
                StreamWriter sr = new StreamWriter(path);
                foreach (var sorted in sortedArray)
                {
                    sr.Write(sorted + " "); 
                }
                sr.Close();
            }

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
                public int[] X { get; set; }
                public int[] Expected { get; set; }
                public Exception ExpectedException { get; set; }

                public static void TestSort(TestCase testCase)
                {
                    try
                    {
                        var list = Sort(testCase.X);

                        var actual = list.ToArray();


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
                   
                    int[] array = ReadFromFile(@"C:\Users\Сергей\source\repos\2B_Lesson8\2B_Lesson8\arr.txt");

                    Console.WriteLine("External Sort \nСчитываю данные из файла....\n");
                     
                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.Write(array[i] + " ");
                    }
                  

                    List<int> sorted = Sort(array);
                    var newSorted = sorted.ToArray();
                    var expected = new int[] { 4, 6, 13, 17, 31, 43, 62, 66, 87, 92, 96 };
                    Console.WriteLine("\n\nМассив отсортирован. Записываю данные в файл....\n");

                    WriteInFile(sorted, @"C:\Users\Сергей\source\repos\2B_Lesson8\2B_Lesson8\SortedArray.txt");

                    foreach (var sort in sorted)
                    {
                        Console.Write(sort + " ");
                    }
                    Console.WriteLine();

                    var testCase = new TestCase()
                    {

                        X = newSorted,
                        Expected = expected,
                        ExpectedException = null,
                    };

                    TestCase.TestSort(testCase);



                    Console.ReadLine();
                }
            }
        }
    }
}
