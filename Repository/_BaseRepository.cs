using Dapper;
using Dapper.FastCrud;
using Dapper.FastCrud.Configuration.StatementOptions.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using static Dapper.SqlMapper;

namespace BurgerBuilder.WebApi.Repository
{
	public class BaseRepository<TEntity>
	{
		public TimeSpan CommandTimeout { get; }
		private readonly ThreadLocal<IDbConnection> internalConnection;
		public BaseRepository()
		{
			this.internalConnection = new ThreadLocal<IDbConnection>(() => new SqlConnection(Repository.Configuration.ConnectionString));
			this.CommandTimeout = TimeSpan.FromSeconds(120);
		}
		
		protected IDbTransaction Transaction { get; set; }
		private IDbConnection Connection
		{
			get
			{
				if (Transaction != null)
				{
					return Transaction.Connection;
				}
				else
				{
					return internalConnection.Value;
				}
			}
		}
		protected int Execute(string sql, object parameters, IDbTransaction transaction)
		{
			return Connection.Execute(sql, parameters, transaction: transaction, commandTimeout: (int)CommandTimeout.TotalSeconds);
		}
		protected TEntity Get(TEntity entity) 
		{
			return Connection.Get(entity);
		}
		protected TEntity Get(TEntity entity, Action<ISelectSqlSqlStatementOptionsBuilder<TEntity>> statementOptions = null) 
		{
			return Connection.Get(entity, statementOptions);
		}
		protected GridReader QueryMultiple(string sql, object param = null)
		{
			return Connection.QueryMultiple(sql, param);
		}
		protected int GetQueryInt(string sql)
		{
			return Connection.QueryFirst<int>(sql);
		}
		protected IEnumerable<TEntity> Find(Action<IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>> statementOptions=null)
		{
			return Connection.Find<TEntity>(statementOptions);
		}
		protected void Insert(TEntity entity)
		{
			Connection.Insert(entity);
		}
		protected void Update(TEntity entity)
		{
			Connection.Update(entity);
		}
		protected bool Exitst(Action<IConditionalSqlStatementOptionsBuilder<TEntity>> statementOptions = null)
		{
			return Connection.Count<TEntity>(statementOptions) > 0;
		}
		
	}
}