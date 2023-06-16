using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWorkCRYPT.Classes
{
    public static class Cesar
    {
        public static string Crypt (int key, string path)
        {
            if (File.Exists(path))
            {


                string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                string alphabetBig = alphabet.ToUpper();
                StringBuilder strCrypt = new StringBuilder();


                StreamReader sr = new StreamReader(path);
                string str = sr.ReadToEnd();



                for (int i = 0; i < str.Length; i++)
                {
                    if (!alphabet.Contains(str[i]) && !alphabetBig.Contains(str[i]))
                    {
                        strCrypt.Append(str[i]);
                    }
                    if (alphabet.Contains(str[i]))
                    {
                        if (alphabet.IndexOf(str[i]) + key > 32)
                        {
                            int newkey = (alphabet.IndexOf(str[i]) + key) - 33;
                            strCrypt.Append(alphabet[newkey]);
                        } else
                        {
                            int newkey = (alphabet.IndexOf(str[i]) + key);
                            strCrypt.Append(alphabet[newkey]);
                        }
                    }

                    if (alphabetBig.Contains(str[i]))
                    {
                        if (alphabetBig.IndexOf(str[i]) + key > 32)
                        {
                            int newkey = (alphabetBig.IndexOf(str[i]) + key) - 33;
                            strCrypt.Append(alphabetBig[newkey]);
                        } else
                        {
                            int newkey = (alphabetBig.IndexOf(str[i]) + key);
                            strCrypt.Append(alphabetBig[newkey]);
                        }
                    }
                }
                sr.Close();
                StreamWriter sw = new StreamWriter(path);
                sw.Write(strCrypt);
                sw.Close();
                return "Файл зашифрован";
            }
            else
            {
                return "Файл не найден";
            }

            
            
        }


        public static string Decrypt (int key, string path)
        {
            if (File.Exists(path))
            {


                string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                string alphabetBig = alphabet.ToUpper();
                StringBuilder strCrypt = new StringBuilder();


                StreamReader sr = new StreamReader(path);
                string str = sr.ReadToEnd();



                for (int i = 0; i < str.Length; i++)
                {
                    if (!alphabet.Contains(str[i]) && !alphabetBig.Contains(str[i]))
                    {
                        strCrypt.Append(str[i]);
                    }
                    if (alphabet.Contains(str[i]))
                    {
                        if (alphabet.IndexOf(str[i]) - key < 0)
                        {
                            int newkey = (alphabet.IndexOf(str[i]) - key) + 33;
                            strCrypt.Append(alphabet[newkey]);
                        } else
                        {
                            int newkey = (alphabet.IndexOf(str[i]) - key);
                            strCrypt.Append(alphabet[newkey]);
                        }
                    }

                    if (alphabetBig.Contains(str[i]))
                    {
                        if (alphabetBig.IndexOf(str[i]) - key < 0)
                        {
                            int newkey = (alphabetBig.IndexOf(str[i]) - key) + 33;
                            strCrypt.Append(alphabetBig[newkey]);
                        } else
                        {
                            int newkey = (alphabetBig.IndexOf(str[i]) - key);
                            strCrypt.Append(alphabetBig[newkey]);
                        }
                    }
                }

                sr.Close();
                StreamWriter sw = new StreamWriter(path);
                sw.Write(strCrypt);
                sw.Close();
                return "Файл расшифрован";
            }
            else
            {
                return "Файл не найден";
            }
            

        }
    }
}
