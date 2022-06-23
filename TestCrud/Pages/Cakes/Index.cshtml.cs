using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestCrud.Data;
using TestCrud.Data.Entities;

namespace TestCrud.Pages.Cakes
{
    public class IndexModel : PageModel
    {
        private readonly CakeDBContext _context;
        public List<Cake> AllCakes = new List<Cake>();
        protected IndexModel(CakeDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            AllCakes = await _context.Cakes.ToListAsync();
            return Page();
        }
    }
}
