using Microsoft.EntityFrameworkCore.Migrations;

namespace entity.Migrations
{
    public partial class upd4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "[Firstname] + ' '+ [Lastname]");

            migrationBuilder.CreateTable(
                name: "DepsEmps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepsEmps", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepsEmps");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Employees");
        }
    }
}
