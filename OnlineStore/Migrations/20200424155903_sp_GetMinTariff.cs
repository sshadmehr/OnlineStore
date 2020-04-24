﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.Migrations
{
	public partial class sp_GetMinTariff : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			var sp = @"CREATE PROCEDURE GetMinTariff 
										@ProductId INT
									AS
									BEGIN
										WITH MaxTarif (DeliveryType, DeliveryGroupId, EffectiveDate) As (SELECT
											Tariffs.DeliveryType,
											Tariffs.DeliveryGroupId,
											MAX(Tariffs.EffectiveDate) AS EffectiveDate

										FROM Tariffs

										GROUP BY Tariffs.DeliveryType, Tariffs.DeliveryGroupId) 

										Select 
											MIN(Tariffs.Price) AS Price
										from 
											MaxTarif
										INNER JOIN 
											ProductsDeliveryGroups
										ON 
											ProductsDeliveryGroups.DeliveryGroupId = MaxTarif.DeliveryGroupId
										INNER JOIN 
											Tariffs 
										ON 
											MaxTarif.DeliveryType = Tariffs.DeliveryType AND 
											MaxTarif.DeliveryGroupId = Tariffs.DeliveryGroupId AND 
											MaxTarif.EffectiveDate = Tariffs.EffectiveDate
										WHERE 
											ProductsDeliveryGroups.ProductId = @ProductId

									END";

			migrationBuilder.Sql(sp);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			var command = "DROP PROCEDURE GetMinTariff";
			migrationBuilder.Sql(command);
		}
	}
}