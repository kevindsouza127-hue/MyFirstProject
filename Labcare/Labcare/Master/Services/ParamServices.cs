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
    
        public interface IParam
        {
            Task<SortedList> Param(Param Param);

            Task<SortedList> UpdateParam(Param Param);
            Task<SortedList> DeleteParam(string ParamName);
        }

        public class ParamServices : IParam
        {
            private readonly IDapper _dapper;
            public ParamServices(IDapper dapper)
            {
                _dapper = dapper;
            }
            public async Task<SortedList> Param(Param Param)

            {
                var dbparams = new DynamicParameters();
                dbparams.Add("@pJsonData", Create_Json(Param), dbType: DbType.String);
                dbparams.Add("@pRid", DBNull.Value, dbType: DbType.Int64, direction: ParameterDirection.Output);
                dbparams.Add("@pResult", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                await Task.FromResult(_dapper.Insert<int>("Sp_InsertParam", dbparams, commandType: CommandType.StoredProcedure));
                SortedList output = new SortedList();
                output.Add("Rid", dbparams.Get<long>("@pRid"));
                output.Add("Result", dbparams.Get<string>("@pResult"));
                return output;
            }



            public async Task<SortedList> UpdateParam(Param Param)

            {
                var dbparams = new DynamicParameters();
                dbparams.Add("@pJsonData", Create_Json(Param), dbType: DbType.String);
                dbparams.Add("@pRid", DBNull.Value, dbType: DbType.Int64, direction: ParameterDirection.Output);
                dbparams.Add("@pResult", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                await Task.FromResult(_dapper.Insert<int>("sp_UpdateParam", dbparams, commandType: CommandType.StoredProcedure));
                SortedList output = new SortedList();
                output.Add("Rid", dbparams.Get<long>("@pRid"));
                output.Add("Result", dbparams.Get<string>("@pResult"));
                return output;
            }


            public async Task<SortedList> DeleteParam(string ParamName)

            {
                var dbparams = new DynamicParameters();
                dbparams.Add("@TestName", ParamName, dbType: DbType.String);
                dbparams.Add("@pRid", DBNull.Value, dbType: DbType.Int64, direction: ParameterDirection.Output);
                dbparams.Add("@pResult", DBNull.Value, dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                await Task.FromResult(_dapper.Insert<int>("Sp_DeleteParam", dbparams, commandType: CommandType.StoredProcedure));
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
