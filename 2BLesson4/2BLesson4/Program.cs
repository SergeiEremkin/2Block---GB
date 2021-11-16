using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace _2BLesson4
{


    //  1. Протестируйте поиск строки в HashSet и в массиве
    //  Заполните массив и HashSet случайными строками, не менее 10 000 строк.Строки можно сгенерировать.
    //  Потом выполните замер производительности проверки наличия строки в массиве и HashSet.Выложите код и результат замеров.

    public class Program

    {
        public class BenchmarkTest
        {

            public string GetRandom()
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                var stringChars = new char[8];
                var random = new Random();
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];

                }
                var finalString = new String(stringChars);
                return finalString;
            }

            public string[] RandomArr(string[] arr)
            {

                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = GetRandom();
                    
                }
                return arr;
            }       
                
            public HashSet<string> RandomHashSet(HashSet<string>hashSet)
            {

                for (int i = 0; i <= 10000; i++)
                {

                    hashSet.Add(GetRandom());
                }
                return hashSet;
            }

            [Benchmark]
            public void ArrTest()
            {
                string[] arr =new string[10000];
                RandomArr(arr);

                for (int i = 0; i < arr.Length; i++)
                {
                    
                }

            }

            [Benchmark]
            public void HashTest()
            {
                var hashSet = new HashSet<string>();
                RandomHashSet(hashSet);

                foreach(var h in hashSet)
                {
                   Console.WriteLine("contains h" + " " + hashSet.Contains(h));      
                }
            }
            
        }

            static void Main(string[] args)
            {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            
                Console.ReadLine();
            }
        }
    }

