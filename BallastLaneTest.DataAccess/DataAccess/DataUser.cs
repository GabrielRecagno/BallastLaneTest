using BallastLaneTest.Data.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using BallastLaneTest.Models;
using BallastLaneTest.Data;

namespace BallastLaneTest.DataAccess
{
    internal class DataUser : IDataUser
    {
        //Singleton
        private static DataUser instance = null;

        private DataUser() { }

        public static DataUser getInstance()
        {
            if (instance == null)
                instance = new DataUser();
            return instance;
        }

        //Operations
        public Result CreateUser(User user)
        {
            Result result = new Result();

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("CreateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FirstName", user.FirstName);
                        command.Parameters.AddWithValue("@LastName", user.LastName);
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@LoginName", user.LoginName);
                        command.Parameters.AddWithValue("@Password", user.Password);

                        connection.Open();
                        command.ExecuteNonQuery();
                        result.IsSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public Result<User> AuthenticateUser(Login login)
        {
            Result<User> result = new Result<User>();
            var user = new User();

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("AuthenticateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@LoginName", login.LoginName);
                        command.Parameters.AddWithValue("@Password", login.Password);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet);

                            if (dataSet.Tables[0].Rows.Count > 0)
                            {
                                DataRow row = dataSet.Tables[0].Rows[0];

                                user = new User
                                {
                                    FirstName = (string)row["FirstName"],
                                    LastName = (string)row["LastName"],
                                    Email = (string)row["Email"],
                                    LoginName = (string)row["LoginName"]
                                };
                                result.IsSuccess = true;
                                result.Data = user;
                            }
                            else
                            {
                                result.IsSuccess = false;
                                result.ErrorMessage = "Incorrect User/Password";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

    }
}
