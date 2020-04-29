using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Dtos;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Repositories;
using Snickler.EFCore;
using System.Collections.Generic;
using System.Data;
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
			var connection = context.Database.GetDbConnection();
			try
			{

				using (var cmd = connection.CreateCommand())
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

		public IEnumerable<ProductTariffDto> GetProductTariffList(IEnumerable<int> ids)
		{
			var connection = context.Database.GetDbConnection();
			try
			{

				var productIds = new DataTable();
				productIds.Columns.Add("Id", typeof(int));
				foreach (var item in ids)
				{
					productIds.Rows.Add(item);
				}

				var parameter = new SqlParameter();
				parameter.ParameterName = "@ProductIds";
				parameter.SqlDbType = SqlDbType.Structured;
				parameter.Value = productIds;
				parameter.TypeName = "dbo.[ListOfId]";

				if (connection.State.Equals(ConnectionState.Closed))
				{
					connection.Open();
				}
				IList<ProductTariffDto> result = new List<ProductTariffDto>();
				context.LoadStoredProc("dbo.GetProductTariffList")
							 .WithSqlParam("ProductIds", parameter)
							 .ExecuteStoredProc((handler) =>
							 {
								 result = handler.ReadToList<ProductTariffDto>();
							 });

				return result.ToList();

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
