using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;
using TaskMVC.Data;
using TaskMVC.Interface;

namespace TaskMVC.Controllers
{
    public class AuditViuwController : Controller
    {
        private readonly IAuditRepository _context;
        private readonly AppDbContext _appDbContext;
        public AuditViuwController(IAuditRepository context, AppDbContext appDbContext)
        { 
            _context = context;
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index(DateTime? fromDate, DateTime? toDate, string Name) => View(await _context.Index(fromDate, toDate, Name));
    }
}

