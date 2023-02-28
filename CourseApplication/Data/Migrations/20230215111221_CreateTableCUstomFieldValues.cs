using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableCUstomFieldValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.DropColumn(
                name: "Value",
                table: "CustomField");

            migrationBuilder.CreateTable(
                name: "CustomFieldsValues",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomFieldId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldsValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomFieldsValues_CustomField_CustomFieldId",
                        column: x => x.CustomFieldId,
                        principalTable: "CustomField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomFieldsValues_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldsValues_CustomFieldId",
                table: "CustomFieldsValues",
                column: "CustomFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldsValues_ItemId",
                table: "CustomFieldsValues",
                column: "ItemId");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropTable(
                name: "CustomFieldsValues");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "CustomField",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");*/
        }
    }
}
