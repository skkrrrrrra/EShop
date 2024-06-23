using EShop.Data.Common;
using FluentMigrator;

namespace EShop.Data.Migrations;

[Migration(1, "Identity tables")]
public class UserTable : SqlMigration
{
	protected override string GetDownSql(IServiceProvider services)
	{
		return "";
	}

	protected override string GetUpSql(IServiceProvider services)
	{
		return "";
	}
}