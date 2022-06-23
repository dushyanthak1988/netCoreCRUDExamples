using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestCrud.Data;
using TestCrud.Data.Entities;

namespace TestCrud.Pages.Cakes
{
    public class CakeHomeModel : PageModel
    {
        private readonly CakeDBContext _DbContext;

        public List<Cake> AllCakes = new List<Cake>();

        public CakeHomeModel(CakeDBContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            AllCakes = await _DbContext.Cake.ToListAsync();
            return Page();
        }
    }
}
