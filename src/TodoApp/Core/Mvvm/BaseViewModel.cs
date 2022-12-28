namespace TodoApp;

public abstract class BaseViewModel : ObservableRecipient
{
    protected IAppNavigator AppNavigator { get; }

    protected BaseViewModel(IAppNavigator appNavigator)
    {
        AppNavigator = appNavigator;
    }

    public virtual Task OnAppearingAsync()
    {
        System.Diagnostics.Debug.WriteLine($"{GetType().Name}.{nameof(OnAppearingAsync)}");

        return Task.CompletedTask;
    }

    // ReSharper disable once UnusedParameter.Global
    // ReSharper disable once UnusedMethodReturnValue.Global
    // ReSharper disable once VirtualMemberNeverOverridden.Global
    public virtual Task OnDisappearingAsync()
    {
        System.Diagnostics.Debug.WriteLine($"{GetType().Name}.{nameof(OnDisappearingAsync)}");

        return Task.CompletedTask;
    }
}