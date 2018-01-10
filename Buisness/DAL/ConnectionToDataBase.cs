using System;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Class For Basic Sql Server Connection
    /// </summary>
    public abstract class ConnectionToDataBase
    {
 
        // The Connection String
        readonly string connectionString;

        /// <summary>
        /// Create New SQL Connection From The Connection String
        /// </summary>
        protected SqlConnection GetConnection { get { return new SqlConnection(connectionString); } }

        protected ConnectionToDataBase(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool IsConnectionStringValid()
        {
            try
            {
                using (SqlConnection cn = GetConnection)
                {
                    cn.Open();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
