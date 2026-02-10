// Модуль 4.2 Sample2 — volatile
//
// Без volatile: поток может закэшировать переменную в регистре CPU
// и никогда не увидеть изменение от другого потока.
// volatile запрещает такую оптимизацию.
//
// ВАЖНО: баг проявляется только в Release-сборке,
// потому что в Debug JIT не оптимизирует.

namespace Module4_2.Sample2;

static class Program
{
    // ── Без volatile ─────────────────────────────────────
    static bool _stopRequested;

    // ── С volatile ───────────────────────────────────────
    static volatile bool _stopRequestedSafe;

    static void Main()
    {
        Console.WriteLine("═══ 1. Без volatile (Release: зависнет!) ═══\n");
        DemoUnsafe();

        Console.WriteLine("\n═══ 2. С volatile ═══\n");
        DemoVolatile();
    }

    static void DemoUnsafe()
    {
        _stopRequested = false;

        var worker = new Thread(() =>
        {
            Console.WriteLine($"  [Поток {Environment.CurrentManagedThreadId}] Работаю...");

            var iterations = 0;
            // JIT в Release может закэшировать _stopRequested в регистре.
            // Цикл никогда не завершится!
            while (!_stopRequested)
            {
                iterations++;
            }

            Console.WriteLine($"  [Поток {Environment.CurrentManagedThreadId}] Остановлен после {iterations:N0} итераций");
        });

        worker.Start();
        Thread.Sleep(500);

        Console.WriteLine($"  [Main] Отправляю сигнал остановки...");
        _stopRequested = true;

        // В Release-сборке worker может зависнуть.
        // Даём 2 секунды, потом принудительно завершаем.
        if (!worker.Join(TimeSpan.FromSeconds(2)))
        {
            Console.WriteLine("  [Main] Поток НЕ остановился! (флаг закэширован в регистре CPU)");
            // Грубая остановка для продолжения демо
            worker.Interrupt();
            Thread.Sleep(100);
        }
    }

    static void DemoVolatile()
    {
        _stopRequestedSafe = false;

        var worker = new Thread(() =>
        {
            Console.WriteLine($"  [Поток {Environment.CurrentManagedThreadId}] Работаю...");

            var iterations = 0;
            // volatile гарантирует: каждое чтение — из памяти, не из кэша/регистра
            while (!_stopRequestedSafe)
            {
                iterations++;
            }

            Console.WriteLine($"  [Поток {Environment.CurrentManagedThreadId}] Остановлен после {iterations:N0} итераций");
        });

        worker.Start();
        Thread.Sleep(500);

        Console.WriteLine($"  [Main] Отправляю сигнал остановки...");
        _stopRequestedSafe = true;

        worker.Join();
        Console.WriteLine("  [Main] Поток корректно завершился.");
    }
}
