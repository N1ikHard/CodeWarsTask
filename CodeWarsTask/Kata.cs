using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarsTask
{
    class Kata
    {
        public static string GetReadableTime(int seconds)
        {
            #region ТЗ
            /*
            Напишите функцию, которая принимает неотрицательное целое число (секунды)
            в качестве входных данных и возвращает время в удобочитаемом формате (ЧЧ:ММ:СС)
            HH = часы, дополненные 2 цифрами, диапазон: 00 - 99
            ММ = минуты, заполненные до 2 цифр, диапазон: 00 - 59
            SS = секунды, заполненные до 2 цифр, диапазон: 00 - 59
            Максимальное время никогда не превышает 359999 (99:59:59)
                
            00:00:05", TimeFormat.GetReadableTime(5));
            00:01:00", TimeFormat.GetReadableTime(60));
            23:59:59", TimeFormat.GetReadableTime(86399));
            99:59:59", TimeFormat.GetReadableTime(359999));
            */
            #endregion
            //  int SS = seconds % 60;
            //  seconds /= 60;
            //  int MM = seconds%60;
            //  seconds /= 60;
            //  int HH = seconds%100;
            // string result = ":"+(seconds % 60).ToString();
            //  result = ((seconds/(60*60)%100).ToString()+":" + ((seconds / 60) % 60).ToString() + ":" + (seconds % 60).ToString());
            //return HH.ToString() + ":" + MM.ToString() + ":" + SS.ToString();
            return new string((seconds / (60 * 60) % 100).ToString("00") + ":" + ((seconds / 60) % 60).ToString("00") + ":" + (seconds % 60).ToString("00"));
        }
    }
}
