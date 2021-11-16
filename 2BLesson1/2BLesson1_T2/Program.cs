using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2BLesson1_T2
{
    //2.Посчитайте сложность функции
    //Вычислите асимптотическую сложность функции из примера ниже.
    class Program
    {
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;     // O(1)
            for (int i = 0; i < inputArray.Length; i++)     // O(N)
            {
                for (int j = 0; j < inputArray.Length; j++)  // O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++)  // O(N)
                    {
                        int y = 0; 

                        if (j != 0)
                        {
                            y = k / j;
                        }

                        sum += inputArray[i] + i + k + j + y;
                    }
                }
            }

            return sum;  // O(1)
        }

        // O(1 + 1 + N*N*N)(Константы отбрасываем) ответ: O(N^3)

        static void Main(string[] args)
        {

            

        }
    }
}
