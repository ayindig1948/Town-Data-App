using TownDataL;

namespace TownApi
{
    public  static class StarUpConfig
    {
        public static void AddCustenSer(this WebApplicationBuilder bulder)
        {
        bulder.Services.AddSingleton<ITownCrud,TownCrud>();
        }
       

    }
}
