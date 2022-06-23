using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TestCrud.Data;
using TestCrud.Data.Entities;
using TestCrud.ViewModel;

namespace TestCrud.Pages.Cakes
{
    public class CreateModel : PageModel
    {
        private readonly CakeDBContext _DbContext;
        [BindProperty]
        public CakeVM CakeVm { get; set; }
        public CreateModel(CakeDBContext dbContext)
        {
            _DbContext = dbContext;
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var entry = _DbContext.Add(new Cake());
            entry.CurrentValues.SetValues(CakeVm);
            await _DbContext.SaveChangesAsync();
            return Redirect("home");
        }
    }
}
