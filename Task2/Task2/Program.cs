using System.IO;
  

// Task 2 № 36, т.к в 8 не понял что необходимо сделать
class Program
{
    static int TextSize(string Name)
    {
        if (!File.Exists(Name))
        {
            return -1;
        }

        int count = 0;
        using (StreamReader reader = new StreamReader(Name))
        {
            while (reader.ReadLine() != null)
            {
                count++;
            }
        }

        return count;
    }

    static void Main()
    {
        int size = TextSize("D:\\Denis\\Учеба\\ИТ\\Task2\\test1.txt");
        if (size == -1)
        {
            Console.WriteLine("Файл не существует");
        }
        else
        {
            Console.WriteLine("Количество строк: " + size);
        }
        size = TextSize("D:\\Denis\\Учеба\\ИТ\\Task2\\test2.txt");
        if (size == -1)
        {
            Console.WriteLine("Файл не существует");
        }
        else
        {
            Console.WriteLine("Количество строк: " + size);
        }
        size = TextSize("D:\\Denis\\Учеба\\ИТ\\Task2\\test3.txt");
        if (size == -1)
        {
            Console.WriteLine("Файл не существует");
        }
        else
        {
            Console.WriteLine("Количество строк: " + size);
        }
        size = TextSize("D:\\Denis\\Учеба\\ИТ\\Task2\\test22.txt");
        if (size == -1)
        {
            Console.WriteLine("Файл не существует");
        }
        else
        {
            Console.WriteLine("Количество строк: " + size);
        }
    }
}