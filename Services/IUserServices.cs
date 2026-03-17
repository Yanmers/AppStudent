using Octokit;

namespace AppStudent.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> GetAllUserAsync();

        Task<User> GetUserByIdAsync(int id);

        Task<User> GetUserByName(string UserName);

        Task<User> UpdateUserAsync(User user, int id);
        Task<bool> DeleteUserAsync(int id);
    }
}
