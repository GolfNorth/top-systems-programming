namespace Module5._2.Sample1;

static class Program
{
    static void Main()
    {
        DemoInvoke();
        DemoFor();
        DemoForEach();
    }

    // ── Parallel.Invoke ─────────────────────────────────────────────
    // Запускает несколько независимых действий параллельно.
    // Удобно, когда есть фиксированный набор задач.

    static void DemoInvoke()
    {
        Console.WriteLine("=== Parallel.Invoke ===\n");

        Parallel.Invoke(
            BoilWater,
            CutVegetables,
            FryMeat
        );

        Console.WriteLine("Все этапы готовки завершены!\n");
    }

    static void BoilWater()
    {
        Console.WriteLine($"[Поток {Environment.CurrentManagedThreadId}] Кипятим воду...");
        Thread.Sleep(1000);
        Console.WriteLine($"[Поток {Environment.CurrentManagedThreadId}] Вода вскипела.");
    }

    static void CutVegetables()
    {
        Console.WriteLine($"[Поток {Environment.CurrentManagedThreadId}] Режем овощи...");
        Thread.Sleep(800);
        Console.WriteLine($"[Поток {Environment.CurrentManagedThreadId}] Овощи нарезаны.");
    }

    static void FryMeat()
    {
        Console.WriteLine($"[Поток {Environment.CurrentManagedThreadId}] Жарим мясо...");
        Thread.Sleep(1200);
        Console.WriteLine($"[Поток {Environment.CurrentManagedThreadId}] Мясо готово.");
    }

    // ── Parallel.For ────────────────────────────────────────────────
    // Параллельный аналог for(int i = from; i < to; i++).
    // Разбивает диапазон индексов между потоками.

    static void DemoFor()
    {
        Console.WriteLine("=== Parallel.For ===\n");

        int[] numbers = new int[10];

        Parallel.For(0, numbers.Length, ComputeSquare);

        Console.WriteLine();
        Console.WriteLine("Результат: " + string.Join(", ", numbers));
        Console.WriteLine();

        void ComputeSquare(int i)
        {
            Console.WriteLine($"[Поток {Environment.CurrentManagedThreadId}] i={i}");
            numbers[i] = i * i;
        }
    }

    // ── Parallel.ForEach ────────────────────────────────────────────
    // Параллельный аналог foreach. Работает с любым IEnumerable<T>.

    static void DemoForEach()
    {
        Console.WriteLine("=== Parallel.ForEach ===\n");

        string[] cities = { "Москва", "Лондон", "Токио", "Нью-Йорк", "Берлин", "Париж" };

        Parallel.ForEach(cities, PrintWeather);

        Console.WriteLine("\nПрогноз для всех городов получен!\n");
    }

    static void PrintWeather(string city)
    {
        // Имитация запроса к внешнему сервису
        Thread.Sleep(500);
        int temp = Random.Shared.Next(-10, 35);
        Console.WriteLine($"[Поток {Environment.CurrentManagedThreadId}] {city}: {temp}°C");
    }
}
