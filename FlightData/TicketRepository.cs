using Flights;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace FlightData
{
    public class TicketRepository
    {
        private readonly string connectionString;
        private readonly DbProviderFactory providerFactory;

        public TicketRepository(string connectionString, string providerName)
        {
            this.connectionString = connectionString;
            providerFactory = DbProviderFactories.GetFactory(providerName);
        }

        public void Add(Ticket ticket)
        {
            using (DbConnection connection = providerFactory.CreateConnection())
            using (DbCommand sqlCommand = connection.CreateCommand())
            {
                string query = $"insert into Flights (id, flightNumber, departureCity, arrivalCity, departuteTime, arrivalTime, number, place, class, flightId, price) values(@Id, " +
                        $"@FlightNumber, " +
                        $"@DepartureCity," +
                        $"@ArrivalCity);" +
                        $"DepartuteTime" +
                        $"ArrivalTime" +
                        $"Number" +
                        $"Place" +
                        $"Class" +
                        $"FlightId" +
                        $"Price";
                sqlCommand.CommandText = query;

                DbParameter parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.Guid;
                parameter.ParameterName = "@Id";
                parameter.Value = ticket.Id;
                sqlCommand.Parameters.Add(parameter);

                parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.String;
                parameter.ParameterName = "@FlightNumber";
                parameter.Value = ticket.FlightNumber;
                sqlCommand.Parameters.Add(parameter);

                parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.String;
                parameter.ParameterName = "@DepartureCity";
                parameter.Value = ticket.DepartureCity;
                sqlCommand.Parameters.Add(parameter);

                parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.String;
                parameter.ParameterName = "@ArrivalCity";
                parameter.Value = ticket.ArrivalCity;
                sqlCommand.Parameters.Add(parameter);

                parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.DateTime;
                parameter.ParameterName = "@DepartuteTime";
                parameter.Value = ticket.DepartuteTime;
                sqlCommand.Parameters.Add(parameter);

                parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.DateTime;
                parameter.ParameterName = "@ArrivalTime";
                parameter.Value = ticket.ArrivalTime;
                sqlCommand.Parameters.Add(parameter);

                parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.String;
                parameter.ParameterName = "@Number";
                parameter.Value = ticket.Number;
                sqlCommand.Parameters.Add(parameter);

                parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.String;
                parameter.ParameterName = "@Place";
                parameter.Value = ticket.Place;
                sqlCommand.Parameters.Add(parameter);

                parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.String;
                parameter.ParameterName = "@Class";
                parameter.Value = ticket.Class;
                sqlCommand.Parameters.Add(parameter);

                parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.Guid;
                parameter.ParameterName = "@FlightId";
                parameter.Value = ticket.FlightId;
                sqlCommand.Parameters.Add(parameter);

                parameter = providerFactory.CreateParameter();
                parameter.DbType = System.Data.DbType.Int32;
                parameter.ParameterName = "@Price";
                parameter.Value = ticket.Price;
                sqlCommand.Parameters.Add(parameter);

                connection.ConnectionString = connectionString;
                connection.Open();
            }
        }

        public void Delete(Ticket ticket)
        {
            using (DbConnection connection = providerFactory.CreateConnection())
            using (DbCommand sqlCommand = connection.CreateCommand())
            {
                string query = "DELETE FROM Tickets WHERE id = " + ticket.Id + ";";
                sqlCommand.CommandText = query;

                connection.ConnectionString = connectionString;
                connection.Open();
                DbDataReader sqlDataReader = sqlCommand.ExecuteReader();
            }
        }

        public ICollection<Ticket> GetAll()
        {
            using (DbConnection connection = providerFactory.CreateConnection())
            using (DbCommand sqlCommand = connection.CreateCommand())
            {
                string query = "select * from Tickets;";
                sqlCommand.CommandText = query;

                connection.ConnectionString = connectionString;
                connection.Open();
                DbDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Ticket> tickets = new List<Ticket>();
                while (sqlDataReader.Read())
                {
                    tickets.Add(new Ticket
                    {
                        Id = Guid.Parse(sqlDataReader["id"].ToString()),
                        FlightNumber = sqlDataReader["flightNumber"].ToString(),
                        DepartureCity = sqlDataReader["departureCity"].ToString(),
                        ArrivalCity = sqlDataReader["arrivalCity"].ToString(),
                        DepartuteTime = DateTime.Parse(sqlDataReader["departuteTime"].ToString()),
                        ArrivalTime = DateTime.Parse(sqlDataReader["arrivalTime"].ToString()),
                        Number = sqlDataReader["number"].ToString(),
                        Place = sqlDataReader["place"].ToString(),
                        Class = sqlDataReader["class"].ToString(),
                        FlightId = DateTime.Parse(sqlDataReader["flightId"].ToString())
                    });
                }
                return tickets;
            }
        }
    }
}
