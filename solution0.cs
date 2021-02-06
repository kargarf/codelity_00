using System;
using System.Collections.Generic;

namespace CodTest
{
    class Program
    {
        static int GetFact(int a)
        {
            int fact = 1;
            for (int i = a; i > 0; i--)
                fact *= i;
            return fact;
        }
        static int solution(int[] arr)
        {
            //Possible outcomes -> combinations n!/(r!*(n-r)!)
            int combOut = GetFact(arr.Length) / (GetFact(2) * GetFact(arr.Length - 2));

            //an Array of size combOut is need
            int[] combArr = new int[combOut + 1];

            int arrCounter = 0;
            int n = arr.Length;
            int tempElement;
            for (int i = 0; i < n; i++)
            {
                //take one element to find subSum with other elements
                tempElement = arr[i];
                for (int j = i; j < n; j++) //for combination j=i, if it was permutation j=0
                {
                    if (tempElement != arr[j] && i != j)
                        combArr[arrCounter++] = tempElement + arr[j]; //Segement With Same Sum
                }
            }

            //From combArr find the number of same elements, which is maxNumberOfSegementWithSameSum
            var dict = new Dictionary<int, int>();
            foreach (var value in combArr)
            {
                if (dict.ContainsKey(value))
                    dict[value]++;
                else
                    dict[value] = 1;
            }

            //Get the biggest key value and return it.
            int maxNumberOfSegementWithSameSum = 0;
            foreach (var pair in dict)
            {
                if (maxNumberOfSegementWithSameSum < pair.Value)
                    maxNumberOfSegementWithSameSum = pair.Value;
            }

            return maxNumberOfSegementWithSameSum;
        }

        static void Main(string[] args)
        {
            int[] test = { 10, 1, 3, 1, 2, 2, 1, 0, 4 };
            int a = solution(test);
            Console.WriteLine($"Result : {a}");
            Console.ReadLine();
        }
    }
}

