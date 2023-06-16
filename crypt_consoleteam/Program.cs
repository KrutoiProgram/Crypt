using TeamWorkCRYPT.Classes;
using System.Text.RegularExpressions;



Console.WriteLine("Команда HELP - справка о командах");
string command;
int check = 1;
do
{

    command = Console.ReadLine();
    command = CheckCommand(command);

    var mas = command.Split(' ');
    string resCommand = "";
    if (mas[0] == "DECRYPT")
    {
        resCommand = mas[0] + " " + mas[1];
    } else
    {
        resCommand = mas[0];
    }
    switch (resCommand)
    {
        case "HELP":
            PrintChoice();
            break;
        case "CAESAR":// mas[1] - key, mas[2] - file
            Console.WriteLine(Cesar.Crypt(int.Parse(mas[1]), mas[2]) );
            
            break;
        case "DECRYPT CAESAR"://mas[2] - key, mas[3] - file
            Console.WriteLine(Cesar.Decrypt(int.Parse(mas[2]), mas[3]));
            
            break;
        case "SUB"://mas[1] - keyfile, mas[2] - file
            SubMethod.Encryption(mas[1], mas[2]);
            break;
        case "DECRYPT SUB"://mas[2] - keyfile, mas[3] - file
            SubMethod.Decryption(mas[2], mas[3]);
            break;
        case "VIGENERE"://mas[1] - file
            VigenereCD.Crypt(mas[1]);
            Console.WriteLine("Файл зашифрован");
            break;
        case "DECRYPT VIGENERE"://mas[2] - file
            VigenereCD.Decrypt(mas[2]);
            Console.WriteLine("Файл расшфрован");
            break;
        default:
            Console.WriteLine("Нет такой команды!");
            break;


    }





}
while (check != 0);


string CheckCommand (string command)
{
    if (!string.IsNullOrWhiteSpace(command))
    {
        if (Regex.IsMatch(command, @"CAESAR (1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|26|27|28|29|30|31|32|33) ((?:.*\\)?)([\w\s]+\.\w+)$", RegexOptions.IgnoreCase))
        {
            return command;
        } else if (Regex.IsMatch(command, @"DECRYPT CAESAR (1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|26|27|28|29|30|31|32|33) ((?:.*\\)?)([\w\s]+\.\w+)$", RegexOptions.IgnoreCase))
        {
            return command;
        } else if (Regex.IsMatch(command, @"SUB ((?:.*\\)?)([\w\s]+\.\w+) ((?:.*\\)?)([\w\s]+\.\w+)$", RegexOptions.IgnoreCase))
        {
            return command;
        } else if (Regex.IsMatch(command, @"DECRYPT SUB ((?:.*\\)?)([\w\s]+\.\w+) ((?:.*\\)?)([\w\s]+\.\w+)$", RegexOptions.IgnoreCase))
        {
            return command;
        } else if (Regex.IsMatch(command, @"VIGENERE ((?:.*\\)?)([\w\s]+\.\w+)$", RegexOptions.IgnoreCase))
        {
            return command;
        } else if (Regex.IsMatch(command, @"DECRYPT VIGENERE ((?:.*\\)?)([\w\s]+\.\w+)$", RegexOptions.IgnoreCase))
        {
            return command;
        } else if (command == "HELP")
        {
            return command;
        }
    } else
    {
        return "Команда не может быть пустой!";
    }

    return "Нет такой команды или она не верна!";
}
void PrintChoice ()
{
    Console.WriteLine("Команды:");
    Console.WriteLine("CAESAR <KEY> <FILE> - выполняет шифровку файла с помощью шифра Цезаря, используя сдвиг KEY;");
    Console.WriteLine("DECRYPT CAESAR <KEY> <FILE> -выполняет рассшифровку файла с помощью шифра Цезаря, используя сдвиг KEY;");
    Console.WriteLine("SUB <KEYFILE> <FILE> - выполняет шифровку файла FILE методом подстановки, используя в качестве словаря KEYFILE;");
    Console.WriteLine("DECRYPT SUB <KEYFILE> <FILE> - выполняет рассшифровку файла FILE методом подстановки, используя в качестве словаря KEYFILE;");
    Console.WriteLine("VIGENERE <FILE> - выполняет шифровку файла с помощью метода Виженера, использовать квадрат Виженера;");
    Console.WriteLine("DECRYPT VIGENERE <FILE> - выполняет рассшифровку файла FILE с помощью метода Виженера, использовать квадрат Виженера;");

}

