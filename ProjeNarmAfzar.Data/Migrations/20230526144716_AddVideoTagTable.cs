using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeNarmAfzar.Data.Migrations
{
    public partial class AddVideoTagTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideoTags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoId = table.Column<long>(type: "bigint", nullable: false),
                    TagTitle = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoTags_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoTags_VideoId",
                table: "VideoTags",
                column: "VideoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoTags");
        }
    }
}
