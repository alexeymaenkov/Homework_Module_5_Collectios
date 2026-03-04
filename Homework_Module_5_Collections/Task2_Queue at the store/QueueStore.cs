namespace Homework_Module_5_Collections.Task2_Queue_at_the_store;

public class QueueStore
{
    public void Run()
    {
        //У вас есть множество целых чисел. Каждое целое число - это сумма покупки.
        //Вам нужно обслуживать клиентов до тех пор, пока очередь не станет пуста.
        //После каждого обслуженного клиента деньги нужно добавлять на наш счёт и выводить его в консоль.
        //После обслуживания каждого клиента программа ожидает нажатия любой клавиши, после чего затирает
        //консоль и по новой выводит всю информацию, только уже со следующим клиентом

        int queueCapacity = 10;
        int minQueueValue = 10;
        int maxQueueValue = 30;
        int storePersonalAccount = 0;

        Queue<int> purchases = GenerateQueue(queueCapacity, minQueueValue, maxQueueValue);

        while (purchases.Count > 0)
        {
            ShowInformation(purchases);

            Console.WriteLine($"\nСумма лицевого счете: {storePersonalAccount}");

            storePersonalAccount += ServeClient(purchases);

            Console.Write("\nПродолжить? ");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static Queue<int> GenerateQueue(int queueCapacity, int minQueueValue, int maxQueueValue)
    {
        Queue<int> purchases = new();

        for (int i = 0; i < queueCapacity; i++)
        {
            int purchase = new Random().Next(minQueueValue, maxQueueValue);
            purchases.Enqueue(purchase);
        }

        return purchases;
    }

    static void ShowInformation(Queue<int> purchases)
    {
        Console.Write("Очередь покупателей: ");

        foreach (int purcase in purchases)
            Console.Write(purcase + " | ");
    }

    static int ServeClient(Queue<int> purchases)
    {
        int accountIncrease = 0;

        Console.WriteLine($"Следующий клиент в очереди с покупкой на сумму: {purchases.Peek()}");

        Console.Write("Обслужить клиента?");
        Console.ReadKey();

        accountIncrease += purchases.Dequeue();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nКлиент обслужен!");
        Console.ResetColor();

        return accountIncrease;
    }
}