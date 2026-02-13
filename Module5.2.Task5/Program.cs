namespace Module5._2.Task5;

static class Program
{
    const string DataFile = "numbers.txt";

    static void Main()
    {
        GenerateFile(DataFile, count: 100);

        List<int> numbers = ReadNumbers(DataFile);
        Console.WriteLine($"Считано {numbers.Count} чисел из {DataFile}\n");

        int sum = numbers.AsParallel().Sum();
        int max = numbers.AsParallel().Max();
        int min = numbers.AsParallel().Min();

        Console.WriteLine($"Сумма:   {sum}");
        Console.WriteLine($"Максимум: {max}");
        Console.WriteLine($"Минимум:  {min}");
    }

    static List<int> ReadNumbers(string path)
    {
        List<int> numbers = new();
        foreach (string line in File.ReadLines(path))
        {
            if (int.TryParse(line.Trim(), out int value))
                numbers.Add(value);
        }
        return numbers;
    }

    static void GenerateFile(string path, int count)
    {
        Random rng = new(42);
        using StreamWriter writer = new(path);
        for (int i = 0; i < count; i++)
            writer.WriteLine(rng.Next(-1000, 1001));

        Console.WriteLine($"Сгенерирован файл {path} ({count} чисел)");
    }
}
