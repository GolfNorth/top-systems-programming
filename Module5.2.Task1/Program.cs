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

        BigInteger result = ParallelFactorial(n);
        Console.WriteLine($"\n{n}! = {result}");
    }

    static BigInteger ParallelFactorial(int n)
    {
        if (n <= 1)
            return 1;

        // Разбиваем диапазон [1..n] на части по числу процессоров.
        // Каждый поток вычисляет произведение своего диапазона,
        // затем частичные результаты перемножаются.

        int partCount = Environment.ProcessorCount;
        BigInteger[] partials = new BigInteger[partCount];

        Parallel.For(0, partCount, i =>
        {
            int from = i * n / partCount + 1;
            int to = (i + 1) * n / partCount;

            Console.WriteLine($"[Поток {Environment.CurrentManagedThreadId}] " +
                              $"диапазон {from}..{to}");

            BigInteger product = 1;
            for (int x = from; x <= to; x++)
                product *= x;

            partials[i] = product;
        });

        BigInteger result = 1;
        for (int i = 0; i < partCount; i++)
            result *= partials[i];

        return result;
    }
}
