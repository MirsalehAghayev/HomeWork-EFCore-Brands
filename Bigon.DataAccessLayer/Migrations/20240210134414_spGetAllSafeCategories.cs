using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bigon.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class spGetAllSafeCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[spGetAllSafeCategories]
    @id int
AS
BEGIN
	SET NOCOUNT ON;
    ;with cte as (
     select Id,[ParentId],[Name] from [dbo].[Categories] 
     where Id  = @id
     union ALL
     select c.Id,c.[ParentId],c.[Name] 
     from [dbo].[Categories] c
     join cte p on p.Id = c.ParentId
    ) 
    select * from dbo.Categories c
	left join cte r on c.Id = r.Id
	where r.Id is null;
END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[spGetAllSafeCategories]");
        }
    }
}
