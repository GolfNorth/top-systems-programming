using System.Runtime.InteropServices;

namespace Module1.Task2;

public partial class MainForm : Form
{
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int MessageBox(IntPtr hWnd, string text, string caption, MessageBoxType type);

    public MainForm()
    {
        InitializeComponent();
    }

    private void buttonStart_Click(object? sender, EventArgs e)
    {
        PlayGame();
    }

    private void PlayGame()
    {
        MessageBox(Handle,
            "Загадайте число от 0 до 100.\nНажмите OK когда будете готовы.",
            "Новая игра",
            MessageBoxType.Ok | MessageBoxType.IconInformation);

        int low = 0;
        int high = 100;
        int attempts = 0;

        while (low <= high)
        {
            int guess = (low + high) / 2;
            attempts++;

            var result = (MessageBoxResult)MessageBox(Handle,
                $"Это число {guess}?\n\nДа - угадал\nНет - моё число меньше\nОтмена - моё число больше",
                $"Попытка {attempts}",
                MessageBoxType.YesNoCancel | MessageBoxType.IconQuestion);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    AskPlayAgain(guess, attempts);
                    return;

                case MessageBoxResult.No:
                    high = guess - 1;
                    break;

                case MessageBoxResult.Cancel:
                    low = guess + 1;
                    break;
            }
        }

        MessageBox(Handle,
            "Вы где-то ошиблись в ответах!",
            "Ошибка",
            MessageBoxType.Ok | MessageBoxType.IconWarning);
    }

    private void AskPlayAgain(int guess, int attempts)
    {
        var result = (MessageBoxResult)MessageBox(Handle,
            $"Я угадал число {guess} за {attempts} попыток!\n\nСыграем ещё раз?",
            "Победа!",
            MessageBoxType.YesNo | MessageBoxType.IconInformation);

        if (result == MessageBoxResult.Yes)
        {
            PlayGame();
        }
    }
}
