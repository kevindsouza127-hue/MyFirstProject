using Dapper;
using Labcare.Master.Classes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections;
using System.Data;

namespace Labcare.Master.Services
{
    public interface IReasons    
    {
        Task<SortedList> Reasons(Reasons Reasons);
        Task<SortedList> UpdateReasons(Reasons Reasons);
        Task<SortedList> DeleteReasons(string Reason);
    }

    public class ReasonsServices : IReasons
    {
        private readonly IDapper _dapper;
        public ReasonsServices(IDapper dapper)
        {
            _dapper = dapper;
        }
        public async Task<SortedList> Reasons(Reasons Reasons)

        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@pJsonData", Create_Json(Reasons), dbType: DbType.String);
            dbparams.Add("@pRid", DBNull.Value, dbType: DbType.Int64, direction: ParameterDirection.Output);
            dbparams.Add("@pResult", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            await Task.FromResult(_dapper.Insert<int>("Sp_InsertReasons", dbparams, commandType: CommandType.StoredProcedure));
            SortedList output = new SortedList();
            output.Add("Rid", dbparams.Get<long>("@pRid"));
            output.Add("Result", dbparams.Get<string>("@pResult"));
            return output;
        }



        public async Task<SortedList> UpdateReasons(Reasons Reasons)

        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@pJsonData", Create_Json(Reasons), dbType: DbType.String);
            dbparams.Add("@pRid", DBNull.Value, dbType: DbType.Int64, direction: ParameterDirection.Output);
            dbparams.Add("@pResult", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            await Task.FromResult(_dapper.Insert<int>("Sp_UpdateReasons", dbparams, commandType: CommandType.StoredProcedure));
            SortedList output = new SortedList();
            output.Add("Rid", dbparams.Get<long>("@pRid"));
            output.Add("Result", dbparams.Get<string>("@pResult"));
            return output;
        }


        public async Task<SortedList> DeleteReasons(string Reason)

        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@Reason",Reasons, dbType: DbType.String);
            dbparams.Add("@pRid", DBNull.Value, dbType: DbType.Int64, direction: ParameterDirection.Output);
            dbparams.Add("@pResult", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            await Task.FromResult(_dapper.Insert<int>("Sp_DeleteReasons", dbparams, commandType: CommandType.StoredProcedure));
            SortedList output = new SortedList();
            output.Add("Rid", dbparams.Get<long>("@pRid"));
            output.Add("Result", dbparams.Get<string>("@pResult"));
            return output;
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
