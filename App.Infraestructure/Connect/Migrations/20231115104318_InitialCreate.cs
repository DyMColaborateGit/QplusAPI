using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infraestructure.Connect.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Observacion",
                table: "tbl_com_ResultcomTecnicas",
                type: "nvarchar(1050)",
                maxLength: 1050,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1050)",
                oldMaxLength: 1050);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Observacion",
                table: "tbl_com_ResultcomTecnicas",
                type: "nvarchar(1050)",
                maxLength: 1050,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1050)",
                oldMaxLength: 1050,
                oldNullable: true);
        }
    }
}
