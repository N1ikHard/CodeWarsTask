﻿using System;
using System.Collections;
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

            for (int i = 0; i < text.Length - 1; i++)
                for (int j = i + 1; j < text.Length; j++)
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
            CountRepeat.Add(6, 0);

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
                score += 1000 + ((CountRepeat[1] % 3) * 100);
            else score += (CountRepeat[1] % 3) * 100;

            if (CountRepeat[5] >= 3)
                score += 500 + ((CountRepeat[5] % 3) * 50);
            else score += (CountRepeat[5] % 3) * 50;

            return score;
        }
        public static Dictionary<string, List<int>> GetPeaks(int[] arr)
        {
            #region ТЗ
            /*
            Повторите в этом ката, вы напишете функцию, которая возвращает позиции и значения "пиков" 
            (или локальных максимумов) числового массива.
            Например, массив arr = [0, 1, 2, 5, 1, 0] имеет пик в позиции 
            3 со значением 5 (так как arr[3] равен 5).
            Выходные данные будут возвращены в виде словаря<string, List<int>> 
            с двумя парами ключ-значение: "pos" и "peaks". 
            Если в данном массиве нет пика, просто верните 
            {"pos" => new List<int>(), "peaks" => new List<int>()}.

            Пример: PeackPicks([3, 2, 3, 6, 4, 1, 2, 3, 2, 1, 2, 3]) 
            должно возвращать {pos: [3, 7], peaks: [6, 3]}

            Все входные массивы будут допустимыми целочисленными массивами 
            (хотя они все равно могут быть пустыми), поэтому вам не нужно будет проверять входные данные.

            Первый и последний элементы массива не будут рассматриваться как пики
            (в контексте математической функции мы не знаем, что происходит после и до, и,
            следовательно, мы не знаем, является ли это пиком или нет).

            Кроме того, остерегайтесь плато !!! 
            [1, 2, 2, 2, 1] имеет пик в то время как
            [1, 2, 2, 2, 3] и [1, 2, 2, 2, 2] нет. 
            В случае плато-пика, верните только положение 
            и значение начала плато. 
            Например: Пикпики([1, 2, 2, 2, 1]) возвращает 
            {pos: [1], peaks: [2]}

            
            Примеры  18, 9, -3, 8, 6, 10, 16, 9, 17, 12, -4, 0, 15, -3, 4, -2, 6, -1, 15, 14, 9, 10, 14, 19, 5, 16, 8, 2, 12
             18, -2, -1, 15, 10, 5, 12, 17, 13, 9, 4, 8, 10, 0, 13, -3, -4, 13, 9, 14, 2, 19, 19, -3, 2, 11, 14, 6, 6
            -1, 12, -5, -4, 7, 13, 15, 18, 10, 6, 0, -4, 0, 19, 11, 6, 5, 14, 16, 13, 12, 12, 13, 10


            Работает , роходит пробное тестирование , проходит еще 2 варианта теста  , но в итоге
            CodeWars выкидывает такое исключение:
            Test Failed
            Testing for 18, 9, -3, 8, 6, 10, 16, 9, 17, 12, -4, 0, 15, -3, 4, -2, 6, -1, 15, 14, 9, 10, 14, 19, 5, 16, 8, 2, 12:
             Expected and actual are both <System.Collections.Generic.Dictionary`2[System.String,System.Collections.Generic.List`1[System.Int32]]> with 2 elements
             Values differ at index [0]
             Expected: 3
             But was:  0
             */
            #endregion
            Dictionary<string, List<int>> keyValuePairs=new Dictionary<string, List<int>>();
            keyValuePairs.Add("pos" , new List<int>());
            keyValuePairs.Add("peaks", new List<int>());
            int index = 1;
            int Maximum;
            bool repeat = true;
            for (int i = 1; i < arr.Length-1; i++)
            {
                if (arr[i] < arr[i + 1])
                {
                    Maximum = arr[i + 1];
                    index = i+1;
                    repeat = true;
                }
                if (arr[i] > arr[i + 1])
                {
                    if (repeat)
                    {
                        int n1 = Convert.ToInt32(index);
                        keyValuePairs["pos"].Add(n1);
                        int n2 = Convert.ToInt32(arr[index]);
                        keyValuePairs["peaks"].Add(n2);
                        repeat = false;
                    }
                }               
            }    
            return keyValuePairs;
            }      
        
    }
    } 
