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
            #region Аналогичное решение
            //  int SS = seconds % 60;
            //  seconds /= 60;
            //  int MM = seconds%60;
            //  seconds /= 60;
            //  int HH = seconds%100;
            // string result = ":"+(seconds % 60).ToString();
            //  result = ((seconds/(60*60)%100).ToString()+":" + ((seconds / 60) % 60).ToString() + ":" + (seconds % 60).ToString());
            //return HH.ToString() + ":" + MM.ToString() + ":" + SS.ToString();
            #endregion
            return new string((seconds / (60 * 60) % 100).ToString("00") + ":" + ((seconds / 60) % 60).ToString("00") + ":" + (seconds % 60).ToString("00"));
        }
        public static string DuplicateEncode(string text)
        {
            #region ТЗ
            //Цель этого упражнения состоит в том, 
            //чтобы преобразовать строку в новую строку, 
            //где каждый символ в новой строке равен " ( ",
            //если этот символ появляется только один раз 
            //в исходной строке, или")", если этот символ
            //появляется более одного раза в исходной строке.
            //Игнорируйте заглавные буквы при определении того,
            //является ли символ дубликатом.
            //Примеры
            //"din" = > " ((("
            //"отступить" => "()()()"
            //"Успех" => ")())())"
            //"(( @" => "))(("
            #endregion
            char[] array = new char[text.Length];
            text = text.ToLower();
            for (int i = 0; i < array.Length; i++)
                array[i] = '(';

                for (int i = 0; i < text.Length-1; i++)
                     for(int j = i+1; j < text.Length; j++)
                     {
                          if (text[i] == text[j])
                           {
                                array[i] = ')';
                                array[j] = ')';
                           }
                      }

            return String.Concat(array);
        }
        public static int Score(int[] dice)
        {
            #region
            /*
            Жадность-это игра в кости, в которую играют пятью шестигранными кубиками.
            Ваша миссия состоит в том, чтобы забить бросок в соответствии с этими правилами.
            Вам всегда будет предоставлен массив с пятью шестигранными значениями кубиков.
            Три 1 => 1000 очков
            Три 6-х => 600 очков
            Три пятерки => 500 очков
            Три 4-х => 400 очков
            Три 3-х => 300 очков
            Три 2-х => 200 очков
            Один 1 => 100 очков
            Один 5 => 50 баллов
            Один кубик может быть подсчитан только один раз в каждом броске.
            Например, данная "5" может считаться только частью триплета (вклад в 500 очков)
            или как единое 50 очков, но не оба в одном броске.
            Пример подсчета очков
            Счет броска
            —-----— —--------------—
            5 1 3 4 1 250: 50 (для 5) + 2 * 100 (для 1s)
            1 1 1 3 1 1100: 1000 (для трех 1s) + 100 (для остальных 1)
            2 4 4 5 4 450: 400 (для трех 4s) + 50 (для 5) */
            #endregion

            int score = 0;
            Dictionary<int, int> CountRepeat = new Dictionary<int, int>();

            CountRepeat.Add(1, 0);
            CountRepeat.Add(2, 0);
            CountRepeat.Add(3, 0);
            CountRepeat.Add(4, 0);
            CountRepeat.Add(5, 0);
            CountRepeat.Add(6,0);

            for (int i = 0; i < dice.Length; i++)
                switch (dice[i])
                {
                    case 1:
                        CountRepeat[1] += 1;
                        break;
                    case 2:
                        CountRepeat[2] += 1;
                        break;
                    case 3:
                        CountRepeat[3] += 1;
                        break;
                    case 4:
                        CountRepeat[4] += 1;
                        break;
                    case 5:
                        CountRepeat[5] += 1;
                        break;
                    case 6:
                        CountRepeat[6] += 1;
                        break;
                }

            foreach (var num in CountRepeat)
                if (num.Key == 1 || num.Key == 5) continue;
                else
                    if (num.Value >= 3)
                        score += 100 * num.Key;
                
            if (CountRepeat[1] >= 3)
               score += 1000+ ((CountRepeat[1] % 3) * 100); 
            else score += (CountRepeat[1] % 3) * 100;

            if (CountRepeat[5] >= 3)
                score += 500+((CountRepeat[5] % 3) * 50);
            else score += (CountRepeat[5] % 3) * 50;
            
            return score;
        }
    }
}
