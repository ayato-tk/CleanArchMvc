using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) " +
                   "VALUES('DVD', 'Aparelho DVD', 7.45, 50, 'caderno1.jpg', 1)");
            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) " +
                   "VALUES('Mouse', 'Um mouse para computador', 20.45, 50, 'mouse1.jpg', 2)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
