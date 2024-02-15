using NationalPark_API_C3.Models;

namespace NationalPark_API_C3.Repository.IRepository
{
    public interface ITrailRepository
    {
        ICollection<Trail> GetTrails();
        Trail GetTrail(int trailId);
        ICollection<Trail> GetTrailsInNationalPark(int nationalParkId);
        bool TrailExist(int trailid);
        bool TrailExists(string trailName);
        bool CreateTrail(Trail trail);
        bool UpdateTrail(Trail trail);
        bool DeleteTrail(Trail trail);
        bool Save();
    }
}
