using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WeServe.Migrations
{
    /// <inheritdoc />
    public partial class AddOrganizationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "Banner", "City", "CreatedAt", "DeletedAt", "Description", "Email", "IsDeleted", "Name", "PhoneNumber", "ProfilePicture", "State", "UpdatedAt", "Website", "ZipCode" },
                values: new object[,]
                {
                    { 1, "123 Main St.", null, "https://placehold.co/640x320", "City", new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6247), null, "This is the first organization.", "email@me.com", false, "Organization 1", "1234567890", "https://placehold.co/320x320", "State", new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6248), "https://www.google.com", "12345" },
                    { 2, "123 Main St.", null, "https://placehold.co/640x320", "City", new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6254), null, "This is the second organization.", "email@me.com", false, "Organization 2", "1234567890", "https://placehold.co/320x320", "State", new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6255), "https://www.google.com", "12345" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Age", "Bio", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "FirstName", "IsBanned", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "Major", "NormalizedEmail", "NormalizedUserName", "OrganizationId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "Role", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName", "Year" },
                values: new object[,]
                {
                    { 1, 0, 0, "This user has not set a bio yet.", "b81c442c-9fcd-429b-b6d8-545421de3c4a", new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(5971), null, "justin@jkruskie.com", false, "Justin", false, false, "Kruskie", false, null, "Undeclared", "JUSTIN@JKRUSKIE.COM", null, null, "AQAAAAIAAYagAAAAECYBVohtuErzY0eh3eEMaGpIil7pOpkFUnnlyQEh3ZFvVS0Zevf0cUSkGWUEWdoPiA==", null, false, "https://placehold.co/320x320", "Admin", null, false, new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6016), null, "Freshman" },
                    { 2, 0, 0, "This user has not set a bio yet.", "5cbf0531-7c37-4970-9975-b74bb7012d48", new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6049), null, "student@weserve.com", false, "Student", false, false, "Account", false, null, "Undeclared", "STUDENT@WESERVE.COM", null, null, "AQAAAAIAAYagAAAAECYBVohtuErzY0eh3eEMaGpIil7pOpkFUnnlyQEh3ZFvVS0Zevf0cUSkGWUEWdoPiA==", null, false, "https://placehold.co/320x320", "Student", null, false, new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6050), null, "Freshman" },
                    { 4, 0, 0, "This user has not set a bio yet.", "ece300b8-74cb-4cbc-999a-1e87f9ac3aee", new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6062), null, "moderator@weserve.com", false, "Moderator", false, false, "Account", false, null, "Undeclared", "MODERATOR@WESERVE.COM", null, null, "AQAAAAIAAYagAAAAECYBVohtuErzY0eh3eEMaGpIil7pOpkFUnnlyQEh3ZFvVS0Zevf0cUSkGWUEWdoPiA==", null, false, "https://placehold.co/320x320", "Moderator", null, false, new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6063), null, "Freshman" },
                    { 5, 0, 0, "This user has not set a bio yet.", "e9547dbb-06e2-4cc7-ab4f-4c73bb450854", new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6066), null, "admin@weserve.com", false, "Admin", false, false, "Account", false, null, "Undeclared", "ADMIN@WESERVE.COM", null, null, "AQAAAAIAAYagAAAAECYBVohtuErzY0eh3eEMaGpIil7pOpkFUnnlyQEh3ZFvVS0Zevf0cUSkGWUEWdoPiA==", null, false, "https://placehold.co/320x320", "Admin", null, false, new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6067), null, "Freshman" },
                    { 3, 0, 0, "This user has not set a bio yet.", "a21b2ec1-fd89-4f90-b254-09342f452d26", new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6058), null, "organization@weserve.com", false, "Organization", false, false, "Account", false, null, "Undeclared", "ORGANIZATION@WESERVE.COM", null, 1, "AQAAAAIAAYagAAAAECYBVohtuErzY0eh3eEMaGpIil7pOpkFUnnlyQEh3ZFvVS0Zevf0cUSkGWUEWdoPiA==", null, false, "https://placehold.co/320x320", "Organization", null, false, new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6059), null, "Freshman" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                table: "Users",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Users_OrganizationId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Users");
        }
    }
}
