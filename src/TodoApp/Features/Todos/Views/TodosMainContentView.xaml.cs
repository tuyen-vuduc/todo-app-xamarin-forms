namespace TodoApp;

public partial class TodosMainContentView : ContentView
{
    public TodosMainContentView()
    {
        InitializeComponent();
    }

    public delegate void OnMenuClickedDelegate();

    public OnMenuClickedDelegate OnMenuClicked { get; set; }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        OnMenuClicked?.Invoke();
    }
}