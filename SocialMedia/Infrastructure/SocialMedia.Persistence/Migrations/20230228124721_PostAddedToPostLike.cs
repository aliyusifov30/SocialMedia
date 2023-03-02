using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PostAddedToPostLike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostLikes_AspNetUsers_ToUserId",
                table: "PostLikes");

            migrationBuilder.DropIndex(
                name: "IX_PostLikes_ToUserId",
                table: "PostLikes");

            migrationBuilder.DropColumn(
                name: "ToUserId",
                table: "PostLikes");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "PostLikes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PostLikes_PostId",
                table: "PostLikes",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostLikes_Posts_PostId",
                table: "PostLikes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostLikes_Posts_PostId",
                table: "PostLikes");

            migrationBuilder.DropIndex(
                name: "IX_PostLikes_PostId",
                table: "PostLikes");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "PostLikes");

            migrationBuilder.AddColumn<string>(
                name: "ToUserId",
                table: "PostLikes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PostLikes_ToUserId",
                table: "PostLikes",
                column: "ToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostLikes_AspNetUsers_ToUserId",
                table: "PostLikes",
                column: "ToUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
