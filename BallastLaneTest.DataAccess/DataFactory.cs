using BallastLaneTest.DataAccess;
using BallastLaneTest.Data.Interfaces;

namespace BallastLaneTest.Data
{
    public class DataFactory
    {
        public DataFactory() { }

        public IDataUser getDataUser()
        {
            try
            {
                return DataUser.getInstance();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IDataBook getDataBook()
        {
            try
            {
                return DataBook.getInstance();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}