// Модуль 5.1 Задание 4 — массив Task
//
// Четыре задачи параллельно ищут в массиве:
// минимум, максимум, среднее, сумму.
// Task.WaitAll ожидает завершения всех.

namespace Module5_1.Task4;

static class Program
{
    static void Main()
    {
        var random = new Random(42);
        var data = new int[1_000_000];
        for (var i = 0; i < data.Length; i++)
            data[i] = random.Next(-10_000, 10_001);

        Console.WriteLine($"Массив: {data.Length:N0} элементов\n");

        var tasks = new Task[]
        {
            Task.Run(() => FindMin(data)),
            Task.Run(() => FindMax(data)),
            Task.Run(() => FindSum(data)),
            Task.Run(() => FindAverage(data)),
        };

        Task.WaitAll(tasks);

        Console.WriteLine("\nВсе задачи завершены.");
    }

    static void FindMin(int[] data)
    {
        var min = data[0];
        for (var i = 1; i < data.Length; i++)
        {
            if (data[i] < min)
                min = data[i];
        }

        Console.WriteLine($"  [Поток {Environment.CurrentManagedThreadId}] Минимум:  {min:N0}");
    }

    static void FindMax(int[] data)
    {
        var max = data[0];
        for (var i = 1; i < data.Length; i++)
        {
            if (data[i] > max)
                max = data[i];
        }

        Console.WriteLine($"  [Поток {Environment.CurrentManagedThreadId}] Максимум: {max:N0}");
    }

    static void FindSum(int[] data)
    {
        var sum = 0L;
        for (var i = 0; i < data.Length; i++)
            sum += data[i];

        Console.WriteLine($"  [Поток {Environment.CurrentManagedThreadId}] Сумма:    {sum:N0}");
    }

    static void FindAverage(int[] data)
    {
        var sum = 0L;
        for (var i = 0; i < data.Length; i++)
            sum += data[i];

        var average = (double)sum / data.Length;
        Console.WriteLine($"  [Поток {Environment.CurrentManagedThreadId}] Среднее:  {average:F2}");
    }
}
