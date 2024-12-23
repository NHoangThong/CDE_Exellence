using CDE_Exellence.Data;
using CDE_Exellence.Model;
using Microsoft.EntityFrameworkCore;

namespace CDE_Exellence.Repository.VisitFolder
{
    public class VisitRepository : IVisitRepository
    {
        private readonly AppDbContext _context;

        public VisitRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Visit> GetAllVisits()
        {
            return _context.Visits.ToList();
        }

        public IEnumerable<Visit> GetVisitsByRegionOrManager(string region, int managerId)
        {
            return _context.Visits
                .Where(v => v.Region == region || v.CreatedBy == managerId)
                .ToList();
        }
    }
}
