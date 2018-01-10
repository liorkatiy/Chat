using System;
using System.Data.SqlClient;
using System.Data;
using ChatData;
namespace DAL
{
    /// <summary>
    /// Class To Handle The Connected Data
    /// </summary>
    public class ConnectedData : Data, IDisposable
    {
        MessageHandler handler;

        public ConnectedData(string connectionString):base(connectionString)
        {
            handler = new MessageHandler(2.3,4.7, connectionString);
        }

        /// <summary>
        /// AddMessage To The DataBase
        /// </summary>
        /// <param name="msg">The Message</param>
        /// <param name="email">The Sender Email</param>
        public void AddMessage(Message msg, string email)
        {
            handler.Add(new MessageDB(msg, email));
        }

        /// <summary>
        /// AddMessage To The Database With Recipient Email
        /// </summary>
        /// <param name="msg">The Mesage</param>
        /// <param name="email">The sender Email</param>
        /// <param name="recipientEmail">The Recipient Email</param>
        public void AddMessage(Message msg, string email, string recipientEmail)
        {
            handler.Add(new MessageDB(msg, email, recipientEmail));
        }

        /// <summary>
        /// Reset All The Users In The DataBase To Not Connected
        /// </summary>
        public void ResetAllUsers()
        {
            ExecuteStoreProcedure(NonQuery, "ResetAllUsers");
        }

        /// <summary>
        /// Add User To The DataBase
        /// </summary>
        /// <param name="entry">The Client Info</param>
        public void AddUser(RegisterInfo entry)
        {
            ExecuteStoreProcedure(NonQuery, "AddUser",
                NvarChar("@email", entry.Email),
                NvarChar("@password", entry.Password));
        }

        /// <summary>
        /// Delete User From DataBase
        /// </summary>
        /// <param name="Email">The User Email</param>
        public void DeleteUser(string Email)
        {
            ExecuteStoreProcedure(NonQuery, "DeleteUser",
                NvarChar("@email", Email));
        }

        /// <summary>
        /// Check If The Email And Password Match
        /// </summary>
        /// <param name="info">The Login Info</param>
        /// <returns>True If The Email And Password Match</returns>
        public bool VerifyUser(LoginInfo info,out string errorMsg)
        {
            SqlParameter error = new SqlParameter("@error", SqlDbType.NVarChar, 30)
            { Direction = ParameterDirection.Output };
             Error result= ExecuteStoreProcedure(CheckLoginVerification, "VerifyUser",
                NvarChar("@email", info.Email),
                NvarChar("@password", info.Password),
                error);
            errorMsg = result.Message;
            return result.Critical;
        }

        /// <summary>
        /// Check If The DataBase Contains The User Email
        /// </summary>
        /// <param name="Email">User Email</param>
        /// <returns>True In The DataBase Contains The User</returns>
        public bool ContainsUser(string Email)
        {
            return ExecuteStoreProcedure(Scalar, "ContainsUser",
                NvarChar("@email", Email));
        }

        /// <summary>
        /// Login The User By Setting Connected To True And Last Connected Time To The Currrent Time
        /// </summary>
        /// <param name="email">The Userr Email</param>
        /// <param name="name">The User Name</param>
        public void UserLogin(string email,string name,int id)
        {
            ExecuteStoreProcedure(NonQuery, "UserLogin",
                NvarChar("@email", email),
                NvarChar("@nickname", name),
                new SqlParameter("@ID", id));
        }

        /// <summary>
        /// Logout The User Setting Connected To False And ID To Null
        /// </summary>
        /// <param name="Email">User Email</param>
        public void UserLogOut(string Email)
        {
            ExecuteStoreProcedure(NonQuery, "UserLogOut",
                NvarChar("@Email", Email));
        }

        /// <summary>
        /// Add Group To GroupChat Table
        /// </summary>
        /// <param name="name">Group Name</param>
        /// <param name="email">The Group Creator Email</param>
        /// <param name="id">The Group ID</param>
        public void AddGroup(string name,string email, Guid id)
        {
            ExecuteStoreProcedure(NonQuery, "AddGroup",
                new SqlParameter("@id", SqlDbType.UniqueIdentifier) { Value = id },
                NvarChar("@name", name),
                NvarChar("@email", email));
        }

        //Execute Store Procedure And Returns Scalar If 0 Than No Item Found 
        bool Scalar(SqlCommand com)
        {
            return (int)com.ExecuteScalar() == 1;
        }

        //return Error Struct Containing If The Verification Was Ok 
        //And String Of The Error If The Verification Failed
        Error CheckLoginVerification(SqlCommand com)
        {
            bool canLogin = (bool)com.ExecuteScalar();
            string error = com.Parameters["@error"].Value.ToString();
            return new Error(error, canLogin);
        }

        /// <summary>
        /// Dispose Of The ConnectedData
        /// </summary>
        public void Dispose()
        {
            handler.Close();
        }
    }
}