using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestCrud.Data;
using TestCrud.ViewModel;

namespace TestCrud.Pages.Cakes
{
    public class DeleteCakeModel : PageModel
    {
        private readonly CakeDBContext _DbContext;
        public DeleteCakeModel(CakeDBContext dbContext)
        {
            _DbContext = dbContext;
        }

        public string ErrorMessage { get; set; }
        public CakeVM? CakeVm { get; set; }
        public async Task<IActionResult> OnGetAsync(int id, bool? saveChangesError)
        {
            CakeVm = await _DbContext.Cake
                    .Where(_ => _.ID == id)
                    .Select(_ =>
                    new CakeVM
                    {
                        Description = _.Description,
                        ID = _.ID,
                        Name = _.Name,
                        Price = _.Price
                    }).FirstOrDefaultAsync();

            if (CakeVm == null)
            {
                return NotFound();
            }
            if (saveChangesError ?? false)
            {
                ErrorMessage = $"Error to delete the record id - {id}";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var recordToDelete = await _DbContext.Cake.FindAsync(id);

            if (recordToDelete == null)
            {
                return Page();
            }

            try
            {
                _DbContext.Cake.Remove(recordToDelete);
                await _DbContext.SaveChangesAsync();
                return Redirect("/Cake/home");
            }
            catch
            {
                return Redirect($"/Cake/delete?id={id}&saveChangesError=true");
            }
        }
    }
}
