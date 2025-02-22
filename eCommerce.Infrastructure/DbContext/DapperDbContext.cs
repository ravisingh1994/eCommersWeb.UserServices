using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.DbContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;
        public DapperDbContext(IConfiguration configuration) 
        { 
          _configuration = configuration;

            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            
            //Create NPGSQL Connection with new ConnectionString

            _connection= new NpgsqlConnection(connectionString);

        }

        public IDbConnection dbConnection => _connection;
    }
}
