using CDE_Exellence.Model;

namespace CDE_Exellence.Service.VisitFolder
{
    public interface IVisitService
    {
        IEnumerable<Visit> GetVisitsForUser(int userId);
    }
}
