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
        
        Queue<int> purchases = new(10);

        int storePersonalAccount = 0;
        
        for ( int i = 0; i < purchases.Capacity; i++)
        {
            int purchase = new Random().Next(1, 30);
            purchases.Enqueue(purchase);
        }
        
        while (purchases.Count > 0)
        {
            ShowInformation(ref purchases, ref storePersonalAccount);

            ServeClient(ref purchases, ref storePersonalAccount);

            Console.Write("\nПродолжить? ");
            Console.ReadKey();
            Console.Clear();
        }
    }
    
    static void ShowInformation(ref Queue<int> purchases, ref int storePersonalAccount)
    {
        Console.Write("Очередь покупателей: ");
        
        foreach (int purcase in purchases)
            Console.Write(purcase + " | ");

        Console.WriteLine($"\nСумма лицевого счете: {storePersonalAccount}");
    }

    static void ServeClient(ref Queue<int> purchases, ref int storePersonalAccount)
    {
        Console.WriteLine($"Следующий клиент в очереди с покупкой на сумму: {purchases.Peek()}");
        
        Console.Write("Обслужить клиента?");
        Console.ReadKey();
        
        storePersonalAccount += purchases.Dequeue();
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nКлиент обслужен!");
        Console.ResetColor();
    }
}