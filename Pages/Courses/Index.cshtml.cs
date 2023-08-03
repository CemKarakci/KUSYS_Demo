using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KUSYS_Demo.Data;
using KUSYS_Demo.Models;

namespace KUSYS_Demo.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly KUSYS_Demo.Data.KUSYS_DemoContext _context;

        public IndexModel(KUSYS_Demo.Data.KUSYS_DemoContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Courses != null)
            {
                Course = await _context.Courses.ToListAsync();
                Course = Course.OrderBy(e => e.CourseId).ToList();
            }
        }
    }
}
