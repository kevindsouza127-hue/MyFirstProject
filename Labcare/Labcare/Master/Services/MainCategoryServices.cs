using Dapper;
using Labcare.Master.Classes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;
using System.Collections;


namespace Labcare.Master.Services
{
    public interface IMainCategory
    {
        Task<SortedList> MainCategory(MainCategory MainCategory);
        Task<SortedList> UpdateMainCategory(MainCategory MainCategory);
        Task<SortedList> DeleteMainCategory(string MainCategory);
    }

    public class MainCategoryServices : IMainCategory
    {
        private readonly IDapper _dapper;
        public MainCategoryServices(IDapper dapper)
        {
            _dapper = dapper;
        }
        public async Task<SortedList> MainCategory(MainCategory MainCategory)

        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@pJsonData", Create_Json(MainCategory), dbType: DbType.String);
            dbparams.Add("@pRid", DBNull.Value, dbType: DbType.Int64, direction: ParameterDirection.Output);
            dbparams.Add("@pResult", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            await Task.FromResult(_dapper.Insert<int>("Sp_InsertMainCategory", dbparams, commandType: CommandType.StoredProcedure));
            SortedList output = new SortedList();
            output.Add("Rid", dbparams.Get<long>("@pRid"));
            output.Add("Result", dbparams.Get<string>("@pResult"));
            return output;
        }



        public async Task<SortedList> UpdateMainCategory(MainCategory MainCategory)

        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@pJsonData", Create_Json(MainCategory), dbType: DbType.String);
            dbparams.Add("@pRid", DBNull.Value, dbType: DbType.Int64, direction: ParameterDirection.Output);
            dbparams.Add("@pResult", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            await Task.FromResult(_dapper.Insert<int>("Sp_UpdateMainCategory", dbparams, commandType: CommandType.StoredProcedure));
            SortedList output = new SortedList();
            output.Add("Rid", dbparams.Get<long>("@pRid"));
            output.Add("Result", dbparams.Get<string>("@pResult"));
            return output;
        }


        public async Task<SortedList> DeleteMainCategory(string MainCategory)

        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@Main",MainCategory, dbType: DbType.String);
            dbparams.Add("@pRid", DBNull.Value, dbType: DbType.Int64, direction: ParameterDirection.Output);
            dbparams.Add("@pResult", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            await Task.FromResult(_dapper.Insert<int>("Sp_DeleteMainCategory", dbparams, commandType: CommandType.StoredProcedure));
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
