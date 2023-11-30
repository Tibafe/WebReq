using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebReqV1.Migrations
{
    /// <inheritdoc />
    public partial class addQuantidadeRequisicao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Requisicoes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Requisicoes");
        }
    }
}
