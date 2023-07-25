using Disc.Models;

namespace Disc.Services
{
    public interface ILoginService
    {
        Task LoginAsync(LoginInfo login);
    }
}

