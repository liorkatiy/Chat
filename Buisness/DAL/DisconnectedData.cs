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
    /// Enum To Get Date By
    /// </summary>
    public enum DateBy
    {
        Day,
        Minute
    }

    /// <summary>
    /// Enum To Get Users By
    /// </summary>
    public enum UserBy
    {
        Email,
        Name,
        Connected,
        All
    }

    /// <summary>
    /// Class To Handle The Disconnected Data
    /// </summary>
    public class DisconnectedData : Data
    {
        public DisconnectedData(string connectionString) : base(connectionString) { }

        /// <summary>
        /// Delete User From DataBase
        /// </summary>
        /// <param name="email"></param>
        public void DeleteUser(string email)
        {
            ExecuteStoreProcedure(NonQuery, "DeleteUser",
                NvarChar("email", email));
        }

        /// <summary>
        /// Get Users By
        /// </summary>
        /// <param name="condition">The Condition For Getting Users</param>
        /// <param name="compareText">If Users Should Get By Name/Email Enter The Name/Email 
        ///                           Otherwise String.Empty</param>
        /// <returns></returns>
        public DataTable GetUserBy(UserBy condition, string compareText="")
        {
            return ExecuteStoreProcedure(GetTable, "GetUserBy",
                NvarChar("@str", compareText),
                NvarChar("@getBy", condition.ToString()));
        }

        /// <summary>
        /// Get User By Last Connection Date Day
        /// </summary>
        /// <param name="date">The Last Day The Users Logged In</param>
        /// <returns></returns>
        public DataTable GetUserBy(DateTime date)
        {
            return ExecuteStoreProcedure(GetTable, "GetUserBy",
                new SqlParameter("@date", SqlDbType.DateTime) { Value = date },
                NvarChar("@getBy", "LastConnectedDate"));
        }

        /// <summary>
        /// Get All The Private Messages Between Two People
        /// </summary>
        /// <param name="email">First User Email</param>
        /// <param name="recipientEmail">Another User Email</param>
        /// <returns></returns>
        public DataTable GetPrivateChat(string email,string recipientEmail)
        {
            return ExecuteStoreProcedure(GetTable, "GetPrivateChatMessages",
                NvarChar("@email", email),
                NvarChar("@recipientEmail", recipientEmail));
        }

        /// <summary>
        /// Get All The Private Chats User Had
        /// </summary>
        /// <param name="email">The User Email</param>
        /// <returns></returns>
        public List<string> GetPrivateChatUsers(string email)
        {
            DataTable dt = ExecuteStoreProcedure(GetTable, "GetPrivateChatUsers",
                NvarChar("@email", email));
            List<string> list = new List<string>();
            foreach (DataRow item in dt.Rows)
            {
                list.Add(item.ItemArray[0].ToString());
            }
            return list;
        }

        /// <summary>
        /// Get Message By Date
        /// </summary>
        /// <param name="date">The Date The Message Got Sent</param>
        /// <param name="compare">Search By Minute/Day</param>
        /// <returns></returns>
        public DataTable GetMessages(DateTime date,DateBy compare)
        {
            return ExecuteStoreProcedure(GetTable, "MessageByDate",
                new SqlParameter("@date", SqlDbType.DateTime) { Value = date },
                NvarChar("compareBy", compare.ToString()));
        }

        /// <summary>
        /// Get Message By Text
        /// </summary>
        /// <param name="text">The Text The Messsage Contains</param>
        /// <returns></returns>
        public DataTable GetMessages(string text)
        {
            return ExecuteStoreProcedure(GetTable, "MessageByText",
                NvarChar("@text", text));
        }

        //Return Data Table From Stored Procedure
        DataTable GetTable(SqlCommand com)
        {
            using (SqlDataAdapter adp = new SqlDataAdapter(com))
            {
                DataTable dataTable = new DataTable();
                adp.Fill(dataTable);
                return dataTable;
            }
        }
    }
}
