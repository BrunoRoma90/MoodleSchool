using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySchool
{
    internal class Generic
    {
        public string GetConnectionString()
        {

            string connectionString = @"Server=localhost\SQLEXPRESS;Database=Teste;Trusted_Connection=True;Integrated Security=True;";
            return connectionString;
        }
    }
}
