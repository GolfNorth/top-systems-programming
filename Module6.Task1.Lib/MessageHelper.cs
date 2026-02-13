namespace Module6.Task1.Lib;

public static class MessageHelper
{
    public static void ShowInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"[INFO] {DateTime.Now:HH:mm:ss} — {message}");
        Console.ResetColor();
    }
}
