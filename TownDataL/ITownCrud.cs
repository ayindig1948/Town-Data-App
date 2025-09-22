using TownDataL.Models;

namespace TownDataL
{
    public interface ITownCrud
    {
        void creteTown(Town town);
        Town GeByIdt(int id);
        List<Town> GetAll();
        void UpdatT(int id, int temputer);
    }
}