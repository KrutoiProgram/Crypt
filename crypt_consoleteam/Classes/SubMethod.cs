using System.Text;

namespace TeamWorkCRYPT.Classes
{
    public static class SubMethod
    {
        public static string Encryption (string keyFile, string file)
        {
            string alphabet = string.Empty;
            string textForEncrytion = string.Empty;
            if (File.Exists(keyFile))
            {
                alphabet = File.ReadAllText(keyFile);
            } 
            else
            {
                Console.WriteLine("Файл не существует!");
            }

            if (File.Exists(file))
            {
                textForEncrytion = File.ReadAllText(file).ToLower();
            } 
            else
            {
                Console.WriteLine("Файл не существует!");
            }

            StringBuilder reverseAlphabet = new();

            for (int i = alphabet.Length - 1; i >= 0; i--)
            {
                reverseAlphabet.Append(alphabet[i]);
            }

            StringBuilder result = new();
            char simbol = ' ';

            for (int i = 0; i < textForEncrytion.Length; i++)
            {
                if (alphabet.Contains(textForEncrytion[i]))
                {
                    int index = alphabet.IndexOf(textForEncrytion[i]);
                    simbol = reverseAlphabet[index];
                }
                result.Append(simbol);
            }

            StreamWriter sw = new(file);
            sw.Write(result.ToString());
            sw.Close();
            Console.WriteLine("Файл зашифрован!");

            return result.ToString();
        }

        public static string Decryption (string keyFile, string file)
        {
            string alphabet = string.Empty;
            string textForDecryption = string.Empty;
            if (File.Exists(keyFile))
            {
                alphabet = File.ReadAllText(keyFile);
            } 
            else
            {
                Console.WriteLine("Файл не существует!");
            }

            if (File.Exists(file))
            {
                textForDecryption = File.ReadAllText(file).ToLower();
            } 
            else
            {
                Console.WriteLine("Файл не существует!");
            }

            StringBuilder reverseAlphabet = new();

            for (int i = alphabet.Length - 1; i >= 0; i--)
            {
                reverseAlphabet.Append(alphabet[i]);
            }

            StringBuilder result = new();
            char simbol = ' ';

            for (int i = 0; i < textForDecryption.Length; i++)
            {
                if (reverseAlphabet.ToString().Contains(textForDecryption[i]))
                {
                    int index = reverseAlphabet.ToString().IndexOf(textForDecryption[i]);
                    simbol = alphabet[index];
                }
                result.Append(simbol);
            }

            StreamWriter sw = new(file);
            sw.Write(result.ToString());
            sw.Close();
            Console.WriteLine("Файл расшифрован!");

            return result.ToString();
        }
    }
}
