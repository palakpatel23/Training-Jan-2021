using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using student_admission_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_admission_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDetailsController : ControllerBase
    {
        private readonly StudentAdmissionContext _context;

        public StudentDetailsController(StudentAdmissionContext context)
        {
            this._context = context;
        }

        //GET: api/StudentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalDetail>>> GetStudentDetails()
        {
            var data = _context.PersonalDetails.Include("address").Include("fatherDetails").Include("motherDetails").Include("emergencyContacts").Include("references");
            return await data.ToListAsync();
        }

        //GET: api/StudentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalDetail>> GetStudentDetails(int id)
        {
            var studentDetail = await _context.PersonalDetails.FindAsync(id);
            if (studentDetail == null)
            {
                return NotFound();
            }
            return studentDetail;
        }

        //PUT: api/studentDetails/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PersonalDetail>> PutStudentDetails(int id, PersonalDetail studentDetail)
        {
            if (id != studentDetail.StudentId)
            {
                return BadRequest();
            }
            _context.Entry(studentDetail).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!StudentDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return studentDetail;
        }

        //POST: api/StudentDetails
        [HttpPost]
        public async Task<ActionResult<PersonalDetail>> PostStudentDetail(PersonalDetail studentDetail)
        {
            _context.PersonalDetails.Add(studentDetail);
            await _context.SaveChangesAsync();

            return Ok(true);
        }

        //DELETE: api/StudentDetails/4
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentsdetails(int id)
        {
            var studentDetail = await _context.PersonalDetails.FindAsync(id);
            if(studentDetail == null)
            {
                return NotFound();
            }

            var addressId = await _context.Addresses.SingleOrDefaultAsync(x => x.StudentId == id);
            _context.Addresses.Remove(addressId);
            var fatherId = await _context.FatherDetails.SingleOrDefaultAsync(x => x.StudentId == id);
            _context.FatherDetails.Remove(fatherId);
            var motherId = await _context.MotherDetails.SingleOrDefaultAsync(x => x.StudentId == id);
            _context.MotherDetails.Remove(motherId);
            var referenceId = _context.References.Where(x => x.StudentId == id);
            foreach (var i in referenceId)
            {
                _context.References.Remove(i);
            }

            var emergencyContactId = _context.EmergencyContacts.Where(x => x.StudentId == id);
            foreach (var i in emergencyContactId)
            {
                _context.EmergencyContacts.Remove(i);
            }
            _context.PersonalDetails.Remove(studentDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentDetailExists(int id)
        {
            return _context.PersonalDetails.Any(e => e.StudentId == id);
        }
    }
}
