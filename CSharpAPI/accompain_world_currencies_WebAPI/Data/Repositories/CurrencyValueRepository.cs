using accompain_world_currencies_WebAPI.Application.Interfaces;
using accompain_world_currencies_WebAPI.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.OData.Edm;
using Npgsql;
using System.Data;

namespace accompain_world_currencies_WebAPI.Data.Repositories
{
    public class CurrencyValueRepository : ICurrencyValueRepository
    {
        private readonly IConfiguration _configuration;

        public CurrencyValueRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Delete(string date)
        {
            try
            {
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("Connection");
                NpgsqlDataReader myReader;

                using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    string query = @"insert into currencies(date_id, name, value) values (@date_id, @name, @value)";

                    using (NpgsqlCommand mycommand = new NpgsqlCommand(query, myCon))
                    {
                        myReader = mycommand.ExecuteReader();
                        table.Load(myReader);

                        myReader.Close();
                    }
                     myCon.Close();
                }

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public CurrencyValues GetByDate(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Save(CurrencyValues obj)
        {
            try
            {
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("Connection");
                NpgsqlDataReader myReader;

                using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    foreach (var item in obj.Currencies)
                    {
                        string query = @"insert into currencies(date_id, name, value) values (@date_id, @name, @value)";

                        using (NpgsqlCommand mycommand = new NpgsqlCommand(query, myCon))
                        {
                            mycommand.Parameters.AddWithValue("@date_id", Date.Now);
                            mycommand.Parameters.AddWithValue("@name", item.Name);
                            mycommand.Parameters.AddWithValue("@value", item.Value);

                            myReader = mycommand.ExecuteReader();
                            table.Load(myReader);

                            myReader.Close();
                        }
                    }
                    myCon.Close();
                }

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }

        }

        public CurrencyValues Update(CurrencyValues obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
