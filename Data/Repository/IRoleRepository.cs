using System.Linq.Expressions;

namespace AppStudent.Data.Repository
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync();

        Task<Role> GetByIdAsync(int id);

        Task<Role> GetByNameAsync(string roleName);

        Task<int> CreateAsync(Role role);

        Task<int> UpdateAsync(Role role);

        Task<bool> DeleteAsync(Role role);

        Task<Role> GetAsync(Expression<Func<Role, bool>> predicate);


    }
}
