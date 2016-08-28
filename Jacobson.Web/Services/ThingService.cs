using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Jacobson.Web.Models.Domain;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace Jacobson.Web.Services
{
    public class ThingService
    {
        public static async Task<int> Create(Thing thing)
        {
            int id = -1;

            //get connection string from web.config
            string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                if (sqlConnection.State == ConnectionState.Closed) {
                    await sqlConnection.OpenAsync();
                }
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "[dbo].[Thing_Create]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Name", thing.Name);
                sqlCommand.Parameters.AddWithValue("@Description", thing.Description);

                object returnedObject = await sqlCommand.ExecuteScalarAsync();
                int.TryParse(returnedObject.ToString(), out id);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open) {
                    sqlConnection.Close();
                }
            }

            return id;
        }

        public static async Task<List<Thing>> GetAll()
        {
            List<Thing> allThings = new List<Thing>();

            //get connection string from web.config
            string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    await sqlConnection.OpenAsync();
                }
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "[dbo].[Thing_GetAll]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                IDataReader dataReader = await sqlCommand.ExecuteReaderAsync();

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
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
            finally {
                if (sqlConnection.State == ConnectionState.Closed) {
                    sqlConnection.Close();
                }
            }

            return allThings;
        }
    }
}