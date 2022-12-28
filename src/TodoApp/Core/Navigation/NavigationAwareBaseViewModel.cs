using System.Collections.Generic;
using System.Threading.Tasks;


namespace TodoApp
{
    public abstract class NavigationAwareBaseViewModel : BaseViewModel //, IQueryAttributable
    {
        protected NavigationAwareBaseViewModel(IAppNavigator appNavigator) : base(appNavigator)
        {
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            if (query.IsGoingBack())
            {
                System.Diagnostics.Debug.WriteLine($"{GetType().Name}.{nameof(OnBack)}");
                OnBack(query);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"{GetType().Name}.{nameof(OnInit)}");
                OnInit(query);
            }
        }

        // ReSharper disable once UnusedParameter.Global
        protected virtual void OnBack(IDictionary<string, string> query)
        {
        }

        // ReSharper disable once UnusedParameter.Global
        protected virtual void OnInit(IDictionary<string, string> query)
        {
        }
    }
    
    public interface IOnBackAwareViewModel
    {
        // ReSharper disable once UnusedMemberInSuper.Global
        // ReSharper disable once UnusedMethodReturnValue.Global
        // ReSharper disable once UnusedParameter.Global
        Task OnBackAsync(IDictionary<string, string> query);
    }

    public interface IOnInitAwareViewModel<in T>
    {
        // ReSharper disable once UnusedMemberInSuper.Global
        // ReSharper disable once UnusedMethodReturnValue.Global
        // ReSharper disable once UnusedParameter.Global
        Task OnInitAsync(T args);
    }

    // ReSharper disable once UnusedType.Global

    // ReSharper disable once UnusedType.Global
    public abstract class NavigationAwareViewModel<TInit>
        : NavigationAwareBaseViewModel
            , IOnInitAwareViewModel<TInit>
            , IOnBackAwareViewModel
    {
        protected NavigationAwareViewModel(IAppNavigator appNavigator) : base(appNavigator)
        {
        }

        protected override void OnInit(IDictionary<string, string> query)
        {
            OnInitAsync(query.GetData<TInit>());
        }

        // ReSharper disable once UnusedParameter.Global
        // ReSharper disable once UnusedMethodReturnValue.Global
        public virtual Task OnInitAsync(TInit args) => Task.CompletedTask;

        protected override void OnBack(IDictionary<string, string> query)
        {
            OnBackAsync(query);
        }

        // ReSharper disable once UnusedParameter.Global
        // ReSharper disable once UnusedMethodReturnValue.Global
        public virtual Task OnBackAsync(IDictionary<string, string> query) => Task.CompletedTask;
    }

    // ReSharper disable once UnusedType.Global
    public abstract class OnBackAwareViewModel
        : NavigationAwareBaseViewModel
            , IOnBackAwareViewModel
    {
        protected OnBackAwareViewModel(IAppNavigator appNavigator) : base(appNavigator)
        {
        }

        protected override void OnBack(IDictionary<string, string> query)
        {
            OnBackAsync(query);
        }

        // ReSharper disable once UnusedParameter.Global
        // ReSharper disable once UnusedMethodReturnValue.Global
        public virtual Task OnBackAsync(IDictionary<string, string> query) => Task.CompletedTask;
    }

    // ReSharper disable once UnusedType.Global
    public abstract class OnInitAwareViewModel<TInit>
        : NavigationAwareBaseViewModel
            , IOnInitAwareViewModel<TInit>
    {
        protected OnInitAwareViewModel(IAppNavigator appNavigator) : base(appNavigator)
        {
        }

        protected override void OnInit(IDictionary<string, string> query)
        {
            OnInitAsync(query.GetData<TInit>());
        }

        // ReSharper disable once UnusedParameter.Global
        // ReSharper disable once UnusedMethodReturnValue.Global
        public virtual Task OnInitAsync(TInit args) => Task.CompletedTask;
    }
}