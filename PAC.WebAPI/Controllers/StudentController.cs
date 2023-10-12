using Microsoft.AspNetCore.Mvc;
using PAC.Domain;
using PAC.IBusinessLogic;
using PAC.WebAPI.Filters;

namespace PAC.WebAPI
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentLogic _studentLogic;

        public StudentController(IStudentLogic studentLogic)
        {
            _studentLogic = studentLogic;
        }

        [HttpGet("{age}")]
        public IEnumerable<Student> GetAllStudents(int age)
        {
            return _studentLogic.GetStudents().Where(student => student.Age == age).ToList();
        }

        [HttpGet("{idStudent}")]
        public Student GetStudent(int idStudent)
        {
            return _studentLogic.GetStudentById(idStudent);
        }

        [AuthorizationFilter]
        [HttpPost]
        public IActionResult AddStudent([FromBody] Student value)
        {
            _studentLogic.InsertStudents(value);

            return Ok();
        }
    }
}
