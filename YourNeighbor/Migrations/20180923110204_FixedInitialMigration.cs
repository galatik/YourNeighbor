using Microsoft.EntityFrameworkCore.Migrations;

namespace YourNeighbor.Migrations
{
    public partial class FixedInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Area_City_CityId",
                table: "Area");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_FromUserId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_ToUserId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_UserArea_Area_AreaId",
                table: "UserArea");

            migrationBuilder.DropForeignKey(
                name: "FK_UserArea_AspNetUsers_UserId",
                table: "UserArea");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInterest_Interest_Interest",
                table: "UserInterest");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInterest_AspNetUsers_UserId",
                table: "UserInterest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInterest",
                table: "UserInterest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserArea",
                table: "UserArea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interest",
                table: "Interest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Area",
                table: "Area");

            migrationBuilder.RenameTable(
                name: "UserInterest",
                newName: "UserInterests");

            migrationBuilder.RenameTable(
                name: "UserArea",
                newName: "UserAreas");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "Interest",
                newName: "Interests");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameTable(
                name: "Area",
                newName: "Areas");

            migrationBuilder.RenameIndex(
                name: "IX_UserInterest_Interest",
                table: "UserInterests",
                newName: "IX_UserInterests_Interest");

            migrationBuilder.RenameIndex(
                name: "IX_UserArea_AreaId",
                table: "UserAreas",
                newName: "IX_UserAreas_AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_ToUserId",
                table: "Messages",
                newName: "IX_Messages_ToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_Text",
                table: "Messages",
                newName: "IX_Messages_Text");

            migrationBuilder.RenameIndex(
                name: "IX_Message_FromUserId",
                table: "Messages",
                newName: "IX_Messages_FromUserId");

            migrationBuilder.RenameIndex(
                name: "IX_City_Name",
                table: "Cities",
                newName: "IX_Cities_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Area_CityId",
                table: "Areas",
                newName: "IX_Areas_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Area_AreaName",
                table: "Areas",
                newName: "IX_Areas_AreaName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInterests",
                table: "UserInterests",
                columns: new[] { "UserId", "Interest" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAreas",
                table: "UserAreas",
                columns: new[] { "UserId", "AreaId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interests",
                table: "Interests",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Areas",
                table: "Areas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Cities_CityId",
                table: "Areas",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_FromUserId",
                table: "Messages",
                column: "FromUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_ToUserId",
                table: "Messages",
                column: "ToUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAreas_Areas_AreaId",
                table: "UserAreas",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAreas_AspNetUsers_UserId",
                table: "UserAreas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterests_Interests_Interest",
                table: "UserInterests",
                column: "Interest",
                principalTable: "Interests",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterests_AspNetUsers_UserId",
                table: "UserInterests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Cities_CityId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_FromUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ToUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAreas_Areas_AreaId",
                table: "UserAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAreas_AspNetUsers_UserId",
                table: "UserAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInterests_Interests_Interest",
                table: "UserInterests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInterests_AspNetUsers_UserId",
                table: "UserInterests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInterests",
                table: "UserInterests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAreas",
                table: "UserAreas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interests",
                table: "Interests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Areas",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "UserInterests",
                newName: "UserInterest");

            migrationBuilder.RenameTable(
                name: "UserAreas",
                newName: "UserArea");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameTable(
                name: "Interests",
                newName: "Interest");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameTable(
                name: "Areas",
                newName: "Area");

            migrationBuilder.RenameIndex(
                name: "IX_UserInterests_Interest",
                table: "UserInterest",
                newName: "IX_UserInterest_Interest");

            migrationBuilder.RenameIndex(
                name: "IX_UserAreas_AreaId",
                table: "UserArea",
                newName: "IX_UserArea_AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ToUserId",
                table: "Message",
                newName: "IX_Message_ToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_Text",
                table: "Message",
                newName: "IX_Message_Text");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_FromUserId",
                table: "Message",
                newName: "IX_Message_FromUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_Name",
                table: "City",
                newName: "IX_City_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Areas_CityId",
                table: "Area",
                newName: "IX_Area_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Areas_AreaName",
                table: "Area",
                newName: "IX_Area_AreaName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInterest",
                table: "UserInterest",
                columns: new[] { "UserId", "Interest" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserArea",
                table: "UserArea",
                columns: new[] { "UserId", "AreaId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interest",
                table: "Interest",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Area",
                table: "Area",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Area_City_CityId",
                table: "Area",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_FromUserId",
                table: "Message",
                column: "FromUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_ToUserId",
                table: "Message",
                column: "ToUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserArea_Area_AreaId",
                table: "UserArea",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserArea_AspNetUsers_UserId",
                table: "UserArea",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterest_Interest_Interest",
                table: "UserInterest",
                column: "Interest",
                principalTable: "Interest",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterest_AspNetUsers_UserId",
                table: "UserInterest",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
