using Dapper;
using Labcare.Master.Classes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;
using System.Collections;

namespace Labcare.Master.Services
{
    public interface ICategories
    {
        Task<SortedList> Categories(Categories Categories);
        Task<SortedList> UpdateCategories(Categories Categories);
        Task<SortedList> DeleteCategories(string Category);
    }

    public class CategoriesServices : ICategories
    {
        private readonly IDapper _dapper;
        public CategoriesServices(IDapper dapper)
        {
            _dapper = dapper;
        }
        public async Task<SortedList> Categories(Categories Categories)

        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@pJsonData", Create_Json(Categories), dbType: DbType.String);
            dbparams.Add("@pRid", DBNull.Value, dbType: DbType.Int64, direction: ParameterDirection.Output);
            dbparams.Add("@pResult", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            await Task.FromResult(_dapper.Insert<int>("Sp_InsertCategory", dbparams, commandType: CommandType.StoredProcedure));
            SortedList output = new SortedList();
            output.Add("Rid", dbparams.Get<long>("@pRid"));
            output.Add("Result", dbparams.Get<string>("@pResult"));
            return output;
        }



        public async Task<SortedList> UpdateCategories(Categories Categories)

        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@pJsonData", Create_Json(Categories), dbType: DbType.String);
            dbparams.Add("@pRid", DBNull.Value, dbType: DbType.Int64, direction: ParameterDirection.Output);
            dbparams.Add("@pResult", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            await Task.FromResult(_dapper.Insert<int>("Sp_UpdateCategory", dbparams, commandType: CommandType.StoredProcedure));
            SortedList output = new SortedList();
            output.Add("Rid", dbparams.Get<long>("@pRid"));
            output.Add("Result", dbparams.Get<string>("@pResult"));
            return output;
        }


        public async Task<SortedList> DeleteCategories(string Category)

        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@Main", Category, dbType: DbType.String);
            dbparams.Add("@pRid", DBNull.Value, dbType: DbType.Int64, direction: ParameterDirection.Output);
            dbparams.Add("@pResult", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            await Task.FromResult(_dapper.Insert<int>("Sp_DeleteCategory", dbparams, commandType: CommandType.StoredProcedure));
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
