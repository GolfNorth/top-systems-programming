// Модуль 4 Задание 1 — Mutex + ThreadPool
//
// Два потока из пула с синхронизацией через Mutex:
// 1-й выводит числа 0..20 по возрастанию, освобождает мьютекс
// 2-й ждёт мьютекс, затем выводит 10..0 по убыванию

namespace Module4.Task1;

static class Program
{
    static readonly Mutex Mutex = new();
    static readonly ManualResetEvent AllDone = new(false);

    static void Main()
    {
        ThreadPool.QueueUserWorkItem(CountUp);
        ThreadPool.QueueUserWorkItem(CountDown);

        AllDone.WaitOne();

        Mutex.Dispose();
        AllDone.Dispose();
    }

    static void CountUp(object? state)
    {
        Mutex.WaitOne();

        try
        {
            Console.WriteLine($"[Поток {Environment.CurrentManagedThreadId}] Счёт вверх:");
            for (var i = 0; i <= 20; i++)
            {
                Console.WriteLine($"  {i}");
                Thread.Sleep(100);
            }
        }
        finally
        {
            Mutex.ReleaseMutex();
        }
    }

    static void CountDown(object? state)
    {
        Mutex.WaitOne();
        try
        {
            Console.WriteLine($"[Поток {Environment.CurrentManagedThreadId}] Счёт вниз:");
            for (var i = 10; i >= 0; i--)
            {
                Console.WriteLine($"  {i}");
                Thread.Sleep(100);
            }
        }
        finally
        {
            Mutex.ReleaseMutex();
            AllDone.Set();
        }
    }
}
