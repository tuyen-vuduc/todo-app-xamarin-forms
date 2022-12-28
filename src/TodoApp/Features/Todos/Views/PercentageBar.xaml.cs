namespace TodoApp;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class PercentageBar
{
    public static readonly BindableProperty PercentageProperty = BindableProperty.Create(
        nameof(Percentage),
        typeof(double),
        typeof(PercentageBar),
        0.0,
        BindingMode.OneWay
        );

    public double Percentage
    {
        get => (double)GetValue(PercentageProperty);
        set => SetValue(PercentageProperty, value);
    }

    public static readonly BindableProperty ColorProperty = BindableProperty.Create(
        nameof(Color),
        typeof(Color),
        typeof(PercentageBar),
        Microsoft.Maui.Graphics.Colors.Purple,
        BindingMode.OneWay
        );

    public Color Color
    {
        get => GetValue(ColorProperty) as Color;
        set => SetValue(ColorProperty, value);
    }

    public PercentageBar()
    {
        InitializeComponent();
    }
}