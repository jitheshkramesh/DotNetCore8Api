using DotNetCore8Api.Models;

namespace DotNetCore8Api.Services.Interfaces
{
    public interface IFanService
    {
        Task<List<Fan>?> GetFans();
    }
}
