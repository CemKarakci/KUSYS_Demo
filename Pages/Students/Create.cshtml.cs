using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KUSYS_Demo.Data;
using KUSYS_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace KUSYS_Demo.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly KUSYS_Demo.Data.KUSYS_DemoContext _context;

        public CreateModel(KUSYS_Demo.Data.KUSYS_DemoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var exist = await _context.Students.AnyAsync(x => x.FirstName == Student.FirstName) &&
               await _context.Students.AnyAsync(x => x.LastName == Student.LastName);
            if (exist)
            {
                ModelState.AddModelError("DuplicateStudent", "This student Already Exists");
                return Page();

            }

            var emptyStudent = new Student();

            if (await TryUpdateModelAsync<Student>(
                emptyStudent,
                "student",   // Prefix for form value.
                s => s.FirstName, s => s.LastName, s => s.BirthDay))
            {
                _context.Students.Add(emptyStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
