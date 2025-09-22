// See https://aka.ms/new-console-template for more information
using TownConsole;
using TownDataL;
using TownDataL.Models;

Console.WriteLine("Hello, World!");
UiTools ui=new UiTools();
var cs=           ui  .GetConcettionString( );
Console.WriteLine(cs);
TownCrud crud=new TownCrud();
Town town = new Town() { TownName = "rio", Temputer = 102 };
ui.CreateTown(town, crud);
ui.GetAll(crud);
//ui.Updat(crud, 2, 95);
//
ui.GetbyId(crud, 3);