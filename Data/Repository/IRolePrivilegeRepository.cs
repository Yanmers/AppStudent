using System.Linq.Expressions;

namespace AppStudent.Data.Repository
{
    public interface IRolePrivilegeRepository
    {
        Task<List<RolePrivilege>> GetAllAsync();

        Task<RolePrivilege> GetByIdAsync(int id);

        Task<RolePrivilege> GetByNameAsync(string roleName);

        Task<int> CreateAsync(RolePrivilege rolePrivilege);

        Task<int> UpdateAsync(RolePrivilege rolePrivilege);

        Task<bool> DeleteAsync(RolePrivilege olePrivilege);
    }
}
