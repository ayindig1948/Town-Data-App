using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TownDataL;

public class DataAcsees : IDataAcsees
{
    private IConfiguration _config;


    public DataAcsees(IConfiguration configuration)
    {
        _config = configuration;
    }

    public DataAcsees()
    {
    }

    public List<T> LoodData<T, U>(string sqlStatmi, U parma)
    {
        using (IDbConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TownData;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))//_config.GetConnectionString("Default")))
        {
            List<T> list = connection.Query<T>(sqlStatmi, parma).ToList();
            return list;
        }
    }
    public void Excute<T>(string sqlStatmi, T Parma)
    {
        using (IDbConnection connection = new SqlConnection(("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TownData;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")))//_config.GetConnectionString("Default"))))
        {
            connection.Execute(sqlStatmi, Parma);
        }
    }
}