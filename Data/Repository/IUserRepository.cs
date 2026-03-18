namespace AppStudent.Data.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserById(int id);

        Task<User> GetUserByNameAsync(string name);
        Task<User> UpdateUserAsync(User user, int id);
        Task<bool> DeleteUserAsync(int id);

    }
}
