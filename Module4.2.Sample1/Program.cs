// Модуль 4.2 Sample1 — Критическая секция (lock / Monitor)
//
// 1. Без синхронизации — гонка данных при работе с банковским счётом
// 2. lock — простейшая критическая секция
// 3. Monitor — ручное управление (TryEnter, Wait/Pulse)

namespace Module4_2.Sample1;

static class Program
{
    const int ThreadCount = 10;
    const int OperationsPerThread = 100_000;

    static void Main()
    {
        Console.WriteLine("═══ 1. Без синхронизации (гонка данных) ═══\n");
        DemoUnsafe();

        Console.WriteLine("\n═══ 2. lock (критическая секция) ═══\n");
        DemoLock();

        Console.WriteLine("\n═══ 3. Monitor.Enter / Monitor.Exit ═══\n");
        DemoMonitor();

        Console.WriteLine("\n═══ 4. Monitor.TryEnter (с таймаутом) ═══\n");
        DemoTryEnter();
    }

    // ── 1. Без синхронизации ─────────────────────────────

    static void DemoUnsafe()
    {
        var balance = 1000;
        var done = new ManualResetEvent(false);
        var remaining = ThreadCount;

        for (var i = 0; i < ThreadCount; i++)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                for (var j = 0; j < OperationsPerThread; j++)
                {
                    balance += 10;
                    balance -= 10;
                }

                if (Interlocked.Decrement(ref remaining) == 0)
                    done.Set();
            });
        }

        done.WaitOne();
        done.Dispose();

        Console.WriteLine($"  Начальный баланс: 1 000");
        Console.WriteLine($"  Итоговый баланс:  {balance:N0}");
        Console.WriteLine($"  Разница:          {balance - 1000:N0}  (должно быть 0)");
    }

    // ── 2. lock ──────────────────────────────────────────

    static void DemoLock()
    {
        var balance = 1000;
        var lockObj = new object();
        var done = new ManualResetEvent(false);
        var remaining = ThreadCount;

        for (var i = 0; i < ThreadCount; i++)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                for (var j = 0; j < OperationsPerThread; j++)
                {
                    // lock гарантирует, что только один поток
                    // находится внутри блока одновременно
                    lock (lockObj)
                    {
                        balance += 10;
                        balance -= 10;
                    }
                }

                if (Interlocked.Decrement(ref remaining) == 0)
                    done.Set();
            });
        }

        done.WaitOne();
        done.Dispose();

        Console.WriteLine($"  Начальный баланс: 1 000");
        Console.WriteLine($"  Итоговый баланс:  {balance:N0}");
        Console.WriteLine($"  Разница:          {balance - 1000:N0}");
    }

    // ── 3. Monitor.Enter / Monitor.Exit ──────────────────

    static void DemoMonitor()
    {
        var balance = 1000;
        var lockObj = new object();
        var done = new ManualResetEvent(false);
        var remaining = ThreadCount;

        for (var i = 0; i < ThreadCount; i++)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                for (var j = 0; j < OperationsPerThread; j++)
                {
                    // lock — это синтаксический сахар для:
                    var lockTaken = false;
                    try
                    {
                        Monitor.Enter(lockObj, ref lockTaken);
                        balance += 10;
                        balance -= 10;
                    }
                    finally
                    {
                        if (lockTaken)
                            Monitor.Exit(lockObj);
                    }
                }

                if (Interlocked.Decrement(ref remaining) == 0)
                    done.Set();
            });
        }

        done.WaitOne();
        done.Dispose();

        Console.WriteLine($"  Начальный баланс: 1 000");
        Console.WriteLine($"  Итоговый баланс:  {balance:N0}");
        Console.WriteLine($"  Разница:          {balance - 1000:N0}");
    }

    // ── 4. Monitor.TryEnter (с таймаутом) ────────────────

    static void DemoTryEnter()
    {
        var balance = 1000;
        var lockObj = new object();
        var done = new ManualResetEvent(false);
        var remaining = ThreadCount;
        var timeouts = 0;

        for (var i = 0; i < ThreadCount; i++)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                for (var j = 0; j < OperationsPerThread; j++)
                {
                    // TryEnter — попытка захватить с таймаутом.
                    // Если не удалось за 1 мс — пропускаем операцию.
                    if (Monitor.TryEnter(lockObj, millisecondsTimeout: 1))
                    {
                        try
                        {
                            balance += 10;
                            balance -= 10;
                        }
                        finally
                        {
                            Monitor.Exit(lockObj);
                        }
                    }
                    else
                    {
                        Interlocked.Increment(ref timeouts);
                    }
                }

                if (Interlocked.Decrement(ref remaining) == 0)
                    done.Set();
            });
        }

        done.WaitOne();
        done.Dispose();

        Console.WriteLine($"  Начальный баланс: 1 000");
        Console.WriteLine($"  Итоговый баланс:  {balance:N0}");
        Console.WriteLine($"  Таймаутов:        {timeouts:N0} из {ThreadCount * OperationsPerThread:N0}");
    }
}
