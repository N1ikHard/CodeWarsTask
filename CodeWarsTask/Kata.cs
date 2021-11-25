using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarsTask
{
    static class Kata
    {
        /// <summary>
        /// Преобразование секунд в формат ЧЧ:ММ:СС
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Преобразование строки в строку из скобкок , инструкция внутри
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Метод , считающий очки(аргумент) в соответсвии с правилами(указаны в комментариии)
        /// </summary>
        /// <param name="dice"></param>
        /// <returns></returns>
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
            Dictionary<string, List<int>> keyValuePairs = new Dictionary<string, List<int>>();
            keyValuePairs.Add("pos", new List<int>());
            keyValuePairs.Add("peaks", new List<int>());
            int index = 1;
            int Maximum;
            bool repeat = true;
            for (int i = 1; i < arr.Length - 1; i++)
            {
                if (arr[i] < arr[i + 1])
                {
                    Maximum = arr[i + 1];
                    index = i + 1;
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
        /// <summary>
        /// Метод расщирения возвращающий строку , состоящую из элементов массива
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string GetString(this string[] array)
        {
            string result = "";
            foreach (var item in array)
                result += item + " ";
            return result;
        }
        /// <summary>
        /// Метод , преобразующий все слова строки таким образом , что первая буква слова становится в конец + добавляется суффикс "ay"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string PigIt(this string str)
        {
            #region ТЗ
            //Переместите первую букву каждого слова в его конец, затем добавьте "ай" в конец слова.Оставьте знаки препинания нетронутыми.
            //Примеры
            //Cata.PigIt("Hello World!");// elloHay orldWay!


            // Лучнее решение     return string.Join(" ", str.Split(' ').Select(w => w.Any(char.IsPunctuation) ? w : w.Substring(1) + w[0] + "ay"));

            #endregion

            string[] array = str.Split(" ");
            str = "";
            foreach (var item in array)
                if (item == "," || item == "." || item == "!")
                    str += item + " ";
                else str += item.Insert(item.Length, item[0] + "ay").Remove(0, 1) + " ";
            return str.Remove(str.Length - 1, 1);
        }

        /// <summary>
        /// Метод , форматирования кол-ва секунд в текстовое представление даты год/дни/часы/секунды
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static string formatDuration(int seconds)
        {
            if (seconds <= 0) return "Now";
            #region ТЗ
            //Ваша задача для выполнения этого Ката -написать функцию, которая форматирует продолжительность,
            //заданную в виде количества секунд, удобным для человека способом.
            //Функция должна принимать неотрицательное целое число. Если он равен нулю, он просто возвращает "сейчас".
            //В противном случае продолжительность выражается в виде комбинации лет, дней, часов, минут и секунд.
            #endregion
            #region  Test
            //1 hour, 1 minute and 2 seconds"(3662));
            // 1 hour, 44 minutes and 40 seconds"(15731080));
            //"4 years, 68 days, 3 hours and 4 minutes", (132030240));
            //("6 years, 192 days, 13 hours, 3 minutes and 54 seconds"(205851834));
            //("8 years, 12 days, 13 hours, 41 minutes and 1 second"(253374061));
            //("7 years, 246 days, 15 hours, 32 minutes and 54 second(242062374));
            //("3 years, 85 days, 1 hour, 9 minutes and 26 seconds"(101956166));
            //("1 year, 19 days, 18 hours, 19 minutes and 46 seconds" (33243586));
            #endregion

            string result = "";

            int year = (seconds / (60 * 60 * 24 * 365));
            result = year > 0 ? year > 1 ? year + " years, " : year + " year, " : result + "";
            //Поможет ли для оптимизации все вычисления делать с одной переменной?
            int days = (seconds / (60 * 60 * 24) % 365);                                                                 //
            result = days > 0 ? result += days > 1 ? days + " days, " : days + " day, " : result + "";

            int hour = (seconds / (60 * 60)) % 24;
            result = hour > 0 ? result += hour > 1 ? hour + " hours, " : hour + " hour, " : result + "";

            int min = (seconds / 60) % 60;
            result = min > 0 ? result += min > 1 ? min + " minutes, " : min + " minute, " : result + "";

            int sec = seconds % 60;
            result = sec > 0 ? result += sec > 1 ? sec + " seconds " : sec + " second " : result;

            result = result.Trim().Trim(',');                                                           //При получившемся значении , когда кол-во секунд = 0 , удаляем пробел и запятую в конце
            int index = result.LastIndexOf(',');                                                        //Находим индекс последнего вхождения запятой
            result = index > 0 ? result.Remove(index, 1).Insert(index, " and") : result;                      //Если он есть , то заменяем его на and , иначе возвращаем , что есть


            return result;
        }
        /// <summary>
        /// Валидатор судоку. Определяет соблюдены ли все правила расстановки цифр на сетке.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static bool ValidateSolution(int[][] board)
        {
            //Успешно пройдены все тесты!

            #region ТЗ
            //https://www.codewars.com/kata/529bf0e9bdf7657179000008/train/csharp
            //Судоку - это игра, в которую играют на сетке 9х9.Цель игры состоит в том, чтобы заполнить все ячейки сетки цифрами от 1 до 9,
            //чтобы каждый столбец, каждая строка и каждая из девяти подсеток 3x3(также известных как блоки) содержали все цифры от 1 до 9.
            //Напишите функцию , которая принимает 2D - массив, представляющий доску судоку, и возвращает true,
            //если это допустимое решение, или false в противном случае.Ячейки доски судоку также могут содержать 0, которые будут представлять пустые ячейки.
            //Доски, содержащие один или несколько нулей, считаются недопустимыми решениями.
            //Доска всегда состоит из 9 ячеек на 9 ячеек, и каждая ячейка содержит только целые числа от 0 до 9.

            //Examples
            //validSolution([
            // [5, 3, 4, 6, 7, 8, 9, 1, 2],
            // [6, 7, 2, 1, 9, 5, 3, 4, 8],
            // [1, 9, 8, 3, 4, 2, 5, 6, 7],
            // [8, 5, 9, 7, 6, 1, 4, 2, 3],
            // [4, 2, 6, 8, 5, 3, 7, 9, 1],
            // [7, 1, 3, 9, 2, 4, 8, 5, 6],
            // [9, 6, 1, 5, 3, 7, 2, 8, 4],
            // [2, 8, 7, 4, 1, 9, 6, 3, 5],
            // [3, 4, 5, 2, 8, 6, 1, 7, 9]
            //]); // => true
            //            validSolution
            // [5, 3, 4, 6, 7, 8, 9, 1, 2], 
            // [6, 7, 2, 1, 9, 0, 3, 4, 8],
            // [1, 0, 0, 3, 4, 2, 5, 6, 0],
            // [8, 5, 9, 7, 6, 1, 0, 2, 0],
            // [4, 2, 6, 8, 5, 3, 7, 9, 1],
            // [7, 1, 3, 9, 2, 4, 8, 5, 6],
            // [9, 0, 1, 5, 3, 7, 2, 1, 4],
            // [2, 8, 7, 4, 1, 9, 6, 3, 5],
            // [3, 0, 0, 4, 8, 1, 1, 7, 9]
            // ]); // => false
            #endregion

            //Алгоритм поиска одинаковых значений по строкам
            foreach (var item1 in board)
                foreach (var item2 in item1)
                    if (Array.IndexOf(item1, item2) != Array.LastIndexOf(item1, item2) || item2 == 0)
                        return false;

            //Сумма для проверки в по вертикали и кубах 3х3
            int CheckSum = (9 + 1 + 8 + 2 + 7 + 3 + 6 + 4 + 5);

            //Проверка по вертикали
            for (int i = 0, sum = 0; i < board.Length; i++, sum = 0)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    if (board[j][i] <= 0 || board[j][i] > 9)
                        return false;
                    else sum += board[j][i];
                }
                if (sum != CheckSum) 
                    return false;
            }

            int CountCube = 0;
            int StartIndexCol =0;
            int StartIndexRow =0;
            int LastIndexCol=0;
            int LastIndexRow=0;

            List<int> CheckList = new List<int>();
           for( ; CountCube< board.Length; CountCube++)
            { 
                switch (CountCube)
                {
                    case 0:
                        StartIndexCol = 0;
                        LastIndexCol = 3;

                        StartIndexRow = 0;
                        LastIndexRow = 3;
                        break;

                    case 1:
                        StartIndexRow = 0;
                        LastIndexRow = 3;

                        StartIndexCol = 3;
                        LastIndexCol = 6;
                        break;
                    
                    case 2:
                        StartIndexRow = 0;
                        LastIndexRow = 3;

                        StartIndexCol = 6;
                        LastIndexCol = 9;
                        break;

                    case 3:
                        StartIndexRow = 3;
                        LastIndexRow = 6;

                        StartIndexCol = 0;
                        LastIndexCol = 3;
                        break;
                    case 4:
                        StartIndexRow = 3;
                        LastIndexRow = 6;

                        StartIndexCol = 3;
                        LastIndexCol = 6;
                        break;

                    case 5:
                        StartIndexRow = 3;
                        LastIndexRow = 6;

                        StartIndexCol = 6;
                        LastIndexCol = 9;
                        break;
                    case 6:
                        StartIndexRow = 6;
                        LastIndexRow = 9;

                        StartIndexCol = 0;
                        LastIndexCol = 3;
                        break;
                    case 7:
                        StartIndexRow = 6;
                        LastIndexRow = 9;

                        StartIndexCol = 3;
                        LastIndexCol = 6;
                        break;

                    case 8:
                        StartIndexRow = 6;
                        LastIndexRow = 9;

                        StartIndexCol = 6;
                        LastIndexCol = 9;
                        break;
                }
                for (; StartIndexRow < LastIndexRow; StartIndexRow++)
                {
                    int SaveIndexCol = StartIndexCol;
                         for (; StartIndexCol < LastIndexCol; StartIndexCol++)
                               CheckList.Add(board[StartIndexRow][StartIndexCol]);
                    StartIndexCol = SaveIndexCol;
                }

            }
            int[] array = CheckList.ToArray();
            for (int i = 0,k=9,  sum = 0; i < array.Length - 10; i += 9, sum = 0 ,k+=9)
            {
                for (int j = i; j < k; j++)
                    sum += array[j];

                if (sum != CheckSum)
                    return false;
            }   
            return true;
        }
    }
} 
