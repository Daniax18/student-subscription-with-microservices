using Microsoft.AspNetCore.Mvc;

namespace subject.Controller
{
    [ApiController]
    [Route("api/subjects")]
    public class SubjectController: ControllerBase
    {
        private readonly Data.AppDbContext _context;

        public SubjectController(Data.AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSubjects()
        {
            var subjects = _context.Subjects.ToList();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public IActionResult GetSubject(int id)
        {
            var subject = _context.Subjects.Find(id);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        [HttpPost]
        public IActionResult CreateSubject(Model.Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSubject), new { id = subject.Id }, subject);
        }
    }
}
