﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.Migrations
{
	public partial class sp_alter_GetProductTariffList_Output : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			var sp = @"ALTER PROCEDURE GetProductTariffList 
									@ProductIds [dbo].[ListOfId] READONLY
								AS
								BEGIN

									SELECT 
										products.[Name] AS ProductName,
										products.[Id] AS ProductId,
										tariffs.* 
									FROM 
										Products products INNER JOIN 
										ProductsDeliveryGroups productsDeliveryGroups ON products.Id = productsDeliveryGroups.ProductId INNER JOIN 
										Tariffs tariffs ON productsDeliveryGroups.DeliveryGroupId = tariffs.DeliveryGroupId 
									WHERE products.Id IN (Select Id from @ProductIds) 
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
