using DryIoc.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TeamWorkCRYPT.Classes
{
    public static class VigenereCD
    {
        public static async void Crypt (string FileName)
        {
            // Cчитываем из файла сообщения
            StreamReader reader = new StreamReader(FileName);//считываем название файла с исходным текстом
            StreamReader reader2 = new StreamReader("CipherKey.txt");//считываем название файла с кодом для шифрования
            string startText = reader.ReadToEnd();
            string k = reader2.ReadToEnd();
            reader.Close();
            reader2.Close();
            int nomer; // Номер в алфавите
            int d; // Смещение
            string Result; //Результат
            int j, f; // Переменная для циклов
            int t = 0; // Преременная для нумерации символов ключа.
            char[] massage = startText.ToCharArray(); // Превращаем сообщение в массив символов.
            char[] key = k.ToCharArray(); // Превращаем ключ в массив символов.
            char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };//Алфавит
            for (int i = 0; i < startText.Length; i++)
            {
                if (!Regex.IsMatch(startText, @"\p{IsCyrillic}"))
                {
                    await Console.Out.WriteLineAsync("В исходном тексте должна быть только кириллица");
                    return;
                }
            }

            // Перебираем каждый символ сообщения
            for (int i = 0; i < massage.Length; i++)
            {
                // Ищем индекс буквы
                for (j = 0; j < alfavit.Length; j++)
                {
                    if (massage[i] == alfavit[j])
                    {
                        break;
                    }
                }

                if (j != 33) // Если j равно 33, значит символ не из алфавита
                {
                    nomer = j; // Индекс буквы

                    // Ключ закончился - начинаем сначала.
                    if (t > key.Length - 1)
                    { t = 0; }

                    // Ищем индекс буквы ключа
                    for (f = 0; f < alfavit.Length; f++)
                    {
                        if (key[t] == alfavit[f])
                        {
                            break;
                        }
                    }

                    t++;

                    if (f != 33) // Если f равно 33, значит символ не из алфавита
                    {
                        d = nomer + f;
                    } else
                    {
                        d = nomer;
                    }

                    // Проверяем, чтобы не вышли за пределы алфавита
                    if (d > 32)
                    {
                        d = d - 33;
                    }

                    massage[i] = alfavit[d]; // Меняем букву
                }
            }

            Result = new string(massage); // Собираем символы обратно в строку.
            StreamWriter streamWriter = new StreamWriter(FileName, false);
            await streamWriter.WriteLineAsync(Result);
            streamWriter.Close();
        }

        public static async void Decrypt (string FileName)
        {
            // Cчитываем из файла сообщения
            StreamReader reader = new StreamReader(FileName);//считываем название файла с исходным текстом
            StreamReader reader2 = new StreamReader("CipherKey.txt");//считываем название файла с кодом для шифрования
            string startText = reader.ReadToEnd();
            string k = reader2.ReadToEnd();
            reader.Close();
            reader2.Close();
            int nomer; // Номер в алфавите
            int d; // Смещение
            string Result; //Результат
            int j, f; // Переменная для циклов
            int t = 0; // Преременная для нумерации символов ключа.
            char[] massage = startText.ToCharArray(); // Превращаем сообщение в массив символов.
            char[] key = k.ToCharArray(); // Превращаем ключ в массив символов.
            char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };//Алфавит
            for (int i = 0; i < startText.Length; i++)
            {
                if (!Regex.IsMatch(startText, @"\p{IsCyrillic}"))
                {
                    await Console.Out.WriteLineAsync("В исходном тексте должна быть только кириллица");
                    return;
                }
            }

            // Перебираем каждый символ сообщения
            for (int i = 0; i < massage.Length; i++)
            {
                // Ищем индекс буквы
                for (j = 0; j < alfavit.Length; j++)
                {
                    if (massage[i] == alfavit[j])
                    {
                        break;
                    }
                }

                if (j != 33) // Если j равно 33, значит символ не из алфавита
                {
                    nomer = j; // Индекс буквы

                    // Ключ закончился - начинаем сначала.
                    if (t > key.Length - 1)
                    { t = 0; }

                    // Ищем индекс буквы ключа
                    for (f = 0; f < alfavit.Length; f++)
                    {
                        if (key[t] == alfavit[f])
                        {
                            break;
                        }
                    }

                    t++;

                    if (f != 33) // Если f равно 33, значит символ не из алфавита
                    {
                        d = nomer - f;
                    } else
                    {
                        d = nomer;
                    }

                    // Проверяем, чтобы не вышли за пределы алфавита
                    if (d < 0)
                    {
                        d = d + 33;
                    }

                    massage[i] = alfavit[d]; // Меняем букву
                }

                Result = new string(massage); // Собираем символы обратно в строку.
                StreamWriter streamWriter = new StreamWriter(FileName, false);
                await streamWriter.WriteLineAsync(Result);
                streamWriter.Close();
            }

        }
    }
}       
