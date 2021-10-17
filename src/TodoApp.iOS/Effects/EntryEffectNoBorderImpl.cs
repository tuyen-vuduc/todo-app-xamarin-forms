using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("TodoApp")]
[assembly: ExportEffect(typeof(TodoApp.iOS.EntryEffectNoBorderImpl), TodoApp.EntryEffectNoBorder.Name)]
namespace TodoApp.iOS
{
    public class EntryEffectNoBorderImpl : PlatformEffect
    {
        UITextBorderStyle _defaultBorderStyle;

        protected override void OnAttached()
        {
            var control = Control as UITextField;

            if (control == null) return;

            _defaultBorderStyle = control.BorderStyle;

            var effect = Element.Effects.FirstOrDefault(x => x is EntryEffectNoBorder);

            if (effect == null) return;

            control.BorderStyle = UITextBorderStyle.None;
        }

        protected override void OnDetached()
        {
            var control = Control as UITextField;

            if (control == null) return;

            control.BorderStyle = _defaultBorderStyle;
        }
    }
}
