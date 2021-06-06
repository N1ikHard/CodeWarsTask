using System;
using System.Collections.Generic;

namespace CodeWarsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 18, 9, -3, 8, 6, 10, 16, 9, 17, 12, -4, 0, 15, -3, 4, -2, 6, -1, 15, 14, 9, 10, 14, 19, 5, 16, 8, 2, 12 };
            /*
        new int[]{1,2,3,6,4,1,2,3,2,1},
        new int[]{3,2,3,6,4,1,2,3,2,1,2,3},
        new int[]{3,2,3,6,4,1,2,3,2,1,2,2,2,1},
        new int[]{2,1,3,1,2,2,2,2,1},
        new int[]{2,1,3,1,2,2,2,2}

             18, 9, -3, 8, 6, 10, 16, 9, 17, 12, -4, 0, 15, -3, 4, -2, 6, -1, 15, 14, 9, 10, 14, 19, 5, 16, 8, 2, 12
             18, -2, -1, 15, 10, 5, 12, 17, 13, 9, 4, 8, 10, 0, 13, -3, -4, 13, 9, 14, 2, 19, 19, -3, 2, 11, 14, 6, 6
            -1, 12, -5, -4, 7, 13, 15, 18, 10, 6, 0, -4, 0, 19, 11, 6, 5, 14, 16, 13, 12, 12, 13, 10

        new int[]{3,7},
        new int[]{3,7},
        new int[]{3,7,10},
        new int[]{2,4},
        new int[]{2}
         peaksS =
        new int[]{6,3},
        new int[]{6,3},
        new int[]{6,3,2},
        new int[]{3,2},
        new int[]{3}
             */
            Dictionary<string , List<int>> kkk=
            Kata.GetPeaks(array);
            foreach(var s in kkk)
            {
                Console.Write(s.Key.ToString()+":");
                foreach(var f in s.Value)
                {
                    Console.Write(f.ToString()+":");
                }
                Console.WriteLine();
            }
            Console.WriteLine(kkk["pos"][0]);
            Dictionary<string, List<int>> prove = new Dictionary<string, List<int>>();
            prove.Add("pos", new List<int>() { 1,3,6,11,14 });
            prove.Add("peaks", new List<int>() { 11, 11, 18, 18, 7 });
            Console.WriteLine(prove.Equals(kkk));
        }
    }
}
