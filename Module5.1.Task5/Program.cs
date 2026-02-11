// Модуль 5.1 Задание 5 — Continuation Tasks
//
// Цепочка задач через ContinueWith:
// 1. Удаление дубликатов
// 2. Сортировка (после удаления)
// 3. Бинарный поиск (после сортировки)

namespace Module5_1.Task5;

static class Program
{
    static void Main()
    {
        var random = new Random(42);
        var data = new int[20];
        for (var i = 0; i < data.Length; i++)
            data[i] = random.Next(1, 15); // маленький диапазон → будут дубли

        Console.WriteLine($"Исходный массив ({data.Length} элементов):");
        Console.WriteLine($"  [{string.Join(", ", data)}]\n");

        var searchValue = data[random.Next(data.Length)];
        Console.WriteLine($"Ищем значение: {searchValue}\n");

        var pipeline = Task.Run(() => RemoveDuplicates(data))
            .ContinueWith(prev => Sort(prev.Result))
            .ContinueWith(prev => BinarySearch(prev.Result, searchValue));

        pipeline.Wait();
    }

    static int[] RemoveDuplicates(int[] data)
    {
        Console.WriteLine($"[Поток {Environment.CurrentManagedThreadId}] Удаление дубликатов...");

        var unique = new List<int>();
        var seen = new HashSet<int>();

        foreach (var item in data)
        {
            if (seen.Add(item))
                unique.Add(item);
        }

        var result = unique.ToArray();
        Console.WriteLine($"  Результат ({result.Length} элементов): [{string.Join(", ", result)}]\n");
        return result;
    }

    static int[] Sort(int[] data)
    {
        Console.WriteLine($"[Поток {Environment.CurrentManagedThreadId}] Сортировка...");

        var sorted = (int[])data.Clone();
        Array.Sort(sorted);

        Console.WriteLine($"  Результат: [{string.Join(", ", sorted)}]\n");
        return sorted;
    }

    static void BinarySearch(int[] sortedData, int value)
    {
        Console.WriteLine($"[Поток {Environment.CurrentManagedThreadId}] Бинарный поиск значения {value}...");

        var index = Array.BinarySearch(sortedData, value);

        if (index >= 0)
            Console.WriteLine($"  Найдено на позиции {index}");
        else
            Console.WriteLine($"  Не найдено (insertion point: {~index})");
    }
}
