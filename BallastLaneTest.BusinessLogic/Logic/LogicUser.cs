using System.Data;
using BallastLaneTest.Models;
using BallastLaneTest.BusinessLogic.Interfaces;
using BallastLaneTest.Data;
using BallastLaneTest.Data.Interfaces;

namespace BallastLaneTest.BusinessLogic.Logic
{
    internal class LogicUser : ILogicUser
    {
        //Singleton
        private static LogicUser instance = null;

        private IDataUser dataInstance;
        private LogicUser() {
            dataInstance = (new DataFactory()).getDataUser();
        }

        public static LogicUser getInstance()
        {
            if (instance == null)
                instance = new LogicUser();
            return instance;
        }

        //Operations
        public Result CreateUser(User user)
        {
            #region Validate the User object before creating it in the database
            if (string.IsNullOrEmpty(user.FirstName))
            {
                throw new ArgumentException("First name cannot be null or empty", nameof(user.FirstName));
            }

            if (string.IsNullOrEmpty(user.LastName))
            {
                throw new ArgumentException("Last name cannot be null or empty", nameof(user.LastName));
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                throw new ArgumentException("Email cannot be null or empty", nameof(user.Email));
            }

            if (string.IsNullOrEmpty(user.LoginName))
            {
                throw new ArgumentException("Login name cannot be null or empty", nameof(user.LoginName));
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentException("Password cannot be null or empty", nameof(user.Password));
            }
            #endregion

            Result result;

            try
            {
                result = dataInstance.CreateUser(user);
            }
            catch (Exception ex)
            {
                result = new Result()
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return result;
        }

        public Result<User> AuthenticateUser(Login login)
        {
            #region Validate the params before creating it in the database
            if (login == null)
            {
                throw new ArgumentException("Login information missing");
            }

            if (string.IsNullOrEmpty(login.LoginName))
            {
                throw new ArgumentException("First name cannot be null or empty");
            }

            if (string.IsNullOrEmpty(login.Password))
            {
                throw new ArgumentException("Last name cannot be null or empty");
            }
            #endregion

            Result<User> result;

            try
            {
                result = dataInstance.AuthenticateUser(login); 
            }
            catch (Exception ex)
            {
                result = new Result<User>()
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message                    
                };
            }

            return result;
        }

    }
}
