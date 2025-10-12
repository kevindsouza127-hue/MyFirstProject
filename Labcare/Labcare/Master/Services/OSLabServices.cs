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

    public interface IOSLab
    {
        Task<SortedList> OSLab(OSLab OSLab);
        Task<SortedList> UpdateOSLab(OSLab OSLab);
        Task<SortedList> DeleteOSLab(string OSLabName);
    }
    public class OSLabServices : IOSLab
    {

        private readonly IDapper _dapper;
        public OSLabServices(IDapper dapper)
        {
            _dapper = dapper;
        }
        public async Task<SortedList> OSLab(OSLab OSLab)

        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@pJsonData", Create_Json(OSLab), dbType: DbType.String);
            dbparams.Add("@pRid", DBNull.Value, dbType: DbType.Int64, direction: ParameterDirection.Output);
            dbparams.Add("@pResult", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            await Task.FromResult(_dapper.Insert<int>("Sp_InsertOSLab", dbparams, commandType: CommandType.StoredProcedure));
            SortedList output = new SortedList();
            output.Add("Rid", dbparams.Get<long>("@pRid"));
            output.Add("Result", dbparams.Get<string>("@pResult"));
            return output;
        }
        public async Task<SortedList> UpdateOSLab(OSLab OSLab)
        {
            var dbparams = new DynamicParameters();

            dbparams.Add("@pJsonData", Create_Json(OSLab), dbType: DbType.String);
            dbparams.Add("@pRid", DBNull.Value, dbType: DbType.Int64, direction: ParameterDirection.Output);
            dbparams.Add("@pResult", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            await Task.FromResult(_dapper.Insert<int>("Sp_UpdateOSLab", dbparams, commandType: CommandType.StoredProcedure));
            SortedList output = new SortedList();
            output.Add("Rid", dbparams.Get<long>("@pRid"));
            output.Add("Result", dbparams.Get<string>("@pResult"));
            return output;
        }

        public async Task<SortedList> DeleteOSLab(string OSLabName)

        {
            var dbparams = new DynamicParameters();
            dbparams.Add("@OSLabName", DBNull.Value, dbType: DbType.String);
            dbparams.Add("@pRid", DBNull.Value, dbType: DbType.Int64, direction: ParameterDirection.Output);
            dbparams.Add("@pResult", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            await Task.FromResult(_dapper.Insert<int>("Sp_DeleteOSLab", dbparams, commandType: CommandType.StoredProcedure));
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
