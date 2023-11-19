using Microsoft.AspNetCore.Mvc;
using TaskMVC.Interface;

namespace TaskMVC.Controllers
{
    public class AuditViuwController : Controller
    {
        private readonly IAuditRepository _context;
        public AuditViuwController(IAuditRepository context) => _context = context;
        public async Task<IActionResult> Index(DateTime? fromDate, DateTime? toDate, string Name) => View(await _context.Index(fromDate, toDate, Name));
    }
}

