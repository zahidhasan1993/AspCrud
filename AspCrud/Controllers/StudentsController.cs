using AspCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDbContext db;

        public StudentsController(StudentDbContext db)
        {
            this.db = db;
        }

        [HttpGet]

        public async Task<ActionResult<List<StudentInfo>>> GetAllData()
        {
            var data = await db.StudentInfos.ToListAsync();

            return Ok(data);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<StudentInfo>> GetSingleData(int id)
        {
            var student = await db.StudentInfos.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]

        public async Task<ActionResult<StudentInfo>> AddData(StudentInfo std)
        {
            await db.StudentInfos.AddAsync(std);
            await db.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentInfo>> UpdateData(int id,StudentInfo std)
        {
            if (id != std.Id)
            {
                return BadRequest();
            }

            db.Entry(std).State = EntityState.Modified;

            await db.SaveChangesAsync();

            return Ok(std);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<StudentInfo>> DeleteData(int id)
        {
            var student = await db.StudentInfos.FindAsync(id);

            if (student == null)
            {
                return BadRequest();
            }

           db.StudentInfos.Remove(student);

            await db.SaveChangesAsync();

            return Ok(student);
        }
    }
}
