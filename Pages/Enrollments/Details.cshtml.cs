using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KUSYS_Demo.Data;
using KUSYS_Demo.Models;

namespace KUSYS_Demo.Pages.Enrollments
{
    public class DetailsModel : PageModel
    {
        private readonly KUSYS_Demo.Data.KUSYS_DemoContext _context;

        public DetailsModel(KUSYS_Demo.Data.KUSYS_DemoContext context)
        {
            _context = context;
        }

      public Enrollment Enrollment { get; set; }
        public Enrollment EnrollmentSt { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Enrollments == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments.Include(p => p.Course).FirstOrDefaultAsync(m => m.EnrollmentId == id);
            var enrollSt = await _context.Enrollments.Include(p => p.Student).FirstOrDefaultAsync(m => m.EnrollmentId == id);
            if (enrollment == null)
            {
                return NotFound();
            }
            else 
            {
                Enrollment = enrollment;
                EnrollmentSt = enrollSt;
            }
            return Page();
        }
    }
}
