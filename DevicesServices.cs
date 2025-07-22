
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
    public class DevicesServices : IDevices
    {
        private readonly ApplicationDbContext _context;
        public DevicesServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetSelectLists()
        {
            return _context.Devices.
                Select(d => new SelectListItem { Value = d.ID.ToString(), Text = d.Name })
                .OrderBy(d => d.Text)
                .AsNoTracking()
                .ToList();
        }
    }
}
