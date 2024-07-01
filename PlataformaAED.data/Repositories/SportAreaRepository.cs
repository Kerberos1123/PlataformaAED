using Dapper;
using MySql.Data.MySqlClient;
using PlataformaAED.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaAED.data.Repositories
{
    public class SportAreaRepository: ISportAreaRepository
    {
        //CONNECCTION TO DB

        private readonly MySQLConfig _connectionString;
        public SportAreaRepository(MySQLConfig connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        //GET ALL
        public async Task<IEnumerable<SportArea>> GetAllSportAreas()
        {
            var db = dbConnection();
            db.Open();

            var sql = @"SELECT sa_id, sa_location, sa_customer_name FROM sportareatable";

            return await db.QueryAsync<SportArea>(sql, new { });

        }
        
        //GET by ID
        public async Task<SportArea> GetSportAreaById(int id)
        {

            var db = dbConnection();
            db.Open();

            var sql = @"SELECT sa_id, sa_location, sa_customer_name FROM sportareatable WHERE sa_id = @sa_id";

            return await db.QueryFirstOrDefaultAsync<SportArea>(sql, new { sa_id = id });
        }
        
        //POST
        public async Task<bool> PostSportArea(SportArea sa)
        {

            var db = dbConnection();
            db.Open();

            var sql = @"INSERT INTO sportareatable (sa_location, sa_customer_name) VALUES ( @sa_location, @sa_customer_name) ";

            var result = await db.ExecuteAsync(sql, new { sa.sa_location, sa.sa_customer_name });

            return result > 0;


        }
        
        //PUT
        public async Task<bool> PutSportArea(SportArea sa)
        {
            var db = dbConnection();
            db.Open();

            var sql = @"UPDATE sportareatable 
                    SET sa_location = @sa_location,
                        sa_customer_name = @sa_customer_name
                    WHERE sa_id = @sa_id";
            var parameters = new
            {
                sa.sa_location,
                sa.sa_customer_name,
                sa.sa_id
            };

            var result = await db.ExecuteAsync(sql, parameters);
            return result > 0;

        }
        
        //DELETE
        public async Task<bool> DelSportArea(int id)
        {
            var db = dbConnection();
            db.Open();

            var sql = @"DELETE FROM sportareatable WHERE sa_id = @sa_id";
            var result = await db.ExecuteAsync(sql, new { sa_id = id });
            return result > 0;


        }
    }
}
