using System.Threading.Tasks;

namespace TodoApp
{
    public interface IAppNavigator
    {
        Task GoBackAsync(object data = default);

        Task NavigateAsync(string target, object args = default);
    }
}
