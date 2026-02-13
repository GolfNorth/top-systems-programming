namespace Module5._2.Task3;

static class Program
{
    const string OutputFile = "multiplication.txt";

    static void Main()
    {
        Console.Write("Введите начало диапазона: ");
        int from = int.Parse(Console.ReadLine()!);

        Console.Write("Введите конец диапазона: ");
        int to = int.Parse(Console.ReadLine()!);

        // Для каждого числа из диапазона формируем таблицу умножения.
        // Parallel.For может выполнять итерации в произвольном порядке,
        // поэтому сначала собираем результаты в массив, затем пишем в файл.

        string[] tables = new string[to - from + 1];

        Parallel.For(from, to + 1, number =>
        {
            Console.WriteLine($"[Поток {Environment.CurrentManagedThreadId}] " +
                              $"таблица для {number}");
            tables[number - from] = BuildTable(number);
        });

        string result = string.Join(Environment.NewLine, tables);
        File.WriteAllText(OutputFile, result);

        Console.WriteLine($"\nТаблица умножения записана в {Path.GetFullPath(OutputFile)}");
        Console.WriteLine();
        Console.Write(result);
    }

    static string BuildTable(int number)
    {
        string[] lines = new string[10];
        for (int i = 1; i <= 10; i++)
            lines[i - 1] = $"{number} * {i} = {number * i}";
        return string.Join(Environment.NewLine, lines);
    }
}
