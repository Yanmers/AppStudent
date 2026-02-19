using Microsoft.EntityFrameworkCore;

namespace AppStudent.Data.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();

        Task<Student> GetByIDAsync(int id);

        Task<Student> GetByNameAsync(String name);

        Task<int> CreateAsync(Student student);

        Task<int> UpdateAsync(Student student);

        Task<bool> DeleteAsync(Student student);
    }
}
