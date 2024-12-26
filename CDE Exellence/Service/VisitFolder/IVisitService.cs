using CDE_Exellence.Model;

namespace CDE_Exellence.Service.VisitFolder
{
    public interface IVisitService
    {
        IEnumerable<Visit> GetVisitsForUser(int userId);
        IEnumerable<Visit> SearchAndFilterVisits(string keyword, DateTime? startDate, DateTime? endDate, string? status, string? distributor);
        IEnumerable<Visit> GetUpcomingVisits();
        IEnumerable<Visit> GetPastOrCancelledVisits();
        IEnumerable<Visit> GetVisitsByStatus(string status);
        Visit UpdateVisit(int visitId, Visit visit);
        Visit GetVisitDetails(int visitId);
    }
}
