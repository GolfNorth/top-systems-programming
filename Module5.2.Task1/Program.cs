using System.Numerics;

namespace Module5._2.Task1;

static class Program
{
    static void Main()
    {
        Console.Write("Введите число для вычисления факториала: ");
        int n = int.Parse(Console.ReadLine()!);

        if (n < 0)
        {
            Console.WriteLine("Факториал отрицательного числа не определён.");
            return;
        }

        Console.WriteLine($"\n--- Parallel.Invoke ---");
        Console.WriteLine($"{n}! = {FactorialInvoke(n)}");

        Console.WriteLine($"\n--- Parallel.For ---");
        Console.WriteLine($"{n}! = {FactorialFor(n)}");

        Console.WriteLine($"\n--- Parallel.ForEach ---");
        Console.WriteLine($"{n}! = {FactorialForEach(n)}");
    }

    // ── Parallel.Invoke ─────────────────────────────────────────────
    // Создаём массив Action[], каждый Action перемножает свой диапазон.

    static BigInteger FactorialInvoke(int n)
    {
        if (n <= 1)
            return 1;

        int partCount = Environment.ProcessorCount;
        BigInteger[] partials = new BigInteger[partCount];
        Action[] actions = new Action[partCount];

        for (int i = 0; i < partCount; i++)
        {
            int index = i;
            int from = index * n / partCount + 1;
            int to = (index + 1) * n / partCount;
            actions[index] = () =>
            {
                Console.WriteLine($"  [Поток {Environment.CurrentManagedThreadId}] {from}..{to}");
                partials[index] = MultiplyRange(from, to);
            };
        }

        Parallel.Invoke(actions);
        return CombinePartials(partials);
    }

    // ── Parallel.For ────────────────────────────────────────────────
    // Parallel.For разбивает диапазон индексов между потоками.

    static BigInteger FactorialFor(int n)
    {
        if (n <= 1)
            return 1;

        int partCount = Environment.ProcessorCount;
        BigInteger[] partials = new BigInteger[partCount];

        Parallel.For(0, partCount, i =>
        {
            int from = i * n / partCount + 1;
            int to = (i + 1) * n / partCount;
            Console.WriteLine($"  [Поток {Environment.CurrentManagedThreadId}] {from}..{to}");
            partials[i] = MultiplyRange(from, to);
        });

        return CombinePartials(partials);
    }

    // ── Parallel.ForEach ────────────────────────────────────────────
    // ForEach обходит коллекцию диапазонов параллельно.

    static BigInteger FactorialForEach(int n)
    {
        if (n <= 1)
            return 1;

        int partCount = Environment.ProcessorCount;
        BigInteger[] partials = new BigInteger[partCount];

        // Готовим список диапазонов (index, from, to)
        var ranges = new (int Index, int From, int To)[partCount];
        for (int i = 0; i < partCount; i++)
            ranges[i] = (i, i * n / partCount + 1, (i + 1) * n / partCount);

        Parallel.ForEach(ranges, range =>
        {
            Console.WriteLine($"  [Поток {Environment.CurrentManagedThreadId}] {range.From}..{range.To}");
            partials[range.Index] = MultiplyRange(range.From, range.To);
        });

        return CombinePartials(partials);
    }

    // ── Общие вспомогательные методы ────────────────────────────────

    static BigInteger MultiplyRange(int from, int to)
    {
        BigInteger product = 1;
        for (int x = from; x <= to; x++)
            product *= x;
        return product;
    }

    static BigInteger CombinePartials(BigInteger[] partials)
    {
        BigInteger result = 1;
        for (int i = 0; i < partials.Length; i++)
            result *= partials[i];
        return result;
    }
}
