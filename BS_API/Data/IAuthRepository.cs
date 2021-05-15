using System.Threading.Tasks;
using BS.Models;
using BS.Services;

namespace BS.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register (User user, string password);
        Task<ServiceResponse<string>> Login (string username, string password);
        Task<bool> UserExist (string username);
    }
}