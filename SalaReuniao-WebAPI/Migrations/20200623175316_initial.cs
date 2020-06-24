using Microsoft.EntityFrameworkCore.Migrations;

namespace SalaReuniao_WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    descricao = table.Column<string>(nullable: true),
                    capacidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    HoraInicio = table.Column<string>(nullable: true),
                    HoraFim = table.Column<string>(nullable: true),
                    SalaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendas_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "id", "capacidade", "descricao" },
                values: new object[] { 1, 4, "Sala Reuniao 1" });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "id", "capacidade", "descricao" },
                values: new object[] { 2, 6, "Sala Reuniao 2" });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "id", "capacidade", "descricao" },
                values: new object[] { 3, 8, "Sala Reuniao 3" });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "id", "capacidade", "descricao" },
                values: new object[] { 4, 10, "Sala Reuniao 4" });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "id", "capacidade", "descricao" },
                values: new object[] { 5, 12, "Sala Reuniao 5" });

            migrationBuilder.InsertData(
                table: "Agendas",
                columns: new[] { "Id", "Data", "HoraFim", "HoraInicio", "SalaId", "Titulo" },
                values: new object[] { 1, "06/06/2020", "08:00", "07:00", 1, "Reuniao Mensal" });

            migrationBuilder.InsertData(
                table: "Agendas",
                columns: new[] { "Id", "Data", "HoraFim", "HoraInicio", "SalaId", "Titulo" },
                values: new object[] { 2, "23/06/2020", "09:00", "08:00", 2, "Feedback" });

            migrationBuilder.InsertData(
                table: "Agendas",
                columns: new[] { "Id", "Data", "HoraFim", "HoraInicio", "SalaId", "Titulo" },
                values: new object[] { 3, "19/06/2020", "10:00", "08:00", 3, "Dailyng" });

            migrationBuilder.InsertData(
                table: "Agendas",
                columns: new[] { "Id", "Data", "HoraFim", "HoraInicio", "SalaId", "Titulo" },
                values: new object[] { 4, "16/06/2020", "11:00", "10:30", 4, "Sprint" });

            migrationBuilder.InsertData(
                table: "Agendas",
                columns: new[] { "Id", "Data", "HoraFim", "HoraInicio", "SalaId", "Titulo" },
                values: new object[] { 5, "01/07/2020", "12:00", "11:00", 5, "Backlog" });

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_SalaId",
                table: "Agendas",
                column: "SalaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
