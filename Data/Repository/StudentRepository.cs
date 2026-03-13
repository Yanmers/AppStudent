
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AppStudent.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CollegeDBContext _dbContext;

        public StudentRepository(CollegeDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateAsync(Student student)
        {
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
            return student.Id;
        }



        public async Task<bool> DeleteAsync(Student student)
        {

            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<Student> GetByIDAsync(int id)
        {
            return await _dbContext.Students.Where(n => n.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Student> GetByNameAsync(string name)
        {
            return await _dbContext.Students.Where(n => n.StudentName == name).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateAsync(Student student)
        {
            _dbContext.Update(student);

            await _dbContext.SaveChangesAsync();

            return student.Id;
        }
    }
}
