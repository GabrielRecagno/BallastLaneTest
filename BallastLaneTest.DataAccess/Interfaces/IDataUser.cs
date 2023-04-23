using BallastLaneTest.Models;

namespace BallastLaneTest.Data.Interfaces
{
    public interface IDataUser
    {
        Result CreateUser(User user);
        Result<User> AuthenticateUser(Login login);
    }
}
