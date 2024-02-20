using System.Data;

namespace TVScheduler.DataAccess.Helpers
{
    public interface IConnectionProvider
    {
        IDbConnection GetConnection();
    }
}
