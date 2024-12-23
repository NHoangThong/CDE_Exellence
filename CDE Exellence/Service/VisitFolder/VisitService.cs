using CDE_Exellence.Data;
using CDE_Exellence.Model;
using CDE_Exellence.Repository.VisitFolder;
using Microsoft.EntityFrameworkCore;

namespace CDE_Exellence.Service.VisitFolder
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitRepository;
        private readonly AppDbContext _context;

        public VisitService(IVisitRepository visitRepository, AppDbContext context)
        {
            _visitRepository = visitRepository;
            _context = context;
        }
        public IEnumerable<Visit> GetVisitsForUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null) throw new Exception("Người dùng không tồn tại.");

            var permission = _context.Permissions.FirstOrDefault(p => p.UserId == userId);

            if (permission != null && permission.AllAccess)
            {
                return _visitRepository.GetAllVisits();
            }

            return _visitRepository.GetVisitsByRegionOrManager(user.Region, userId);
        }
    }
}
