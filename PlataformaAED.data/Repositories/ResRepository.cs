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
    public class ResRepository : IResRepository
    {
        //CONNECCTION TO DB

        private readonly MySQLConfig _connectionString;
        public ResRepository(MySQLConfig connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        //GET ALL
        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            var db = dbConnection();
            db.Open();

            var sql = @"SELECT res_id, res_name, res_location, res_customer, res_date, create_time FROM reservations";

            return await db.QueryAsync<Reservation>(sql, new { });

        }

        //GET by ID
        public async Task<Reservation> GetRes(int id)
        {

            var db = dbConnection();
            db.Open();

            var sql = @"SELECT res_id, res_name, res_location, res_customer, res_date, create_time FROM reservations WHERE res_id = @Id";

            return await db.QueryFirstOrDefaultAsync<Reservation>(sql, new { Id = id });
        }
        
        //POST
        public async Task<bool> PostRes(Reservation res)
        {

            var db = dbConnection();
            db.Open();

            var sql = @"INSERT INTO reservations ( res_name, res_location, res_customer, res_date) VALUES ( @Res_name, @Res_location, @Res_customer, @Res_date) ";

            var result = await db.ExecuteAsync(sql, new { res.res_name, res.res_location, res.res_customer, res.res_date });

            return result > 0;


        }
        
        //PUT 
        public async Task<bool> UpdateRes(Reservation res)
        {

            var db = dbConnection();
            db.Open();

            var sql = @"UPDATE reservations 
                    SET res_name = @res_name,
                        res_location = @res_location,
                        res_customer = @res_customer,
                        res_date = @res_date 
                    WHERE res_id = @Id";

            var parameters = new
            {
                res.res_name,
                res.res_location,
                res.res_customer,
                res.res_date,
                res.res_id 
            };

            var result = await db.ExecuteAsync(sql, parameters);

            return result > 0;

        }
       
        //DELETE
        public async Task<bool> DeleteRes(int id)
        {
            var db = dbConnection();
            db.Open();

            var sql = @"DELETE FROM reservations WHERE res_id = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = id });
            return result > 0;

        }

    }
}
