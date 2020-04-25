using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Respsitories;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace OnlineStore.DataAccess.Repository
{
	public class TariffRepository : BaseLogicalDeletableRepository<Tariff>, ITariffRepository
	{
		public TariffRepository(OnlineStoreContext context) : base(context)
		{

		}

		public int GetMinTariff(int productId)
		{
			DbConnection connection = context.Database.GetDbConnection();
			try
			{

				using (DbCommand cmd = connection.CreateCommand())
				{

					cmd.CommandText = "EXEC	 [dbo].[GetMinTariff] @ProductId = @ProductId";

					cmd.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.Int) { Value = productId });

					if (connection.State.Equals(ConnectionState.Closed))
					{
						connection.Open();
					}

					return (int)cmd.ExecuteScalar();
				}

			}
			finally
			{
				if (connection.State.Equals(ConnectionState.Open))
				{
					connection.Close();
				}
			}

		}

		public IEnumerable<Tariff> GetProductTariffList(IEnumerable<int> ids)
		{
			DbConnection connection = context.Database.GetDbConnection();
			try
			{

				DataTable productIds = new DataTable();
				productIds.Columns.Add("Id", typeof(int));
				foreach (var item in ids)
				{
					productIds.Rows.Add(item);
				}

				SqlParameter parameter = new SqlParameter();
				parameter.ParameterName = "@ProductIds";
				parameter.SqlDbType = SqlDbType.Structured;
				parameter.Value = productIds;
				parameter.TypeName = "dbo.[ListOfId]";

				if (connection.State.Equals(ConnectionState.Closed))
				{
					connection.Open();
				}

				return context.Tariffs.FromSqlRaw("EXEC [dbo].[GetProductTariffList] @ProductIds", parameter).ToList();

			}
			finally
			{
				if (connection.State.Equals(ConnectionState.Open))
				{
					connection.Close();
				}
			}
		}
	}
}
