
using BallastLaneTest.BusinessLogic.Interfaces;
using BallastLaneTest.BusinessLogic.Logic;

namespace BallastLaneTest.BusinessLogic
{
    public class BLFactory
    {
        public BLFactory() { }

        public ILogicUser getLogicUser()
        {
            try
            {
                return LogicUser.getInstance();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ILogicBook getLogicBook()
        {
            try
            {
                return LogicBook.getInstance();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}