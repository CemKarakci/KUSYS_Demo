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
    public class IndexModel : PageModel
    {
        private readonly KUSYS_Demo.Data.KUSYS_DemoContext _context;

        public IndexModel(KUSYS_Demo.Data.KUSYS_DemoContext context)
        {
            _context = context;
        }

        public IList<Enrollment> Enrollment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Enrollments != null)
            {
                Enrollment = await _context.Enrollments
                .Include(e => e.Course)
                .Include(e => e.Student).ToListAsync();
                Enrollment = Enrollment.OrderBy(e => e.Student.StudentId).ToList();
            }
        }
    }
}
