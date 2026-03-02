namespace Homework_Module_5_Collections.Task1_Explanatory_dictionary;

public class ExplanatoryDictionary
{
    public void Run()
    {
        //Создать программу, которая принимает от пользователя слово и выводит его значение.
        //Если такого слова нет, то следует вывести соответствующее сообщение.

        var watches = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            ["Longines"] = 1832,
            ["Breitling"] = 1884,
            ["Ball"] = 1891,
            ["Oris"] = 1904,
            ["Rolex"] = 1905
        };

        while (true)
        {
            string userInput = GetInput("Введите название бренда часов: ");

            SearchValue(ref watches, ref userInput);
        }
    }
    
    static string GetInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }
    
    static void SearchValue(ref Dictionary<string, int> dictionary, ref string userInput)
    {
        if (dictionary.TryGetValue(userInput, out int value))
        {
            Console.WriteLine($"Год основания бренда: {value}");
        }
        else
        {
            OutputError("Такого бренда нет в каталоге.");
        }
    }
    
    static void OutputError(string message)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}