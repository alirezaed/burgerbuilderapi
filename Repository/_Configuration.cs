using Dapper.FastCrud;
using BurgerBuilder.WebApi.DataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BurgerBuilder.WebApi.Repository
{
	public static class Configuration
	{
		public static string ConnectionString = ConfigurationManager.ConnectionStrings["JHCS"].ConnectionString;
		public static void RegisterEntities()
		{
			OrmConfiguration.DefaultDialect = SqlDialect.MsSql;
			OrmConfiguration.GetDefaultEntityMapping<UserDataModel>()
				.SetTableName("brg_Users")
				.SetProperty(user => user.Id, prop => prop
					.SetPrimaryKey()
					.SetDatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity));

			OrmConfiguration.GetDefaultEntityMapping<OrderDataModel>()
				.SetTableName("brg_Orders")
				.SetProperty(user => user.Id, prop => prop
					.SetPrimaryKey().SetDatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity));

			Migrate();
		}
		private static void Migrate()
		{
			try
			{
				var cnx = new SqlConnection(ConnectionString);
				var evolve = new Evolve.Evolve(cnx,c=> log(c))
				{
					Command = Evolve.Configuration.CommandOptions.Migrate,
					Driver = "sqlserver",
					ConnectionString = ConnectionString,
					Locations = new List<string> { "Sql_Scripts" }
				};

				evolve.Migrate();
			}
			catch (Exception ex)
			{
				//_logger.LogCritical("Database migration failed.", ex);
				throw;
			}
		}
		static void log(string x)
		{
			string xx = "asdas";

			//asd
		}
	}
}