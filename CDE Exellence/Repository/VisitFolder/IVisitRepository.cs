using CDE_Exellence.Model;

namespace CDE_Exellence.Repository.VisitFolder
{
    public interface IVisitRepository
    {
        IEnumerable<Visit> GetAllVisits();
        IEnumerable<Visit> GetVisitsByRegionOrManager(string region, int managerId);
        IEnumerable<Visit> SearchAndFilterVisits(string keyword, DateTime? startDate, DateTime? endDate, string? status, string? distributor);
        IEnumerable<Visit> GetUpcomingVisits();
        IEnumerable<Visit> GetPastOrCancelledVisits();
        IEnumerable<Visit> GetVisitsByStatus(string status);
        void UpdateVisit(Visit visit);
        Visit GetVisitById(int visitId);
    }
}
