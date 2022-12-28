namespace TodoApp;

public partial class SidebarItemView
{
    public SidebarItemView()
    {
        InitializeComponent();
    }

    public static BindableProperty IconSourceProperty = BindableProperty.Create(
        nameof(IconSource),
        typeof(ImageSource),
        typeof(SidebarItemView),
        null
        );
    public ImageSource IconSource
    {
        get => GetValue(IconSourceProperty) as ImageSource;
        set => SetValue(IconSourceProperty, value);
    }

    public static BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text),
        typeof(string),
        typeof(SidebarItemView),
        null
        );
    public string Text
    {
        get => GetValue(TextProperty) as string;
        set => SetValue(TextProperty, value);
    }
}
