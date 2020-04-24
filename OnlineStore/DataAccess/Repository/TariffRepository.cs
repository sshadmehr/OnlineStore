using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Models;
using OnlineStore.Domain.Respsitories;
using System.Data;
using System.Data.Common;

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

					if (connection.State.Equals(ConnectionState.Closed)) { connection.Open(); }

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

	}
}
