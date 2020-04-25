using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.Migrations
{
	public partial class udt_ListOfId : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			var udt = @"CREATE TYPE [dbo].[ListOfId] AS TABLE
								(
									Id INT NOT NULL
								)";

			migrationBuilder.Sql(udt);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			var command = "DROP TYPE [dbo].[ListOfId]";
			migrationBuilder.Sql(command);
		}
	}
}
