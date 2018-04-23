using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public CreateModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        ///////////////////////////////////////////////////////
        // Original scaffolding code
        ///////////////////////////////////////////////////////
        // public async Task<IActionResult> OnPostAsync()
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return Page();
        //     }

        //     _context.Students.Add(Student);
        //     await _context.SaveChangesAsync();

        //     return RedirectToPage("./Index");
        // }
        ///////////////////////////////////////////////////////
        
        /**********************************************************************************************
            TryUpdateModelAsync<Student> tries to update the emptyStudent object using the posted
            form values from the PageContext property in the PageModel. 
            
            TryUpdateModelAsync only updates the properties listed
            (s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate).
            
            The second argument ("student", // Prefix) is the prefix uses to look up values.
            It's not case sensitive.
            
            The posted form values are converted to the types in the Student model using model binding.
            
            Using TryUpdateModel to update fields with posted values is a security best practice
            because it prevents overposting.
        ************************************************************************************************/
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyStudent = new Student();

            if (await TryUpdateModelAsync<Student>(
                emptyStudent,
                "student",   // Prefix for form value.
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                _context.Students.Add(emptyStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return null;
        }

    }
}