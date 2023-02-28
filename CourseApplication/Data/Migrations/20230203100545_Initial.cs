using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
/*            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserStatuses_StatusId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserStatuses",
                table: "UserStatuses");

            migrationBuilder.RenameTable(
                name: "UserStatuses",
                newName: "UserStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserStatus",
                table: "UserStatus",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Them",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Them", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collection",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumericalFieldName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumericalFieldName2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumericalFieldName3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StringFieldName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StringFieldName2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StringFieldName3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextFieldName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextFieldName2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextFieldName3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFieldName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFieldName2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFieldName3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogicalFieldName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogicalFieldName2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogicalFieldName3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThemeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThemId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collection_Them_ThemId",
                        column: x => x.ThemId,
                        principalTable: "Them",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumericalFieldValue1 = table.Column<float>(type: "real", nullable: true),
                    NumericalFieldValue2 = table.Column<float>(type: "real", nullable: true),
                    NumericalFieldValue3 = table.Column<float>(type: "real", nullable: true),
                    StringFieldValue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StringFieldValue2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StringFieldValue3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextFieldValue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextFieldValue2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextFieldValue3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateFieldValue1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateFieldValue2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateFieldValue3 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LogicalFieldValue1 = table.Column<bool>(type: "bit", nullable: true),
                    LogicalFieldValue2 = table.Column<bool>(type: "bit", nullable: true),
                    LogicalFieldValue3 = table.Column<bool>(type: "bit", nullable: true),
                    CollectionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Collection_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collection",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserCollection",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CollectionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCollection", x => new { x.UserId, x.CollectionId });
                    table.ForeignKey(
                        name: "FK_UserCollection_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCollection_Collection_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemTag",
                columns: table => new
                {
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TagId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTag", x => new { x.ItemId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ItemTag_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserItemComment",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserItemComment", x => new { x.ItemId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserItemComment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserItemComment_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserItemLike",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LikeField = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserItemLike", x => new { x.ItemId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserItemLike_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserItemLike_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collection_ThemId",
                table: "Collection",
                column: "ThemId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CollectionId",
                table: "Item",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTag_TagId",
                table: "ItemTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCollection_CollectionId",
                table: "UserCollection",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserItemComment_UserId",
                table: "UserItemComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserItemLike_UserId",
                table: "UserItemLike",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserStatus_StatusId",
                table: "AspNetUsers",
                column: "StatusId",
                principalTable: "UserStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserStatus_StatusId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ItemTag");

            migrationBuilder.DropTable(
                name: "UserCollection");

            migrationBuilder.DropTable(
                name: "UserItemComment");

            migrationBuilder.DropTable(
                name: "UserItemLike");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DropTable(
                name: "Them");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserStatus",
                table: "UserStatus");

            migrationBuilder.RenameTable(
                name: "UserStatus",
                newName: "UserStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserStatuses",
                table: "UserStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserStatuses_StatusId",
                table: "AspNetUsers",
                column: "StatusId",
                principalTable: "UserStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);*/
        }
    }
}
