namespace TodoApp;

public static class EntryEffect
{
    public static BindableProperty HasBorderProperty = BindableProperty.CreateAttached(
        "HasBorder",
        typeof(bool?),
        typeof(EntryEffect),
        true,
        BindingMode.OneWay,
        propertyChanged: HandleHasBorderChanged
    );
    public static bool? GetHasBorder(BindableObject obj)
    {
        return (bool?)obj.GetValue(HasBorderProperty);
    }
    public static void SetHasBorder(BindableObject obj, bool? value)
    {
        obj.SetValue(HasBorderProperty, value);
    }
    static void HandleHasBorderChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var element = (View)bindable;

        var value = newValue as bool? ?? true;

        var effect = element.Effects.FirstOrDefault(x => x is EntryEffectNoBorder);

        if (effect != null)
        {
            if (value)
            {
                element.Effects.Remove(effect);
            }

            return;
        }

        if (!value)
        {
            element.Effects.Add(new EntryEffectNoBorder());
        }
    }
}

public class EntryEffectNoBorder : RoutingEffect
{
    public const string Name = "EntryEffectNoBorder";

    public EntryEffectNoBorder() : base($"TodoApp.{Name}")
    {

    }
}
