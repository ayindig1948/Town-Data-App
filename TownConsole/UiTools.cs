using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TownDataL;
using TownDataL.Models;

namespace TownConsole;

public class UiTools
{

    public string GetConcettionString(string ConcettionName = "Defualt")
    {
        var Builder = new ConfigurationBuilder().
            SetBasePath(Directory.GetCurrentDirectory()).
            AddJsonFile("appsettings.json");
        var config = Builder.Build();
        var otpuat = config.GetConnectionString(ConcettionName);
        return otpuat;




    }
    public void GetAll(TownCrud crud)
    {
        var otput = crud.GetAll();
        foreach (var item in otput)
        {
            Console.WriteLine($"{item.Id}:{item.TownName}");
        }
    }
    public void GetbyId(TownCrud crud, int id)
    {
        var otput = crud.GeByIdt(id);
        Console.WriteLine($"{otput.TownName} {otput.Temputer}");
    }
    public void Updat(TownCrud crud, int id, int temp)
    {
        crud.UpdatT(id, temp);
    }
    public void CreateTown(Town town, TownCrud crud)
    {
        crud.creteTown(town);
    }
}