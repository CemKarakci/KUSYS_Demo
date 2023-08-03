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

namespace KUSYS_Demo.Pages.Courses
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
        public Course Course { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var exist = await _context.Courses.AnyAsync(x => x.CourseCode == Course.CourseCode);
            if (exist)
            {
                ModelState.AddModelError("Duplicatecourse", "This Course Already Exists");
                return Page();
            }

            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
