namespace Homework_Module_5_Collections.Task5_Merging_into_one_collection;

public class MergingIntoOneCollection
{
    public void Run()
    {
        //Есть два массива строк. Надо их объединить в одну коллекцию, исключив повторения, не используя Linq.
        //Пример: {"1", "2", "1"} + {"3", "2"} => {"1", "2", "3"}
        
        string[] array1 = { "1", "2", "4", "2", "6", "6", "6", "6", "2", "1", "1" };
        string[] array2 = { "3", "2", "5", "7", "4", "3", "7", "7", "3", "9" };

        List<string> list = array1.ToList();
        
        list.AddRange(array2.ToList());
        
        list.Sort();

        for (int i = 0; i < list.Count - 1; i++)
        {
            if (list[i] == list[i + 1])
            {
                list.RemoveAt(i);
                i--;
            }
        }
        
        foreach (var element in list)
            Console.Write(element + " | ");
    }
}