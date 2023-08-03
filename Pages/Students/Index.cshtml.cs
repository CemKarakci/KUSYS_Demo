using KUSYS_Demo.Data;
using KUSYS_Demo.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace KUSYS_Demo.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly KUSYS_DemoContext _context;

        public IndexModel(KUSYS_DemoContext context)
        {
            _context = context;
        }

        public string CurrentSort { get; set; }
        public IList<Student> Student { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Student = await _context.Students.ToListAsync();
                Student = Student.OrderBy(x => x.LastName).ToList();
            }

        }

    }
}
