namespace Module5._2.Task5;

static class Program
{
    const string DataFile = "numbers.txt";

    static void Main()
    {
        GenerateFile(DataFile, count: 100);

        List<int> numbers = ReadNumbers(DataFile);
        Console.WriteLine($"Считано {numbers.Count} чисел из {DataFile}");

        Console.WriteLine("\n--- Вариант 1: Parallel.Invoke + PLINQ ---\n");
        DemoParallelInvoke(numbers);

        Console.WriteLine("\n--- Вариант 2: PLINQ Aggregate (один проход) ---\n");
        DemoAggregate(numbers);
    }

    // ── Вариант 1 ───────────────────────────────────────────────────
    // Три PLINQ-запроса запускаются параллельно через Parallel.Invoke.
    // Каждый запрос сам по себе параллелен (AsParallel),
    // а Invoke позволяет не ждать завершения одного, чтобы начать другой.

    static void DemoParallelInvoke(List<int> numbers)
    {
        int sum = 0, max = 0, min = 0;

        Parallel.Invoke(
            () => sum = numbers.AsParallel().Sum(),
            () => max = numbers.AsParallel().Max(),
            () => min = numbers.AsParallel().Min()
        );

        Console.WriteLine($"Сумма:    {sum}");
        Console.WriteLine($"Максимум: {max}");
        Console.WriteLine($"Минимум:  {min}");
    }

    // ── Вариант 2 ───────────────────────────────────────────────────
    // Один параллельный проход по коллекции.
    // PLINQ разбивает список на партиции (по числу ядер).
    // Каждая партиция обрабатывается в своём потоке.
    // В конце результаты партиций объединяются.
    //
    // Aggregate принимает 4 параметра:
    //   1) seedFactory        — начальное значение для каждой партиции
    //   2) updateAccumulator  — обработка одного элемента внутри партиции
    //   3) combineAccumulators — слияние результатов двух партиций
    //   4) resultSelector     — финальное преобразование итога

    static void DemoAggregate(List<int> numbers)
    {
        var result = numbers.AsParallel().Aggregate(

            // 1) seedFactory: вызывается для КАЖДОЙ партиции отдельно.
            //    Создаёт начальный аккумулятор: сумма = 0, max = минимально возможное, min = максимально возможное.
            () => (Sum: 0L, Max: int.MinValue, Min: int.MaxValue),

            // 2) updateAccumulator: вызывается для каждого числа в партиции.
            //    Обновляет аккумулятор партиции: прибавляет к сумме, сравнивает с max/min.
            (acc, number) =>
            {
                acc.Sum += number;
                if (number > acc.Max) acc.Max = number;
                if (number < acc.Min) acc.Min = number;
                return acc;
            },

            // 3) combineAccumulators: вызывается после завершения всех партиций.
            //    Объединяет результаты двух партиций в один: суммы складываются, max/min сравниваются.
            (acc1, acc2) => (
                Sum: acc1.Sum + acc2.Sum,
                Max: Math.Max(acc1.Max, acc2.Max),
                Min: Math.Min(acc1.Min, acc2.Min)
            ),

            // 4) resultSelector: финальное преобразование (здесь просто возвращаем как есть).
            acc => acc
        );

        Console.WriteLine($"Сумма:    {result.Sum}");
        Console.WriteLine($"Максимум: {result.Max}");
        Console.WriteLine($"Минимум:  {result.Min}");
    }

    // ── Вспомогательные методы ───────────────────────────────────────

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
