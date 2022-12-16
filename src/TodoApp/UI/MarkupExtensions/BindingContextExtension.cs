using System;
using DryIoc;

namespace TodoApp
{
    [ContentProperty(nameof(ViewModelType))]
    public class BindingContextExtension : IMarkupExtension
    {
        public Type ViewModelType { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var container = DependencyService.Get<DryIoc.IContainer>();

            var vm = container?.Resolve(ViewModelType);

            return vm;
        }
    }
}
