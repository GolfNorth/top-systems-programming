// Модуль 5.1 Задание 1 — Task: три способа запуска
//
// 1. new Task() + Start()
// 2. Task.Factory.StartNew()
// 3. Task.Run()

namespace Module5_1.Task1;

static class Program
{
    static void Main()
    {
        Console.WriteLine("═══ 1. new Task() + Start() ═══\n");
        DemoTaskStart();

        Console.WriteLine("\n═══ 2. Task.Factory.StartNew() ═══\n");
        DemoFactoryStartNew();

        Console.WriteLine("\n═══ 3. Task.Run() ═══\n");
        DemoTaskRun();
    }

    static void DemoTaskStart()
    {
        var task = new Task(ShowDateTime);
        task.Start();
        task.Wait();
    }

    static void DemoFactoryStartNew()
    {
        var task = Task.Factory.StartNew(ShowDateTime);
        task.Wait();
    }

    static void DemoTaskRun()
    {
        var task = Task.Run(ShowDateTime);
        task.Wait();
    }

    static void ShowDateTime()
    {
        Console.WriteLine($"  Поток:     {Environment.CurrentManagedThreadId}");
        Console.WriteLine($"  Дата:      {DateTime.Now:dd.MM.yyyy}");
        Console.WriteLine($"  Время:     {DateTime.Now:HH:mm:ss.fff}");
    }
}
