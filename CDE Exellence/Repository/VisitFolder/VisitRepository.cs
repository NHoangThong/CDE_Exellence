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
        // Tìm kiếm và lọc lịch viếng thăm theo các tiêu chí
        public IEnumerable<Visit> SearchAndFilterVisits(string keyword, DateTime? startDate, DateTime? endDate, string? status, string? distributor)
        {
            var query = _context.Visits.AsQueryable();

            // Tìm kiếm theo từ khóa trong tiêu đề hoặc mô tả
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(v => v.Title.Contains(keyword) || v.Description.Contains(keyword));
            }

            // Lọc theo ngày bắt đầu và kết thúc
            if (startDate.HasValue && endDate.HasValue)
            {
                query = query.Where(v => v.VisitDate >= startDate.Value && v.VisitDate <= endDate.Value);
            }

            // Lọc theo trạng thái
            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(v => v.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
            }

            // Lọc theo nhà phân phối (giả sử có trường 'Region' đại diện cho nhà phân phối)
            if (!string.IsNullOrEmpty(distributor))
            {
                query = query.Where(v => v.Region.Equals(distributor, StringComparison.OrdinalIgnoreCase));
            }

            return query.ToList();
        }
        // Lấy tất cả lịch viếng thăm theo trạng thái
        public IEnumerable<Visit> GetVisitsByStatus(string status)
        {
            return _context.Visits
                .Where(v => v.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Lấy lịch viếng thăm trong quá khứ hoặc đã hủy
        public IEnumerable<Visit> GetPastOrCancelledVisits()
        {
            return _context.Visits
                .Where(v => v.VisitDate < DateTime.Now || v.Status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Lấy lịch viếng thăm trong tương lai hoặc chưa viếng thăm
        public IEnumerable<Visit> GetUpcomingVisits()
        {
            return _context.Visits
                .Where(v => v.VisitDate >= DateTime.Now && v.Status.Equals("Pending", StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        // Lấy chi tiết lịch viếng thăm theo ID
        public Visit GetVisitById(int visitId)
        {
            return _context.Visits.FirstOrDefault(v => v.Id == visitId);
        }

        // Cập nhật thông tin lịch viếng thăm
        public void UpdateVisit(Visit visit)
        {
            _context.Visits.Update(visit); // Cập nhật đối tượng vào cơ sở dữ liệu
            _context.SaveChanges(); // Lưu thay đổi
        }
    }
}
