using BallastLaneTest.Models;

namespace BallastLaneTest.BusinessLogic.Interfaces
{
    public interface ILogicUser
    {
        Result CreateUser(User user);
        Result<User> AuthenticateUser(Login login);
    }
}
