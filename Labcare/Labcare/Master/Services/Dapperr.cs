using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;


namespace Labcare.Master.Services
{
    public class Dapperr : IDapper
    {
        private readonly IConfiguration _config;
        private string token = string.Empty;
        private List<Claim> additionalClaims;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Dapperr(IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            this._config = config;
            this._httpContextAccessor = httpContextAccessor;
        }

        public void Dispose()
        {
        }

        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int CommandTimeout = 300)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(GetDBInstance()))
                {
                    // throw new Exception();
                    return db.Query<int>(sp, parms, commandType: commandType, commandTimeout: CommandTimeout).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                // InsertDbExceptionLog("Get", sp, parms, ex);
                throw ex;
            }
            //throw new NotImplementedException();
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text, int CommandTimeout = 300)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(GetDBInstance()))
                {
                    // throw new Exception();
                    return db.Query<T>(sp, parms, commandType: commandType, commandTimeout: CommandTimeout).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                // InsertDbExceptionLog("Get", sp, parms, ex);
                throw ex;
            }
        }

        public async Task<T> GetAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text, int CommandTimeout = 300)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(GetDBInstance()))
                {
                    return await db.QuerySingleOrDefaultAsync<T>(sp, parms, commandType: commandType, commandTimeout: CommandTimeout);
                }
            }
            catch (Exception ex)
            {
                // InsertDbExceptionLog("Get", sp, parms, ex);
                throw ex;
            }
        }

        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int CommandTimeout = 300)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(GetDBInstance()))
                {
                    return db.Query<T>(sp, parms, commandType: commandType, commandTimeout: CommandTimeout).ToList();
                }
            }
            catch (Exception ex)
            {
                // InsertDbExceptionLog("GetAll", sp, parms, ex);
                throw ex;
            }
        }
        public async Task<List<T>> GetAllAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int CommandTimeout = 300)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(GetDBInstance()))
                {
                    return (await db.QueryAsync<T>(sp, parms, commandType: commandType, commandTimeout: CommandTimeout)).ToList();
                }
            }
            catch (Exception ex)
            {
                // InsertDbExceptionLog("GetAll", sp, parms, ex);
                throw ex;
            }
        }
        public DbConnection GetDbconnection()
        {
            return new SqlConnection(GetDBInstance());
        }

        public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int CommandTimeout = 300)
        {
            T result;
            try
            {
                using (IDbConnection db = new SqlConnection(GetDBInstance()))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();

                    result = db.Query<T>(sp, parms, commandType: commandType, commandTimeout: CommandTimeout).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                // InsertDbExceptionLog("Insert", sp, parms, ex);
                throw ex;
            }
            return result;
        }

        public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int CommandTimeout = 300)
        {
            T result;

            try
            {
                using (IDbConnection db = new SqlConnection(GetDBInstance()))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();

                    result = db.Query<T>(sp, parms, commandType: commandType, commandTimeout: CommandTimeout).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                // InsertDbExceptionLog("Update", sp, parms, ex);
                throw ex;
            }
            return result;
        }

        public SqlMapper.GridReader GetMultiple(IDbConnection db, string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int CommandTimeout = 300)
        {
            SqlMapper.GridReader result;
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                // result = db.QueryMultiple(sp, parms, commandType: commandType);
                result = db.QueryMultiple(sp, parms, commandType: commandType, commandTimeout: CommandTimeout);
            }
            catch (Exception ex)
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
                // InsertDbExceptionLog("GetMultiple", sp, parms, ex);
                throw ex;
            }
            return result;
        }
        public async Task<SqlMapper.GridReader> GetMultipleAsync(IDbConnection db, string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int CommandTimeout = 300)
        {
            SqlMapper.GridReader result;
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                result = await db.QueryMultipleAsync(sp, parms, commandType: commandType, commandTimeout: CommandTimeout);
            }
            catch (Exception ex)
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
                // InsertDbExceptionLog("GetMultiple", sp, parms, ex);
                throw ex;
            }
            return result;
        }

        private string GetDBInstance()
        {
            var sbCon = new StringBuilder();
            try
            {
                string conn = "Server=DESKTOP-CV49QB4\\Kevin;Database=Labcare_New;User ID=sa;Password=Pss@2024$;TrustServerCertificate=True;";
                return conn;
            }
            catch (Exception ex)
            {
                throw ex;

                throw new Exception("Database instance not initialized!");
            }
        }
    }
}
