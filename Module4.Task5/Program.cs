// Модуль 4 Задание 5 — Semaphore + ThreadPool
//
// 10 потоков, одновременно работают не более 3.
// Каждый выводит ID потока и набор случайных чисел.
// Семафор ограничивает параллелизм.

namespace Module4.Task5;

static class Program
{
    static readonly Semaphore Semaphore = new(3, 3);
    static readonly ManualResetEvent AllDone = new(false);
    static int _remaining = 10;

    static void Main()
    {
        for (var i = 1; i <= 10; i++)
        {
            var taskId = i;
            ThreadPool.QueueUserWorkItem(_ => DoWork(taskId));
        }

        AllDone.WaitOne();

        Semaphore.Dispose();
        AllDone.Dispose();

        Console.WriteLine("\nВсе потоки завершены.");
    }

    static void DoWork(int taskId)
    {
        Semaphore.WaitOne();
        try
        {
            var threadId = Environment.CurrentManagedThreadId;
            Console.WriteLine($"[Задача {taskId,2}, поток {threadId,2}] Начало работы");

            var random = new Random();
            var numbers = new int[5];
            for (var i = 0; i < numbers.Length; i++)
                numbers[i] = random.Next(1, 100);

            Thread.Sleep(random.Next(500, 1500));

            Console.WriteLine($"[Задача {taskId,2}, поток {threadId,2}] Числа: {string.Join(", ", numbers)}");
        }
        finally
        {
            Semaphore.Release();

            if (Interlocked.Decrement(ref _remaining) == 0)
                AllDone.Set();
        }
    }
}
