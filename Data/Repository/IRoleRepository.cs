namespace AppStudent.Data.Repository
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync();

        Task<Role> GetByIDAsync(int id);

        Task<Role> GetByNameAsync(String roleName);

        Task<int> CreateAsync(Role role);

        Task<int> UpdateAsync(Role role);

        Task<bool> DeleteAsync(Role role);
    }
}
