using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFileService
    {
        Task Write(string text);
    }
}
