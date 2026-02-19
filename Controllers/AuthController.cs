using AppStudent.Data;
using AppStudent.Models;
using AppStudent.MyLogger;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AppStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //Strongly couple/ tightly couple
        //private readonly IMyLogger _myLogger;
        //public AuthController(IMyLogger myLogger)
        //{
        //    _myLogger = myLogger;
        //}

        private readonly ILogger<IMyLogger> _logger;
        private readonly CollegeDBContext _dbContext;
        private readonly IMapper _mapper;

        public AuthController(ILogger<IMyLogger> logger, CollegeDBContext dBContext, IMapper mapper)
        {
            _logger = logger;
            _dbContext = dBContext;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<User>> GetAction()
        {
            var users = _dbContext.Users;

            if (users == null)
            {
                _logger.LogWarning("BadRequest");
                return BadRequest();
            }

            _logger.LogInformation("Log Info");

            return Ok(users);
        }

        [HttpPost]
        [Route("CreateUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<User> CreateUser([FromBody] User model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            User user = new User()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Role = model.Role,
                Password = model.Password

            };

            //var user = _mapper.Map<UserDTO>(User);

            _dbContext.Add(user);
            _dbContext.SaveChanges();

            model.Id = user.Id;

            return Ok(model);
        }
    }
}
