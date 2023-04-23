
namespace BallastLaneTest.Data
{
    internal class Connection
    {
        //Update Server with local DB Server name
        private static string connectionString = "Server=W5417;Database=BallastLaneTest;Integrated Security=True;TrustServerCertificate=true";

        internal static string ConnectionString
        { 
            get { return connectionString; } 
        }
    }
}
