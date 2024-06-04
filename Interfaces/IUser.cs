using DokumentuTvirtinimoSistema.Models;
namespace DokumentuTvirtinimoSistema.Interfaces
{
    public interface IUser
    {
        Task<List<User>> GetUsersAsync();
        Task<User> AddUserAsync(User user, string password);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        
    }
}
