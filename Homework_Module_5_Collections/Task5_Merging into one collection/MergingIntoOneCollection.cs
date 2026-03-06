namespace Homework_Module_5_Collections.Task5_Merging_into_one_collection;

public class MergingIntoOneCollection
{
    public void Run()
    {
        //Есть два массива строк. Надо их объединить в одну коллекцию, исключив повторения, не используя Linq.
        //Пример: {"1", "2", "1"} + {"3", "2"} => {"1", "2", "3"}

        string[] array1 = { "10", "1", "2", "4", "2", "6", "6", "6", "6", "18", "2", "1", "1" };
        string[] array2 = { "3", "2", "5", "7", "4", "18", "3", "7", "7", "3", "9" };

        List<string> list = ArraysToList(array1, array2);

        foreach (var element in list)
            Console.Write(element + " | ");
    }

    static List<string> ArraysToList(string[] array1, string[] array2)
    {
        List<string> list = new();

        foreach (var str in array1)
        {
            if (!list.Contains(str))
            {
                list.Add(str);
            }
        }

        foreach (var str in array2)
        {
            if (!list.Contains(str))
            {
                list.Add(str);
            }
        }

        return list;
    }
}