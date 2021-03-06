using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public DetailsModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Student = await _context.Students.SingleOrDefaultAsync(m => m.ID == id);
            // FirstOrDefaultAsync is more efficient at fetching one entity
            //Student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id);

            /**********************************************************************************************
                The Include and ThenInclude methods cause the context to load the Student.Enrollments
                navigation property, and within each enrollment the Enrollment.Course navigation property.
                
                The AsNoTracking method improves performance in scenarios when the entities returned are
                not updated in the current context. 
                
                FirstOrDefaultAsync is more efficient at fetching one entity
            ***********************************************************************************************/
            Student = await _context.Students
                    .Include(s => s.Enrollments)
                        .ThenInclude(e => e.Course)
                    .AsNoTracking()
                    .FirstOrDefaultAsync (m => m.ID == id);            

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
