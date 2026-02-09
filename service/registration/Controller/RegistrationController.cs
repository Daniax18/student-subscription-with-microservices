using Microsoft.AspNetCore.Mvc;
using registration.Data;
using registration.Model;
using registration.Services;

namespace registration.Controller
{
    [ApiController]
    [Route("api/registrations")]
    public class RegistrationController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly StudentClient _studentClient;
        private readonly SubjectClient _subjectClient;

        public RegistrationController(AppDbContext context, StudentClient studentClient, SubjectClient subjectClient)
        {
            _context = context;
            _studentClient = studentClient;
            _subjectClient = subjectClient;
        }

        [HttpGet]
        public IActionResult GetAllRegistrations()
        {
            var registrations = _context.Registrations.ToList();
            return Ok(registrations);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Registration registrationData)
        {
            if (!await _studentClient.IsStudentExist(registrationData.StudentId))
                return BadRequest("Étudiant inexistant");

            if (!await _subjectClient.IsSubjectExist(registrationData.SubjectId))
                return BadRequest("Matière inexistante");

            _context.Registrations.Add(registrationData);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), registrationData);
        }
    }
}
