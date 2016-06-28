using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Jacobson.Web.Models.Domain;
using System.Data.SqlClient;
using System.Data;

namespace Jacobson.Web.Services
{
    public class ThingService
    {
        public static int Create(Thing thing)
        {
            //string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //SqlConnection sqlConnection = new SqlConnection(connectionString);
            //sqlConnection.Open();
            //SqlCommand sqlCommand = sqlConnection.CreateCommand();

            //await sqlConnection.OpenAsync();
            return 1;
        }

        public static List<Thing> GetAll()
        {
            List<Thing> allThings = new List<Thing>();

            //get connection string from web.config
            string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "[dbo].[Things_GetAll]";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            IDataReader dataReader = sqlCommand.ExecuteReader();

            while (dataReader.Read())
            {
                Thing thing = new Thing();
                int colpos = 0;

                thing.Id = dataReader.GetInt32(colpos++);
                thing.Name = dataReader.GetString(colpos++);
                thing.Description = dataReader.GetString(colpos++);
                allThings.Add(thing);
            }

            dataReader.Close();
            sqlConnection.Close();

            return allThings;
        }
    }
}