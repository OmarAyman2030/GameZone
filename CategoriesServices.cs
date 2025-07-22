
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
    public class CategoriesServices : Icategories
    {
        private readonly ApplicationDbContext _context;

        public CategoriesServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetSelectLists()
        {
            return _context.Categories.
                Select(c => new SelectListItem { Value = c.ID.ToString(), Text = c.Name })
                .OrderBy(c => c.Text)
                .AsNoTracking()
                .ToList();
        }
    }
}
