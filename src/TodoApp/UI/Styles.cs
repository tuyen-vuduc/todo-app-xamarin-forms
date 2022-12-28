namespace TodoApp;

public partial class Styles
{
    public static readonly Style TextPrimaryLg = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Microsoft.Maui.Graphics.Colors.Transparent)
        .Set(Label.TextColorProperty, Colors.TextPrimary)
        .Set(Label.FontSizeProperty, Dimens.FontSizeLg);
    
    public static readonly Style TextPrimaryMd = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Microsoft.Maui.Graphics.Colors.Transparent)
        .Set(Label.TextColorProperty, Colors.TextPrimary)
        .Set(Label.FontSizeProperty, Dimens.FontSizeMd);
    
    public static readonly Style TextSecondaryLg = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Microsoft.Maui.Graphics.Colors.Transparent)
        .Set(Label.TextColorProperty, Colors.TextSecondary)
        .Set(Label.FontSizeProperty, Dimens.FontSizeLg);

    public static readonly Style TextSecondaryMd = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Microsoft.Maui.Graphics.Colors.Transparent)
        .Set(Label.TextColorProperty, Colors.TextSecondary)
        .Set(Label.FontSizeProperty, Dimens.FontSizeMd);
    
    public static readonly Style TextSecondarySm = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Microsoft.Maui.Graphics.Colors.Transparent)
        .Set(Label.TextColorProperty, Colors.TextSecondary)
        .Set(Label.FontSizeProperty, Dimens.FontSizeSm);
    
    public static readonly Style TextSidebarMenuItem = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Microsoft.Maui.Graphics.Colors.Transparent)
        .Set(Label.TextColorProperty, Microsoft.Maui.Graphics.Colors.White)
        .Set(Label.FontSizeProperty, Dimens.FontSizeMd);
    
    public static readonly Style TextSidebarPersonName = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Microsoft.Maui.Graphics.Colors.Transparent)
        .Set(Label.TextColorProperty, Microsoft.Maui.Graphics.Colors.White)
        .Set(Label.FontSizeProperty, Dimens.FontSizeXl);
    
    public static readonly Style TextSidebarFooter = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Microsoft.Maui.Graphics.Colors.Transparent)
        .Set(Label.TextColorProperty, Microsoft.Maui.Graphics.Colors.White)
        .Set(Label.FontSizeProperty, Dimens.FontSizeLg);
    
    public static readonly Style TextPageHeader = CreateStyle<Label>()
        .Set(VisualElement.BackgroundColorProperty, Microsoft.Maui.Graphics.Colors.Transparent)
        .Set(Label.TextColorProperty, Colors.TextPrimary)
        .Set(Label.FontAttributesProperty, FontAttributes.Bold)
        .Set(Label.FontSizeProperty, Dimens.FontSizeXl);

}

public static partial class Styles
{
    public static Style CreateStyle<T>() {
        return new Style(typeof(T));
    }

    public static Style BaseOn(this Style style, Style basedOn) {
        style.BasedOn = basedOn;
        return style;
    }

    public static Style Set(this Style style, BindableProperty property, object value) {
        style.Setters.Add(new Setter {
            Property = property,
            Value = value
        });
        return style;
    }

    public static Style BindTrigger(this Style style, Binding binding, object value, params (BindableProperty p, object value)[] setters) {
        var dataTrigger = new DataTrigger(style.TargetType) {
            Binding = binding,
            Value = value
        };

        for (int i = 0; i < setters.Length; i++) {
            dataTrigger.Setters.Add(new Setter {
                Property = setters[i].p,
                Value = setters[i].value
            });
        }

        style.Triggers.Add(dataTrigger);

        return style;
    }
}