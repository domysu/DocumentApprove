using DokumentuTvirtinimoSistema.Models;
namespace DokumentuTvirtinimoSistema.Interfaces
{
    public interface IUser
    {
        Task<List<User>> GetUsersAsync();
        Task<User> AddUserAsync(User user, string password);
        Task<User> GetUserByUsernameAsync(string username);
        Task deleteUser(int id);
        
    }
}
