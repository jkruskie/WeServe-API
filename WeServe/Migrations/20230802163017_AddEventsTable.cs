using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WeServe.Migrations
{
    /// <inheritdoc />
    public partial class AddEventsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "Description", "Details", "EndDate", "Image", "IsDeleted", "Location", "Name", "OrganizationId", "StartDate", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6440), 3, null, "Join us for a fun-filled summer festival!", "This event has no details.", new DateTime(2023, 8, 15, 22, 0, 0, 0, DateTimeKind.Unspecified), "https://placehold.co/320x320", false, "Central Park, New York", "Summer Festival", 1, new DateTime(2023, 8, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6441) },
                    { 2, new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6448), 3, null, "Learn about the latest tech trends and innovations.", "This event has no details.", new DateTime(2023, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), "https://placehold.co/320x320", false, "Tech Convention Center, San Francisco", "Tech Conference", 1, new DateTime(2023, 9, 20, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6448) },
                    { 3, new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6450), 3, null, "Admire stunning artworks from talented artists.", "This event has no details.", new DateTime(2023, 10, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), "https://placehold.co/320x320", false, "City Art Gallery, London", "Art Exhibition", 1, new DateTime(2023, 10, 10, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6451) },
                    { 4, new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6452), 3, null, "Run for a cause and support local charities.", "This event has no details.", new DateTime(2023, 11, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "https://placehold.co/320x320", false, "Riverside Park, Chicago", "Charity Run", 1, new DateTime(2023, 11, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6453) },
                    { 5, new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6454), 3, null, "Get into the holiday spirit with festive vendors.", "This event has no details.", new DateTime(2023, 12, 24, 20, 0, 0, 0, DateTimeKind.Unspecified), "https://placehold.co/320x320", false, "Town Square, Paris", "Holiday Market", 1, new DateTime(2023, 12, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6455) }
                });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6404), new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6405) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6413), new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6414) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { "a0aa8c37-b350-4d87-a5d2-c6378ccd0054", new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6033), "AQAAAAIAAYagAAAAEChYzb3mkPlVn5Tyx/rI21tD1qjPZX0TfsXi2sU1NQgKL/Iv5br8viEgc2zOGmO2Ww==", new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6085) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { "0b54ac36-ca26-4071-b07a-c224664f0db9", new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6124), "AQAAAAIAAYagAAAAEChYzb3mkPlVn5Tyx/rI21tD1qjPZX0TfsXi2sU1NQgKL/Iv5br8viEgc2zOGmO2Ww==", new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6126) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { "c9a85a1a-2677-445a-90ba-c6851141c38e", new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6129), "AQAAAAIAAYagAAAAEChYzb3mkPlVn5Tyx/rI21tD1qjPZX0TfsXi2sU1NQgKL/Iv5br8viEgc2zOGmO2Ww==", new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6130) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { "4478b4d7-e14f-4d11-955b-6a0c0599fe69", new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6134), "AQAAAAIAAYagAAAAEChYzb3mkPlVn5Tyx/rI21tD1qjPZX0TfsXi2sU1NQgKL/Iv5br8viEgc2zOGmO2Ww==", new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6135) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { "0d62ea1c-2277-452a-a969-e6ffc95cebd1", new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6138), "AQAAAAIAAYagAAAAEChYzb3mkPlVn5Tyx/rI21tD1qjPZX0TfsXi2sU1NQgKL/Iv5br8viEgc2zOGmO2Ww==", new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6139) });

            migrationBuilder.CreateIndex(
                name: "IX_Event_CreatedByUserId",
                table: "Event",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_OrganizationId",
                table: "Event",
                column: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6247), new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6248) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6254), new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6255) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { "b81c442c-9fcd-429b-b6d8-545421de3c4a", new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(5971), "AQAAAAIAAYagAAAAECYBVohtuErzY0eh3eEMaGpIil7pOpkFUnnlyQEh3ZFvVS0Zevf0cUSkGWUEWdoPiA==", new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6016) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { "5cbf0531-7c37-4970-9975-b74bb7012d48", new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6049), "AQAAAAIAAYagAAAAECYBVohtuErzY0eh3eEMaGpIil7pOpkFUnnlyQEh3ZFvVS0Zevf0cUSkGWUEWdoPiA==", new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6050) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { "a21b2ec1-fd89-4f90-b254-09342f452d26", new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6058), "AQAAAAIAAYagAAAAECYBVohtuErzY0eh3eEMaGpIil7pOpkFUnnlyQEh3ZFvVS0Zevf0cUSkGWUEWdoPiA==", new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6059) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { "ece300b8-74cb-4cbc-999a-1e87f9ac3aee", new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6062), "AQAAAAIAAYagAAAAECYBVohtuErzY0eh3eEMaGpIil7pOpkFUnnlyQEh3ZFvVS0Zevf0cUSkGWUEWdoPiA==", new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6063) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { "e9547dbb-06e2-4cc7-ab4f-4c73bb450854", new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6066), "AQAAAAIAAYagAAAAECYBVohtuErzY0eh3eEMaGpIil7pOpkFUnnlyQEh3ZFvVS0Zevf0cUSkGWUEWdoPiA==", new DateTime(2023, 8, 2, 12, 8, 30, 255, DateTimeKind.Local).AddTicks(6067) });
        }
    }
}
