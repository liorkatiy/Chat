using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Base DAL Class
    /// </summary>
    public class Data:ConnectionToDataBase
    {
        public Data(string connectionString) : base(connectionString) { }

        /// <summary>
        /// Create NvarChar Paramater
        /// </summary>
        /// <param name="paramaterName">The Paramater Name</param>
        /// <param name="Value">The String Value</param>
        /// <returns></returns>
        protected SqlParameter NvarChar(string paramaterName, string Value)
        {
            SqlParameter p = new SqlParameter(paramaterName, SqlDbType.NVarChar, Value.Length);
            p.Value = Value;
            return p;
        }

        /// <summary>
        /// Execute Store Procedure And Return Generic Type
        /// </summary>
        /// <typeparam name="T">The Type To Return From The Store Procedure</typeparam>
        /// <param name="Exec">Function That Take The SqlCommand And Returns T</param>
        /// <param name="name">The Store Procedure Name</param>
        /// <param name="paramaters">The Store Procedure Parameters</param>
        /// <returns></returns>
        protected T ExecuteStoreProcedure<T>(Func<SqlCommand, T> Exec, string name, params SqlParameter[] paramaters)
        {
            try
            {
                using (var sn = GetConnection)
                {
                    using (var com = new SqlCommand(name, sn)
                    { CommandType = CommandType.StoredProcedure })
                    {
                        for (int i = 0; i < paramaters.Length; i++)
                        {
                            com.Parameters.Add(paramaters[i]);
                        }
                        sn.Open();
                        return Exec(com);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Data "+e.Message);
                return default(T);
            }
        }

        /// <summary>
        /// Execute Non Query Stored Procedure
        /// </summary>
        /// <param name="com">The Stored Procedure</param>
        /// <returns>The Number Of Rows Affected</returns>
        protected int NonQuery(SqlCommand com)
        {
            return com.ExecuteNonQuery();
        }
    }
}