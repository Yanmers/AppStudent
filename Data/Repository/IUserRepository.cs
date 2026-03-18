namespace AppStudent.Data.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByNameAsync(string name);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);

    }
}
