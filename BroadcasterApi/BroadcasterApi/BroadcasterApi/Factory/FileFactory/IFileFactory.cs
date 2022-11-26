using BroadcasterApi.ViewModel.File;
using System.Threading.Tasks;

namespace BroadcasterApi.Factory.FileFactory
{
    public interface IFileFactory
    {
        Task<(bool result, string message, string error, Entity.File data)> Insert(FileViewModel model);
    }
}
