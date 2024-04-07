using FluentMigrator;

namespace BookAPI.Data.Migrations;

[Migration(03032024)]

public class CreateSchema : Migration
{
    public override void Up()
    {
        Create.Table("books")
           .WithColumn("id").AsInt32().PrimaryKey().Identity()
           .WithColumn("title").AsString(128).NotNullable()
           .WithColumn("author").AsString(128).NotNullable()
           .WithColumn("category").AsString(128).NotNullable()
           .WithColumn("publish_date").AsDateTime().NotNullable();
    }
    public override void Down()
    {

    }
}
