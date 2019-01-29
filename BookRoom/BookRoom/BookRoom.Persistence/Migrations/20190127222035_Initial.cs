using Microsoft.EntityFrameworkCore.Migrations;

namespace BookRoom.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    NumberOfChairs = table.Column<int>(nullable: false),
                    SizeM2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
