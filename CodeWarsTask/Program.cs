using System;

namespace CodeWarsTask
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine(Kata.GetReadableTime(0));
           Console.WriteLine(Kata.GetReadableTime(5));
            Console.WriteLine(Kata.GetReadableTime(60));
            Console.WriteLine(Kata.GetReadableTime(86399));
           
           Console.WriteLine(Kata.GetReadableTime(359999));
        }
    }
}
