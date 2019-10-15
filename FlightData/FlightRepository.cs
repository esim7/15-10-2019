
using Flights;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace FlightData
{
    public class FlightRepository 
    {
        private readonly string connectionString;
        private readonly DbProviderFactory providerFactory;

        public FlightRepository(string connectionString, string providerName)
        {
            this.connectionString = connectionString;
            providerFactory = DbProviderFactories.GetFactory(providerName);
        }

        public void Add(Flight flight)
        {
            using (DbConnection connection = providerFactory.CreateConnection())
            using (DbCommand sqlCommand = connection.CreateCommand())
            {
                string query = $"insert into Flights (id, flightNumber, departureCity, arrivalCity, departuteTime, arrivalTime) values(@Id, " +
                        $"@FlightNumber, " +
                        $"@DepartureCity," +
                        $"@ArrivalCity);" +
                        $"DepartuteTime" +
                        $"ArrivalTime";
                sqlCommand.CommandText = query;

                DbParameter parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.Guid;
                parameter.ParameterName = "@Id";
                parameter.Value = flight.Id;
                sqlCommand.Parameters.Add(parameter);

                parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.String;
                parameter.ParameterName = "@FlightNumber";
                parameter.Value = flight.FlightNumber;
                sqlCommand.Parameters.Add(parameter);

                parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.String;
                parameter.ParameterName = "@DepartureCity";
                parameter.Value = flight.DepartureCity;
                sqlCommand.Parameters.Add(parameter);

                parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.String;
                parameter.ParameterName = "@ArrivalCity";
                parameter.Value = flight.ArrivalCity;
                sqlCommand.Parameters.Add(parameter);

                parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.DateTime;
                parameter.ParameterName = "@DepartuteTime";
                parameter.Value = flight.DepartuteTime;
                sqlCommand.Parameters.Add(parameter);

                parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.DateTime;
                parameter.ParameterName = "@ArrivalTime";
                parameter.Value = flight.ArrivalTime;
                sqlCommand.Parameters.Add(parameter);

                connection.ConnectionString = connectionString;
                connection.Open();

            }
        }

        public void Delete(Flight flight)
        {
            using (DbConnection connection = providerFactory.CreateConnection())
            using (DbCommand sqlCommand = connection.CreateCommand())
            {
                string query = "DELETE FROM Flights WHERE id = " + flight.Id + ";";
                sqlCommand.CommandText = query;

                connection.ConnectionString = connectionString;
                connection.Open();
                DbDataReader sqlDataReader = sqlCommand.ExecuteReader(); 
            }
        }

        public ICollection<Flight> GetAll()
        {
            using (DbConnection connection = providerFactory.CreateConnection())
            using (DbCommand sqlCommand = connection.CreateCommand())
            {
                string query = "select * from Flights;";
                sqlCommand.CommandText = query;

                connection.ConnectionString = connectionString;
                connection.Open();
                DbDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Flight> flights = new List<Flight>();
                while (sqlDataReader.Read())
                {
                    flights.Add(new Flight
                    {
                        Id = Guid.Parse(sqlDataReader["id"].ToString()),
                        FlightNumber = sqlDataReader["flightNumber"].ToString(),
                        DepartureCity = sqlDataReader["departureCity"].ToString(),
                        ArrivalCity = sqlDataReader["arrivalCity"].ToString(),
                        DepartuteTime = DateTime.Parse(sqlDataReader["departuteTime"].ToString()),
                        ArrivalTime = DateTime.Parse(sqlDataReader["arrivalTime"].ToString())
                    });
                }
                return flights;
            }
        }
    }
}
