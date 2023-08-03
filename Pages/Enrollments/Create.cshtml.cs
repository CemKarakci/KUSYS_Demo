using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KUSYS_Demo.Data;
using KUSYS_Demo.Models;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.ExceptionServices;
using Humanizer;
using NuGet.Protocol;
using Microsoft.EntityFrameworkCore;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace KUSYS_Demo.Pages.Enrollments
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
            
            
            ViewData["CourseId"] = new  SelectList(_context.Courses, "CourseId", "CourseCode");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName");

            return Page();
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var courseID = Enrollment.CourseId;
            var studentId = Enrollment.StudentId;
            var enrollment = _context.Enrollments.Where(s => s.CourseId == courseID).Where(s => s.StudentId == studentId).FirstOrDefault();
            if(enrollment != null)
            {
               ModelState.AddModelError("DuplicateEnrollment", "This Enrollment Already Exists");
               return Page();
            }
            var emptyEnrollment = new Enrollment();
            if (await TryUpdateModelAsync<Enrollment>(
                 emptyEnrollment,
                 "enrollment",   // Prefix for form value.
                 s => s.EnrollmentId, s=>s.CourseId, s =>s.StudentId))
            {
                    _context.Enrollments.Add(emptyEnrollment);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");

                
                
            }
            return Page();
        }


    }
}
