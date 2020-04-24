using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.Migrations
{
	public partial class sp_GetProductTariffList : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			var sp = @"CREATE PROCEDURE GetProductTariffList 
										@ProductIds NVARCHAR(MAX)
									AS
									BEGIN

										SELECT 
											tariffs.* 
										FROM 
											Products products INNER JOIN 
											ProductsDeliveryGroups productsDeliveryGroups ON products.Id = productsDeliveryGroups.ProductId INNER JOIN 
											Tariffs tariffs ON productsDeliveryGroups.DeliveryGroupId = tariffs.DeliveryGroupId 
										WHERE products.Id IN (@ProductIds) 
										ORDER BY tariffs.EffectiveDate DESC

									END
									GO";

			migrationBuilder.Sql(sp);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			var command = "DROP PROCEDURE GetProductTariffList";
			migrationBuilder.Sql(command);
		}
	}
}
