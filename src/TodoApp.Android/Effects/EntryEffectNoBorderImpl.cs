using System.Linq;
using Android.Graphics.Drawables;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("TodoApp")]
[assembly: ExportEffect(typeof(TodoApp.Droid.EntryEffectNoBorderImpl), TodoApp.EntryEffectNoBorder.Name)]
namespace TodoApp.Droid
{
    public class EntryEffectNoBorderImpl : PlatformEffect
    {
        Drawable _defaultBackground;
        protected override void OnAttached()
        {
            var control = Control as EditText;

            if (control == null) return;

            _defaultBackground = control.Background;

            var effect = Element.Effects.FirstOrDefault(x => x is EntryEffectNoBorder);

            if (effect == null) return;

            control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            // control.SetPadding(control.PaddingLeft, 0, control.PaddingRight, 0);
            control.SetPadding(0, 0, 0, 0);
        }

        protected override void OnDetached()
        {
            if (Control is FormsEditText control)
                control.SetBackground(_defaultBackground);
        }
    }
}
