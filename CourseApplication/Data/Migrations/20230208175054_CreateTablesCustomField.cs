using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTablesCustomField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Collection_Them_ThemId",
            //    table: "Collection");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Item_Collection_CollectionId",
            //    table: "Item");

            //migrationBuilder.DropTable(
            //    name: "Them");

            //migrationBuilder.DropIndex(
            //    name: "IX_Collection_ThemId",
            //    table: "Collection");

            //migrationBuilder.DropColumn(
            //    name: "ThemId",
            //    table: "Collection");

            //migrationBuilder.AlterColumn<double>(
            //    name: "NumericalFieldValue3",
            //    table: "Item",
            //    type: "float",
            //    nullable: true,
            //    oldClrType: typeof(float),
            //    oldType: "real",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<double>(
            //    name: "NumericalFieldValue2",
            //    table: "Item",
            //    type: "float",
            //    nullable: true,
            //    oldClrType: typeof(float),
            //    oldType: "real",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<double>(
            //    name: "NumericalFieldValue1",
            //    table: "Item",
            //    type: "float",
            //    nullable: true,
            //    oldClrType: typeof(float),
            //    oldType: "real",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "CollectionId",
            //    table: "Item",
            //    type: "nvarchar(450)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "ThemeId",
            //    table: "Collection",
            //    type: "nvarchar(450)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "TextFieldName3",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "TextFieldName2",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "TextFieldName1",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "StringFieldName3",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "StringFieldName2",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "StringFieldName1",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "NumericalFieldName3",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "NumericalFieldName2",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "NumericalFieldName1",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "LogicalFieldName3",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "LogicalFieldName2",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "LogicalFieldName1",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "DateFieldName3",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "DateFieldName2",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "DateFieldName1",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.CreateTable(
            //    name: "Theme",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Theme", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ValueType",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ValueType", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CustomField",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ValueTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        CollectionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CustomField", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CustomField_Collection_CollectionId",
            //            column: x => x.CollectionId,
            //            principalTable: "Collection",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CustomField_ValueType_ValueTypeId",
            //            column: x => x.ValueTypeId,
            //            principalTable: "ValueType",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Collection_ThemeId",
            //    table: "Collection",
            //    column: "ThemeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CustomField_CollectionId",
            //    table: "CustomField",
            //    column: "CollectionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CustomField_ValueTypeId",
            //    table: "CustomField",
            //    column: "ValueTypeId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Collection_Theme_ThemeId",
            //    table: "Collection",
            //    column: "ThemeId",
            //    principalTable: "Theme",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Item_Collection_CollectionId",
            //    table: "Item",
            //    column: "CollectionId",
            //    principalTable: "Collection",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Collection_Theme_ThemeId",
            //    table: "Collection");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Item_Collection_CollectionId",
            //    table: "Item");

            //migrationBuilder.DropTable(
            //    name: "CustomField");

            //migrationBuilder.DropTable(
            //    name: "Theme");

            //migrationBuilder.DropTable(
            //    name: "ValueType");

            //migrationBuilder.DropIndex(
            //    name: "IX_Collection_ThemeId",
            //    table: "Collection");

            //migrationBuilder.AlterColumn<float>(
            //    name: "NumericalFieldValue3",
            //    table: "Item",
            //    type: "real",
            //    nullable: true,
            //    oldClrType: typeof(double),
            //    oldType: "float",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<float>(
            //    name: "NumericalFieldValue2",
            //    table: "Item",
            //    type: "real",
            //    nullable: true,
            //    oldClrType: typeof(double),
            //    oldType: "float",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<float>(
            //    name: "NumericalFieldValue1",
            //    table: "Item",
            //    type: "real",
            //    nullable: true,
            //    oldClrType: typeof(double),
            //    oldType: "float",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "CollectionId",
            //    table: "Item",
            //    type: "nvarchar(450)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ThemeId",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "TextFieldName3",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "TextFieldName2",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "TextFieldName1",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "StringFieldName3",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "StringFieldName2",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "StringFieldName1",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "NumericalFieldName3",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "NumericalFieldName2",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "NumericalFieldName1",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "LogicalFieldName3",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "LogicalFieldName2",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "LogicalFieldName1",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "DateFieldName3",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "DateFieldName2",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "DateFieldName1",
            //    table: "Collection",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "ThemId",
            //    table: "Collection",
            //    type: "nvarchar(450)",
            //    nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "Them",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Them", x => x.Id);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Collection_ThemId",
            //    table: "Collection",
            //    column: "ThemId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Collection_Them_ThemId",
            //    table: "Collection",
            //    column: "ThemId",
            //    principalTable: "Them",
            //    principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Item_Collection_CollectionId",
            //    table: "Item",
            //    column: "CollectionId",
            //    principalTable: "Collection",
            //    principalColumn: "Id");
        }
    }
}
