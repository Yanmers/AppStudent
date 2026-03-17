using AppStudent.Data;
using AppStudent.Data.Repository;
using AppStudent.Models;
using AppStudent.MyLogger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading.Tasks;

namespace AppStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<IMyLogger> _logger;
        private readonly IStudentRepository _studentRespository;


        public StudentController(ILogger<IMyLogger> logger, IStudentRepository studentRespository)
        {
            _logger = logger;
            _studentRespository = studentRespository;
        }

        [HttpGet]
        [Route("All", Name = "GetAllStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {

            var student = await _studentRespository.GetAllAsync();

            if (student == null)
            {
                _logger.LogWarning("BadRequest");
                return BadRequest();
            }
            return Ok(student);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudentsByDTO()
        {
            //var students = new List<StudentDTO>();
            //foreach (var item in StudentRepository.Students)
            //{
            //    StudentDTO obj = new StudentDTO()
            //    {
            //        Id = item.Id,
            //        Name = item.Name,
            //        Email = item.Email,
            //        Address = item.Address

            //    };
            //    students.Add(obj);
            //}

            //Link Example.
            //var students = _dbContext.Students.Select(s => new StudentDTO()
            //{
            //    Id = s.Id,
            //    Name = s.Name,
            //    Email = s.Email,
            //    Address = s.Address,
            //    DBO = s.DBO

            //});

            var students = await _studentRespository.GetAllAsync();

            if (students == null)
            {
                _logger.LogWarning("BadRequest");
                return BadRequest();
            }
            return Ok(students);
        }


        [HttpGet]
        [Route("{id}", Name = "GetByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("BadRequest");
                return BadRequest();
            }
            var studentById = await _studentRespository.GetByIDAsync(id);
            if (studentById == null)
            {
                _logger.LogError("NotFound");
                return NotFound();
            }
            return Ok(studentById);
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentDTO>> CreateStudent([FromBody] StudentDTO model)
        {
            if (model == null)
            {
                _logger.LogWarning("BadRequest");
                return BadRequest();
            }


            Student student = new Student
            {
                // Id = newId,
                StudentName = model.Name,
                Email = model.Email,
                Address = model.Address,
                DBO = model.DBO
            };

            await _studentRespository.CreateAsync(student);


            model.Id = student.Id;

            return Ok(model);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentDTO>> UpdateStudent([FromBody] StudentDTO model)
        {
            if (model == null || model.Id < 0)
            {
                _logger.LogWarning("BadRequest");
                return BadRequest();
            }

            //var studentUpdate = await _dbContext.Students.Where(n => n.Id == model.Id).FirstOrDefaultAsync();
            var studentUpdate = await _studentRespository.GetByIDAsync(model.Id);
            if (studentUpdate == null)
            {
                _logger.LogError("NotFound");
                return NotFound();
            }

            studentUpdate.StudentName = model.Name;
            studentUpdate.Email = model.Email;
            studentUpdate.Address = model.Address;
            studentUpdate.DBO = model.DBO;


            //await _dbContext.SaveChangesAsync();
            await _studentRespository.UpdateAsync(studentUpdate);
            return Ok(studentUpdate);
        }

        [HttpPatch]
        [Route("{id:int}/UpdatePartial")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentDTO>> UpdateStudentPartial(int id, [FromBody] JsonPatchDocument<StudentDTO> patchDocument)
        {
            if (patchDocument == null || id <= 0)
            {
                return BadRequest();
            }

            //var studentUpdate = await _dbContext.Students.Where(n => n.Id == id).FirstOrDefaultAsync();
            var studentUpdate = await _studentRespository.GetByIDAsync(id);

            if (studentUpdate == null)
            {
                return NotFound();
            }

            var studentDTO = new StudentDTO
            {
                Id = studentUpdate.Id,
                Name = studentUpdate.StudentName,
                Email = studentUpdate.Email,
                Address = studentUpdate.Address,
                DBO = studentUpdate.DBO
            };


            patchDocument.ApplyTo(studentDTO);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            studentUpdate.StudentName = studentDTO.Name;
            studentUpdate.Email = studentDTO.Email;
            studentUpdate.Address = studentDTO.Address;
            studentUpdate.DBO = studentDTO.DBO;

            await _studentRespository.UpdateAsync(studentUpdate);
            return NoContent();
        }

        [HttpGet]
        [Route("name", Name = "GetByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Student>> GetStudentsByName(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            //var studentByName = await _dbContext.Students.Where(n => n.Name == name).FirstOrDefaultAsync();
            var studentByName = await _studentRespository.GetByNameAsync(name);
            if (studentByName == null)
            {
                return NotFound($"The student with the {name} not found");
            }

            return Ok(studentByName);
        }

        [HttpDelete]
        [Route("{id}", Name = "DeleteById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteStudent(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            //var deleteStudent = await _dbContext.Students.Where(n => n.Id == id).FirstOrDefaultAsync();
            var deleteStudent = await _studentRespository.GetByIDAsync(id);
            if (deleteStudent == null)
            {
                return NotFound($"The Student With Id {id} not founf");
            }


            await _studentRespository.DeleteAsync(deleteStudent);

            return Ok(true);
        }



    }
}

