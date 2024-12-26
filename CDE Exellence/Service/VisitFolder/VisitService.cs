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
        // Tìm kiếm và lọc các lịch viếng thăm theo các tiêu chí
        public IEnumerable<Visit> SearchAndFilterVisits(string keyword, DateTime? startDate, DateTime? endDate, string? status, string? distributor)
        {
            return _visitRepository.SearchAndFilterVisits(keyword, startDate, endDate, status, distributor);
        }

        // Lọc các lịch viếng thăm theo trạng thái
        public IEnumerable<Visit> GetVisitsByStatus(string status)
        {
            return _visitRepository.GetVisitsByStatus(status);
        }

        // Lọc lịch viếng thăm trong quá khứ hoặc đã hủy
        public IEnumerable<Visit> GetPastOrCancelledVisits()
        {
            return _visitRepository.GetPastOrCancelledVisits();
        }

        // Lọc lịch viếng thăm trong tương lai hoặc chưa viếng thăm
        public IEnumerable<Visit> GetUpcomingVisits()
        {
            return _visitRepository.GetUpcomingVisits();
        }
        // Lấy chi tiết lịch viếng thăm
        public Visit GetVisitDetails(int visitId)
        {
            var visit = _visitRepository.GetVisitById(visitId); // Gọi phương thức trong repository
            if (visit == null)
            {
                throw new Exception("Visit not found");
            }
            return visit;
        }

        // Cập nhật thông tin lịch viếng thăm
        public Visit UpdateVisit(int visitId, Visit visit)
        {
            var existingVisit = _visitRepository.GetVisitById(visitId);
            if (existingVisit == null)
            {
                throw new Exception("Visit not found");
            }

            // Cập nhật thông tin lịch viếng thăm
            existingVisit.Title = visit.Title;
            existingVisit.Description = visit.Description;
            existingVisit.VisitDate = visit.VisitDate;
            existingVisit.Status = visit.Status;

            // Lưu vào cơ sở dữ liệu
            _visitRepository.UpdateVisit(existingVisit);

            return existingVisit;
        }
    }
}
