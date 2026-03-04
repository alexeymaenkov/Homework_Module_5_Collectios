namespace Homework_Module_5_Collections.Task4_Advanced_personnel_accounting;

public class AdvancedPersonnelAccounting
{
    public void Run()
    {
        //Перерабатываем задание “[Кадровый учет].
        //У нас может быть множество должностей, без повторений. На одной должности может быть несколько сотрудников (их полное имя).
        //Вам надо реализовать:
        //1. Добавление сотрудника (при отсутствии должности, она добавляется)
        //2. Удаление сотрудника. (при отсутствии у должности каких либо сотрудников, должность также удаляется)
        //3. Показ полной информации (показ всех должностей и сотрудников по этой должности)

        const string COMMAND_ADD_WORKER = "1";
        const string COMMAND_DELETE_WORKER = "2";
        const string COMMAND_SHOW_INFORMATION = "3";
        const string COMMAND_EXIT = "4";

        Dictionary<string, List<string>> workers = new();

        bool isWorking = true;

        while (isWorking)
        {
            Console.WriteLine("Команды работы с базой сотрудников:");
            Console.WriteLine($"{COMMAND_ADD_WORKER} - добавить сотрудника.");
            Console.WriteLine($"{COMMAND_DELETE_WORKER} - удалить сотрудника.");
            Console.WriteLine($"{COMMAND_SHOW_INFORMATION} - вывести все досье.");
            Console.WriteLine($"{COMMAND_EXIT} - выход.");

            string userCommand = GetInput("Введите номер команды: ");

            switch (userCommand)
            {
                case COMMAND_ADD_WORKER:
                    AddWorker(workers);
                    break;

                case COMMAND_DELETE_WORKER:
                    DeleteWorker(workers);
                    break;

                case COMMAND_SHOW_INFORMATION:
                    ShowInformation(workers);
                    break;

                case COMMAND_EXIT:
                    isWorking = false;
                    break;

                default:
                    OutputError("Ошибка ввода команды! Попробуйте еще раз:");
                    break;
            }
        }
    }

    static void AddWorker(Dictionary<string, List<string>> workers)
    {
        string newWorkerName = GetInput("Введите ФИО сотрудника: ");

        if (string.IsNullOrWhiteSpace(newWorkerName))
        {
            OutputError("Ошибка! Не верный ввод ФИО сотрудника.\n");
            return;
        }

        string newJob = GetInput("Введите должность сотрудника: ");

        if (string.IsNullOrWhiteSpace(newJob))
        {
            OutputError("Ошибка! Не верный ввод должности сотрудника.\n");
            return;
        }

        if (!workers.ContainsKey(newJob))
        {
            workers[newJob] = new List<string>();
        }

        workers[newJob].Add(newWorkerName);

        OutputSuccess("Сотрудник успешно добавлен.\n");
    }

    static void DeleteWorker(Dictionary<string, List<string>> workers)
    {
        if (workers.Keys.Count == 0)
        {
            OutputError("База сотрудников пуста!\n");
            return;
        }

        string deleteWorkerName = GetInput("Введите ФИО сотрудника, которого нужно удалить: ");

        if (string.IsNullOrWhiteSpace(deleteWorkerName))
        {
            OutputError("Ошибка! Не верный ввод ФИО сотрудника.\n");
            return;
        }

        foreach (var worker in workers.ToList())
        {
            for (int j = 0; j < worker.Value.Count; j++)
            {
                if (worker.Value[j] == deleteWorkerName)
                {
                    worker.Value.RemoveAt(j);
                }

                if (worker.Value.Count == 0)
                {
                    workers.Remove(worker.Key);
                }
            }
        }

        OutputSuccess("Сотрудник успешно удален.\n");
    }

    static void ShowInformation(Dictionary<string, List<string>> workers)
    {
        foreach (var worker in workers)
        {
            Console.Write($"Должность: {worker.Key} ");

            foreach (var name in worker.Value)
                Console.Write($"ФИО: {name}" + " || ");

            Console.WriteLine();
        }
    }

    static void OutputSuccess(string message)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    static void OutputError(string message)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    static string GetInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine().Trim();
    }
}