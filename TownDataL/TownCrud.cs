using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownDataL.Models;

namespace TownDataL;

public class TownCrud : ITownCrud
{

   private IDataAcsees dataAcsees=new DataAcsees();

   
    public List<Town> GetAll()
    {
        string sql = "select id,Townname from dbo.name;";
        return dataAcsees.LoodData<Town, dynamic>(sql, new { });
    }
    public Town GeByIdt(int id)
    {
        string sql = "select townname from dbo.name where id=@Id;";
        Town town = new Town();
        town.TownName = dataAcsees.LoodData<Town, dynamic>(sql, new { id }).FirstOrDefault().TownName;
        if (town.TownName == null)
        {
            throw new Exception("town not Found");
        }
        sql = @"select c.*
            from dbo.Climete c
            inner join ClimeteId ci on ci.CId=c.Id
            where ci.TownId=@Id;";
        town.Temputer = dataAcsees.LoodData<Town, dynamic>(sql, new { Id = id }).FirstOrDefault().Temputer;
        return town;

    }
    public void UpdatT(int id, int temputer)
    {
        string sql = "select cid from dbo.ClimeteId where Townid=@Id ";
        var cid = dataAcsees.LoodData<int, dynamic>(sql, new { Id = id });

        sql = "Update dbo.Climete set Temputer=@temputer where id =@Cid";
        dataAcsees.Excute(sql, new { temputer, Cid = cid });
    }

    public void creteTown(Town town)
    {
        string sql = "insert into dbo.name (TownName) values(@townName);";
        dataAcsees.Excute<dynamic>(sql, new { town.TownName });
        sql = "select id from dbo.name where TownName =@TownName;";
        var tid = dataAcsees.LoodData<Town, dynamic>(sql, new { town.TownName }).First().Id;


        sql = "insert into dbo.Climete (Temputer) values(@temputer); ";
        dataAcsees.Excute<dynamic>(sql, new { town.Temputer });
        sql = "select Cid from dbo.Clmete where Temputer=@temputer";
        var cid = dataAcsees.LoodData<int, dynamic>(sql, new {town.Temputer });



    }
}




       
