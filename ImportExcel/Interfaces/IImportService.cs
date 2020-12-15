using ImportExcel.Domain.Model.Enuns;
using System.Threading.Tasks;

namespace ImportExcel.Service.Interfaces
{
    public interface IImportService
    {
        Task<int> CreateImport(string fileName, string fullPath);
    }
}
