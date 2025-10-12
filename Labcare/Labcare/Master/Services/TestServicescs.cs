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


namespace Labcare.Master.Services
{
        public interface ITest
        {
        Task<SortedList> Test(Test Test);

        Task<SortedList> UpdateTest(Test Test);
        Task<SortedList> DeleteTest(string TestName);
        }

       public class TestServices: ITest
      {
           private readonly IDapper _dapper;
           public TestServices(IDapper dapper)
           {
            _dapper = dapper;
           }
           public async Task<SortedList> Test(Test Test)
        
           {
            var dbparams = new DynamicParameters();
            dbparams.Add("@pJsonData",Create_Json(Test), dbType: DbType.String);
            dbparams.Add("@pRid", DBNull.Value, dbType: DbType.Int64, direction: ParameterDirection.Output);
            dbparams.Add("@pResult", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            await Task.FromResult(_dapper.Insert<int>("Sp_CreateTest", dbparams, commandType: CommandType.StoredProcedure));
            SortedList output = new SortedList();
            output.Add("Rid", dbparams.Get<long>("@pRid"));
            output.Add("Result", dbparams.Get<string>("@pResult"));
            return output;
           }



        public async Task<SortedList> UpdateTest(Test Test)

        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@pJsonData", Create_Json(Test), dbType: DbType.String);
            dbparams.Add("@pRid", DBNull.Value, dbType: DbType.Int64, direction: ParameterDirection.Output);
            dbparams.Add("@pResult", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            await Task.FromResult(_dapper.Insert<int>("sp_UpdateTest", dbparams, commandType: CommandType.StoredProcedure));
            SortedList output = new SortedList();
            output.Add("Rid", dbparams.Get<long>("@pRid"));
            output.Add("Result", dbparams.Get<string>("@pResult"));
            return output;
        }


        public async Task<SortedList> DeleteTest(string TestName)

        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@TestName",TestName, dbType: DbType.String);
            dbparams.Add("@pRid", DBNull.Value, dbType: DbType.Int64, direction: ParameterDirection.Output);
            dbparams.Add("@pResult", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            await Task.FromResult(_dapper.Insert<int>("Sp_DeleteTest", dbparams, commandType: CommandType.StoredProcedure));
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
