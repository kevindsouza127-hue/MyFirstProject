using Dapper;
using Labcare.Master.Classes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace Labcare.Master.Services
{
    public interface ITitle
    {
        Task<SortedList> AddTitle(Titles Title);
        Task<SortedList> UpdateTitle(Titles Title);
        Task<List<Titles>> GetTitle();

    }
    public class TitleServices : ITitle
    {

        private readonly IDapper _dapper;
        public TitleServices (IDapper dapper)
        {
            _dapper = dapper;
        }
        public async Task<SortedList> AddTitle(Titles Title)

        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@pJsonData", Create_Json(Title), dbType: DbType.String);
            dbparams.Add("@pRid", DBNull.Value, dbType: DbType.Int64, direction: ParameterDirection.Output);
            dbparams.Add("@pResult", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            await Task.FromResult(_dapper.Insert<int>("Sp_InsertTitle", dbparams, commandType: CommandType.StoredProcedure));
            SortedList output = new SortedList();
            output.Add("Rid", dbparams.Get<long>("@pRid"));
            output.Add("Result", dbparams.Get<string>("@pResult"));
            return output;
        }
        public async Task<SortedList> UpdateTitle(Titles Title)
        {
            var dbparams = new DynamicParameters();

            dbparams.Add("@pJsonData", Create_Json(Title), dbType: DbType.String);
            dbparams.Add("@pRid", DBNull.Value, dbType: DbType.Int64, direction: ParameterDirection.Output);
            dbparams.Add("@pResult", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            await Task.FromResult(_dapper.Insert<int>("Sp_UpdateTilte", dbparams, commandType: CommandType.StoredProcedure));
            SortedList output = new SortedList();
            output.Add("Rid", dbparams.Get<long>("@pRid"));
            output.Add("Result", dbparams.Get<string>("@pResult"));
            return output;
        }

        public async Task<List<Titles>> GetTitle()
        {
            var dbparams = new DynamicParameters();
            return await Task.FromResult(_dapper.GetAll<Titles>("sp_GetTitle", dbparams, commandType: CommandType.StoredProcedure));
           
        }



        private static string Create_Json<T>(T obj, string type = null)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(obj);
            if (type == "1")
            {
                JSONString = JSONString.Replace(@"\", "");
            }
            else
            {
                var token = JToken.Parse(JSONString);
                JSONString = token.ToString();
            }
            return JSONString;
        }




    }
}
