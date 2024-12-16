using CDE_Exellence.Model;

namespace CDE_Exellence.Repository
{
    public interface IUserRepository
    {
       
        User? GetUserByEmail(string email);
      

    }
}
