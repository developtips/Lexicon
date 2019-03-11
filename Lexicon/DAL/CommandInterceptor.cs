using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;

namespace Ikco.Data
{
    public class CommandInterceptor : IDbCommandInterceptor
    {
        public void NonQueryExecuting(
            DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            System.Diagnostics.Debug.WriteLine(command.CommandText);
        }

        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            System.Diagnostics.Debug.WriteLine(command.CommandText);
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            System.Diagnostics.Debug.WriteLine(command.CommandText);
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            System.Diagnostics.Debug.WriteLine(command.CommandText);
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            System.Diagnostics.Debug.WriteLine(command.CommandText);
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            System.Diagnostics.Debug.WriteLine(command.CommandText);
        }
    }
}