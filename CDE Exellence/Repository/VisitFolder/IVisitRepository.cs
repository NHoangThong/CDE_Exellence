using CDE_Exellence.Model;

namespace CDE_Exellence.Repository.VisitFolder
{
    public interface IVisitRepository
    {
        IEnumerable<Visit> GetAllVisits();
        IEnumerable<Visit> GetVisitsByRegionOrManager(string region, int managerId);
    }
}
