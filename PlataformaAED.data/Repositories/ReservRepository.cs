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
    public class ReservRepository : IReservRepository
    {
        //CONNECCTION TO DB

        private readonly MySQLConfig _connectionString;
        public ReservRepository(MySQLConfig connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        //GET ALL
        public async Task<IEnumerable<Reserv>> GetAllReserv()
        {
            var db = dbConnection();
            db.Open();

            var sql = @"SELECT res_id, res_name,res_customer, res_date, res_sportArea FROM restable";

            return await db.QueryAsync<Reserv>(sql, new { });
        }

        //GET by ID
        public async Task<Reserv> GetReservById(int id)
        {
            var db = dbConnection();
            db.Open();

            var sql = @"SELECT res_id, res_name,res_customer, res_date, res_sportArea FROM restable WHERE res_id = @res_id";

            return await db.QueryFirstOrDefaultAsync<Reserv>(sql, new { res_id = id });

        }
        
        //POST
        public async Task<bool> PostReserv(Reserv reserv)
        {
            var db = dbConnection();
            db.Open();

            var sql = @"INSERT INTO restable (res_name,res_customer, res_date, res_sportArea) VALUES ( @res_name,@res_customer,@res_date,@res_sportArea) ";

            var result = await db.ExecuteAsync(sql, new { reserv.res_name, reserv.res_customer, reserv.res_date,reserv.res_sportArea });

            return result > 0;

        }

        //PUT
        public async Task<bool> PutReserv(Reserv reserv)
        {

            var db = dbConnection();
            db.Open();

            var sql = @"UPDATE reservations 
                    SET res_name = @res_name,
                        res_customer = @res_customer,
                        res_date = @res_date,
                        res_sportArea = @res_sportArea
                    WHERE res_id = @res_id";
            var parameters = new
            {
                reserv.res_name,
                reserv.res_customer,
                reserv.res_date,
                reserv.res_sportArea,
                reserv.res_id
            };
            var result = await db.ExecuteAsync(sql, parameters);

            return result > 0;

        }

        //Delete
        public async Task<bool> DelReserv(int id)
        {
            var db = dbConnection();
            db.Open();

            var sql = @"DELETE FROM restable WHERE res_id = @res_id";
            var result = await db.ExecuteAsync(sql, new { res_id = id });
            return result > 0;


        }
    }
}
