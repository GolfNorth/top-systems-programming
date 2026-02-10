// Модуль 4.2 Задание 1 — ManualResetEvent
//
// Генератор создаёт 1000 случайных чисел (0..5000).
// Три потока-анализатора ждут события (ManualResetEvent).
// После генерации событие сигналит — все три стартуют одновременно:
//   1) максимум  2) минимум  3) среднее арифметическое

namespace Module4_2.Task1;

static class Program
{
    static readonly ManualResetEvent DataReady = new(false);
    static readonly ManualResetEvent AllDone = new(false);
    static int _remaining = 3;

    static int[] _numbers = [];

    static void Main()
    {
        ThreadPool.QueueUserWorkItem(Generate);
        ThreadPool.QueueUserWorkItem(FindMax);
        ThreadPool.QueueUserWorkItem(FindMin);
        ThreadPool.QueueUserWorkItem(FindAverage);

        AllDone.WaitOne();

        DataReady.Dispose();
        AllDone.Dispose();
    }

    static void Generate(object? state)
    {
        Console.WriteLine($"[Поток {Environment.CurrentManagedThreadId}] Генерация 1000 чисел...");

        var random = new Random();
        _numbers = new int[1000];

        for (var i = 0; i < _numbers.Length; i++)
        {
            _numbers[i] = random.Next(0, 5001);
        }

        Thread.Sleep(500); // имитация длительной генерации

        Console.WriteLine($"[Поток {Environment.CurrentManagedThreadId}] Генерация завершена.\n");
        DataReady.Set(); // сигнал всем ожидающим потокам
    }

    static void FindMax(object? state)
    {
        DataReady.WaitOne();

        var max = _numbers[0];
        for (var i = 1; i < _numbers.Length; i++)
        {
            if (_numbers[i] > max)
                max = _numbers[i];
        }

        Thread.Sleep(300);
        Console.WriteLine($"[Поток {Environment.CurrentManagedThreadId}] Максимум: {max}");
        SignalDone();
    }

    static void FindMin(object? state)
    {
        DataReady.WaitOne();

        var min = _numbers[0];
        for (var i = 1; i < _numbers.Length; i++)
        {
            if (_numbers[i] < min)
                min = _numbers[i];
        }

        Thread.Sleep(300);
        Console.WriteLine($"[Поток {Environment.CurrentManagedThreadId}] Минимум:  {min}");
        SignalDone();
    }

    static void FindAverage(object? state)
    {
        DataReady.WaitOne();

        var sum = 0L;
        for (var i = 0; i < _numbers.Length; i++)
        {
            sum += _numbers[i];
        }

        var average = (double)sum / _numbers.Length;

        Thread.Sleep(300);
        Console.WriteLine($"[Поток {Environment.CurrentManagedThreadId}] Среднее: {average:F2}");
        SignalDone();
    }

    static void SignalDone()
    {
        if (Interlocked.Decrement(ref _remaining) == 0)
            AllDone.Set();
    }
}
