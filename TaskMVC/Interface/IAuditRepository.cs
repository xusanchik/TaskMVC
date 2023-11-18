using TaskMVC.Entity;

namespace TaskMVC.Interface;
public interface IAuditRepository
{
    Task<List<AuditLog>> GetAllAudits();
    Task<List<AuditLog>> GetFiltered(string? fromDate, string? toDate);
    Task<List<AuditLog>> SortByUserName(string name);
    Task<AuditLogViewModel> Index(DateTime? fromDate, DateTime? toDate, string name);


}
