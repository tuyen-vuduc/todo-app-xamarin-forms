using System;
using DryIoc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoApp
{
    [ContentProperty(nameof(ViewModelType))]
    public class BindingContextExtension : IMarkupExtension
    {
        public Type ViewModelType { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var container = DependencyService.Get<IContainer>();

            var vm = container?.Resolve(ViewModelType);

            return vm;
        }
    }
}
