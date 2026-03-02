namespace Homework_Module_5_Collections.Task3_Dynamic_Array_Advanced;

public class DynamicArrayAdvanced
{
    public void Run()
    {
        //В массивах вы выполняли задание "[Динамический массив]
        //Используя всё изученное, напишите улучшенную версию динамического массива(не обязательно брать своё старое решение)
        //Задание нужно, чтобы вы освоились с List и прощупали его преимущество.Проверка на ввод числа обязательна.
        //Пользователь вводит числа, и программа их запоминает.
        //Как только пользователь введёт команду sum, программа выведет сумму всех введенных чисел.
        //Выход из программы должен происходить только в том случае, если пользователь введёт команду exit.

        const string COMMAND_SUM = "sum";
        const string COMMAND_EXIT = "exit";
        
        List<int> numbers = new();
        
        bool isWorking = true;

        while (isWorking)
        {
            PrintNumbers(ref numbers);
            
            string userInput = GetInput("\nВведите число или команду (sum/exit): ");

            switch (userInput)
            {
                case COMMAND_SUM:
                    Console.Clear();
                    Console.WriteLine("Сумма чисел: " + SumNumbers(ref numbers));
                    break;
                
                case COMMAND_EXIT:
                    isWorking = false;
                    break;
                
                default:
                    AddNumbers(ref userInput, ref numbers);
                    break;
            }
        }
    }
    
    static string GetInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine().Trim();
    }

    static int SumNumbers(ref List<int> list)
    {
        int sum = 0;

        foreach (var number in list)
            sum += number;
        
        return sum;
    }
    
    static void PrintNumbers(ref List<int> list)
    {
        foreach (var number in list)
            Console.Write(number + " ");
    }

    static void AddNumbers(ref string userInput, ref List<int> numbers)
    {
        if (int.TryParse(userInput, out int userNumber))
        {
            numbers.Add(userNumber);
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Не правильно введено число/команда!");
        }
    }
}