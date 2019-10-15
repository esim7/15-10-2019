using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace Flights
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User(); 
            bool isActive = true;
            string key;
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            IConfigurationRoot configurationRoot = builder.Build();
            string providerName = configurationRoot.GetSection("AppConfig").GetChildren().Single().Value;

            DbProviderFactories.RegisterFactory(providerName, SqlClientFactory.Instance);

            List<Flight> flights = new List<Flight>
            {
                new Flight("A8885", "Астана", "Алматы"),
                new Flight("A4512", "Астана", "Караганда"),
                new Flight("A7845", "Астана", "Комтанай"),
                new Flight("A3213", "Астана", "Уральск"),
                new Flight("A7452", "Астана", "Шымкент"),
                new Flight("A9632", "Астана", "Тараз"),
                new Flight("A6547", "Астана", "Павлодар"),
                new Flight("A1244", "Астана", "Петропавловск"),
                new Flight("A8898", "Астана", "Кызылорда"),
                new Flight("A1211", "Астана", "Балхаш"),
            };
            List<Ticket> tickets = new List<Ticket>
            {
                new Ticket("A8885", "Астана", "Алматы", "kz45445", "", "" ),
                new Ticket("A4512", "Астана", "Караганда", "kz45123", "", "" ),
                new Ticket("A7845", "Астана", "Комтанай", "kz87874", "", "" ),
                new Ticket("A3213", "Астана", "Уральск", "kz96541", "", "" ),
                new Ticket("A7452", "Астана", "Шымкент", "kz84544", "", "" ),
                new Ticket("A9632", "Астана", "Тараз", "kz12121", "", "" ),
                new Ticket("A6547", "Астана", "Павлодар", "kz89877", "", "" ),
                new Ticket("A1244", "Астана", "Петропавловск", "kz141333", "", "" ),
                new Ticket("A8898", "Астана", "Кызылорда", "kz54654", "", "" ),
                new Ticket("A1211", "Астана", "Балхаш", "kz87898", "", "" )
            };

            do
            {
                Console.WriteLine("1. Регистрация пользователя \n2. Показать все билеты \n3. Показать все рейсы \n4. Купить билет");
                key = Console.ReadLine();
                switch (key)
                {
                    case "1":
                        {
                            user.Name = Console.ReadLine();
                            user.Password = Console.ReadLine();
                            user.PhoneNumber = Console.ReadLine();
                        }
                        break;
                    case "2":
                        {

                        }
                        break;
                    case "3":
                        {

                        }
                        break;
                    case "4":
                        {

                        }
                        break;
                }
                Console.ReadLine();
            } while (!isActive);

        }
    }
}
