using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Npgsql;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Test.Controllers
{
    public class NewController : Controller
    {
        private readonly string connectionString = "Host=localhost,5432,1433;Database=Test;Username=sa1;Password=Qaz_xsw12;";

        [HttpGet("/new")]
        public IActionResult Index()
        {
            var newsTitles = new List<string>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                var command = new NpgsqlCommand("SELECT \"NewId\", \"Number\" FROM \"public\".\"News\"", connection);



                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int newId = reader.GetInt32(0);
                        newsTitles.Add(newId.ToString());

                    }
                }
            }

            // Pass list to view
            return View(newsTitles);
        }
    }
}