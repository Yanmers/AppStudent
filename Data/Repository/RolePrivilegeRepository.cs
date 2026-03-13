
namespace AppStudent.Data.Repository
{
    public class RolePrivilegeRepository : IRolePrivilegeRepository
    {
        private readonly CollegeDBContext _collegeDBContext;
        public RolePrivilegeRepository(CollegeDBContext collegeDBContext)
        {
            _collegeDBContext = collegeDBContext;
        }
        public async Task<int> CreateAsync(RolePrivilege rolePrivilege)
        {
            _collegeDBContext.RolePrivileges.Add(rolePrivilege);
            _collegeDBContext.SaveChanges();
            return rolePrivilege.Id;
        }

        public Task<bool> DeleteAsync(RolePrivilege olePrivilege)
        {
            throw new NotImplementedException();
        }

        public Task<List<RolePrivilege>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RolePrivilege> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RolePrivilege> GetByNameAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(RolePrivilege rolePrivilege)
        {
            throw new NotImplementedException();
        }
    }
}
