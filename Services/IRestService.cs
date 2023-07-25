using Disc.Models;

namespace Disc.Services
{
    public interface IRestService
    {
        //Task<List<Posts>> RefreshDataAsync();

        Task LoginAsync(LoginInfo loginInfo);

        //Task SaveItemAsync(Posts item, bool isNewItem);

        //Task DeleteItemAsync(string id);
    }
}
