namespace Module3.Sample3;

public partial class MainForm : Form
{
    // Захватываем SynchronizationContext UI-потока
    private readonly SynchronizationContext _uiContext;

    public MainForm()
    {
        InitializeComponent();
        _uiContext = SynchronizationContext.Current ?? new SynchronizationContext();
    }

    private void buttonStart_Click(object? sender, EventArgs e)
    {
        labelStatus.Text = "Выполняется...";
        buttonStart.Enabled = false;

        // Запускаем работу на фоновом потоке из пула
        ThreadPool.QueueUserWorkItem(DoWork);
    }

    private void DoWork(object? state)
    {
        // Имитация длительной операции
        Thread.Sleep(2000);
        var result = $"Готово в {DateTime.Now:HH:mm:ss}, поток: {Environment.CurrentManagedThreadId}";

        // Маршалим результат на UI-поток через захваченный контекст
        _uiContext.Post(UpdateUI, result);
    }

    private void UpdateUI(object? state)
    {
        // Этот код выполняется на UI-потоке
        textBoxResult.Text = (string?)state;
        labelStatus.Text = $"UI обновлён в потоке: {Environment.CurrentManagedThreadId}";
        buttonStart.Enabled = true;
    }
}
