namespace TodoApp;

public partial class SideBarMenuView
{
    public SideBarMenuView()
    {
        InitializeComponent();
    }

    public delegate void OnBackClickedDelegate();

    public OnBackClickedDelegate OnBackClicked { get; set; }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        OnBackClicked?.Invoke();
    }
}