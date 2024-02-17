using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bigon.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpAllNewSchemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Views",
                table: "BlogPosts");

            migrationBuilder.RenameColumn(
                name: "ApprovedBy",
                table: "BlogPosts",
                newName: "PublishedBy");

            migrationBuilder.RenameColumn(
                name: "ApprovedAt",
                table: "BlogPosts",
                newName: "PublishedAt");

            migrationBuilder.AlterColumn<string>(
                name: "SmallName",
                table: "Sizes",
                type: "varchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sizes",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Colors",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HexCode",
                table: "Colors",
                type: "varchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(7)",
                oldMaxLength: 7,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_CategoryId",
                table: "BlogPosts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Categories_CategoryId",
                table: "BlogPosts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Categories_CategoryId",
                table: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_CategoryId",
                table: "BlogPosts");

            migrationBuilder.RenameColumn(
                name: "PublishedBy",
                table: "BlogPosts",
                newName: "ApprovedBy");

            migrationBuilder.RenameColumn(
                name: "PublishedAt",
                table: "BlogPosts",
                newName: "ApprovedAt");

            migrationBuilder.AlterColumn<string>(
                name: "SmallName",
                table: "Sizes",
                type: "varchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sizes",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Colors",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "HexCode",
                table: "Colors",
                type: "varchar(7)",
                maxLength: 7,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(7)",
                oldMaxLength: 7);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "BlogPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
