
namespace TownDataL
{
    public interface IDataAcsees
    {
        void Excute<T>(string sqlStatmi, T Parma);
        List<T> LoodData<T, U>(string sqlStatmi, U parma);
    }
}