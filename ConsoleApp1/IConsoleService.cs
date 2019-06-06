using System.Threading.Tasks;

namespace ApiClientConsoleApp
{
    public interface IConsoleService
    {
        Task Categories();
        Task Ingredients();
        Task Cocktails();
    }
}