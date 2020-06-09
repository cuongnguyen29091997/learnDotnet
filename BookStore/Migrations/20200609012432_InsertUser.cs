using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class InsertUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("userdetails", new string[] {"id", "name", "email","password"}, new object[,]
            {
                {1, "Cường Nguyễn", "quoccuong@gmail.com", "123456" },
                {2, "Cường Nguyễn Quốc", "quoccuong1234@gmail.com", "123456" },
                {3, "Nguyễn Quốc Cường", "quoccuong123@gmail.com", "123456" }
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
