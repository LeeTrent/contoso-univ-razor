using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public EditModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ///////////////////////////////////////////////////////////////////////////
            // Original scaffolding code
            ///////////////////////////////////////////////////////////////////////////            
            // Student = await _context.Students.SingleOrDefaultAsync(m => m.ID == id);
            
            ///////////////////////////////////////////////////////////////////////////
            // FirstOrDefaultAsync is more efficient at fetching one entity
            ///////////////////////////////////////////////////////////////////////////
            //Student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id);
            
            ///////////////////////////////////////////////////////////////////////////            
            //FindAsync is a good choice when selecting an entity from the primary key
            ///////////////////////////////////////////////////////////////////////////            
            Student = await _context.Students.FindAsync(id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var studentToUpdate = await _context.Students.FindAsync(id);

            if (await TryUpdateModelAsync<Student>(
                studentToUpdate,
                "student",
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        } 
    }
}
