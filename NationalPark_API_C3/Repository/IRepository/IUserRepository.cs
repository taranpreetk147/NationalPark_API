using NationalPark_API_C3.Models;

namespace NationalPark_API_C3.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string userName);
        User Authenticate(string userName, string password);
        User Register(string userName, string password);
    }
}
