using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestCrud.Data;
using TestCrud.Data.Entities;
using TestCrud.ViewModel;

namespace TestCrud.Pages.Cakes
{
    public class EditCakeModel : PageModel
    {
        private CakeDBContext _DbContext;
        public EditCakeModel(CakeDBContext dbContext)
        {
            _DbContext = dbContext;
        }

        [BindProperty]
        public CakeVM? CakeVm { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            CakeVm = await _DbContext.Cake
                    .Where(_ => _.id == id)
                    .Select(_ =>
                    new CakeVM
                    {
                        Description = _.Description,
                        id = _.id,
                        Name = _.Name,
                        Price = _.Price
                    }).FirstOrDefaultAsync();

            if (CakeVm == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var cakeToUpdate = await _DbContext.Cake.FindAsync(id);

            if (cakeToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Cake>(
                cakeToUpdate,
                "CakeVm",
                c => c.Name, c => c.Description, c => c.Price
            ))
            {
                await _DbContext.SaveChangesAsync();
                return Redirect("home");
            }

            return Page();
        }
    }
}
