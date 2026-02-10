// Модуль 4 Sample1 — Interlocked + ThreadPool
//
// Демонстрация гонки данных (race condition) при конкурентном
// инкременте счётчика и решение через Interlocked.

namespace Module4.Sample1;

static class Program
{
    const int ThreadCount = 10;
    const int IncrementsPerThread = 100_000;
    static readonly int Expected = ThreadCount * IncrementsPerThread;

    static void Main()
    {
        DemoUnsafe();
        DemoIncrement();
        DemoAdd();
        DemoCompareExchange();
    }

    // ── 1. Без синхронизации (race condition) ────────────────

    static void DemoUnsafe()
    {
        var counter = 0;
        var done = new CountdownEvent(ThreadCount);

        for (var i = 0; i < ThreadCount; i++)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                for (var j = 0; j < IncrementsPerThread; j++)
                    counter++; // не атомарно: read → increment → write

                done.Signal();
            });
        }

        done.Wait();

        Console.WriteLine("═══ Без синхронизации ═══");
        Console.WriteLine($"  Ожидалось:  {Expected:N0}");
        Console.WriteLine($"  Получено:   {counter:N0}");
        Console.WriteLine($"  Потеряно:   {Expected - counter:N0}");
        Console.WriteLine();
    }

    // ── 2. Interlocked.Increment ─────────────────────────────

    static void DemoIncrement()
    {
        var counter = 0;
        var done = new CountdownEvent(ThreadCount);

        for (var i = 0; i < ThreadCount; i++)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                for (var j = 0; j < IncrementsPerThread; j++)
                    Interlocked.Increment(ref counter); // атомарная операция

                done.Signal();
            });
        }

        done.Wait();

        Console.WriteLine("═══ Interlocked.Increment ═══");
        Console.WriteLine($"  Ожидалось:  {Expected:N0}");
        Console.WriteLine($"  Получено:   {counter:N0}");
        Console.WriteLine($"  Потеряно:   {Expected - counter:N0}");
        Console.WriteLine();
    }

    // ── 3. Interlocked.Add ───────────────────────────────────

    static void DemoAdd()
    {
        var sum = 0;
        var done = new CountdownEvent(ThreadCount);

        for (var i = 0; i < ThreadCount; i++)
        {
            var threadId = i + 1;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                var localSum = 0;
                for (var j = 0; j < IncrementsPerThread; j++)
                    localSum++;

                Interlocked.Add(ref sum, localSum);
                Console.WriteLine($"  Поток {threadId,2} добавил {localSum:N0}, текущая сумма: {sum:N0}");
                done.Signal();
            });
        }

        done.Wait();

        Console.WriteLine($"\n═══ Interlocked.Add ═══");
        Console.WriteLine($"  Итого: {sum:N0}");
        Console.WriteLine();
    }

    // ── 4. Interlocked.CompareExchange (lock-free максимум) ──

    static void DemoCompareExchange()
    {
        var max = 0;
        var done = new CountdownEvent(ThreadCount);
        var random = new Random(42);
        var values = new int[ThreadCount];

        for (var i = 0; i < ThreadCount; i++)
            values[i] = random.Next(1, 10_000);

        for (var i = 0; i < ThreadCount; i++)
        {
            var value = values[i];
            var threadId = i + 1;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                // Lock-free обновление максимума через CAS-цикл
                int current;
                do
                {
                    current = max;
                    if (value <= current)
                        break;
                }
                while (Interlocked.CompareExchange(ref max, value, current) != current);

                Console.WriteLine($"  Поток {threadId,2}: значение = {value,5}, max = {max}");
                done.Signal();
            });
        }

        done.Wait();

        Console.WriteLine($"\n═══ Interlocked.CompareExchange (lock-free max) ═══");
        Console.WriteLine($"  Максимум:  {max:N0}");
        Console.WriteLine($"  Проверка:  {values.Max():N0}");
    }
}
