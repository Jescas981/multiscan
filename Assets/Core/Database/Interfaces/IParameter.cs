using System.Data.SqlClient;

namespace Multiscan.Database
{
    public interface IParameter
    {
        public SqlParameter apply();
    }
}
