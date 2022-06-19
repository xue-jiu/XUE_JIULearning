using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helloworld
{
    public class DatabaseHelper: IDisposable
    {
        private SqlConnection _connection;
        private string _connectionString = $"Data Source=localhost;Initial Catalog=course565;User ID=sa;Password=PaSSword12!;" +
            $"App=TestApp;" +
            $"Max Pool Size=100;" +
            $"Pooling=true;";

        public string GetDate()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
                Console.WriteLine("数据库开启");
            }
            var command = _connection.CreateCommand();
            command.CommandText = "SELECT getdate()";
            return command.ExecuteScalar().ToString();
        }

        //public void Close()
        //{
        //    Console.WriteLine("数据库关闭");
        //    _connection.Close();
        //    _connection.Dispose();
        //    _connection = null;
        //}

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    Console.WriteLine("数据库关闭");
                    _connection.Close();
                    _connection.Dispose();
                    _connection = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~DatabaseHelper()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
