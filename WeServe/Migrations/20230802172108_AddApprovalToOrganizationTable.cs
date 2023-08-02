using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeServe.Migrations
{
    /// <inheritdoc />
    public partial class AddApprovalToOrganizationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Organizations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(5053), new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(5054) });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(5062), new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(5062) });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(5064), new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(5065) });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(5066), new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(5067) });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(5069), new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(5069) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsApproved", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(5026), false, new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(5027) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsApproved", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(5033), false, new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(5034) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "Role", "UpdatedAt" },
                values: new object[] { "8ba170b7-6215-489e-9419-7b461ef0efc9", new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(4679), "AQAAAAIAAYagAAAAEClaPu/Uv3V4DO4shUhMj7nFQfI8sFHMZgzjX3YaDYoELc3adYt3x5MPWmzttr37hg==", "admin", new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(4728) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "Role", "UpdatedAt" },
                values: new object[] { "588521a9-0436-4552-924a-d2e60e31b6aa", new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(4758), "AQAAAAIAAYagAAAAEClaPu/Uv3V4DO4shUhMj7nFQfI8sFHMZgzjX3YaDYoELc3adYt3x5MPWmzttr37hg==", "student", new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(4762) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "Role", "UpdatedAt" },
                values: new object[] { "2db7c719-30ab-45e9-9899-286db3500921", new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(4805), "AQAAAAIAAYagAAAAEClaPu/Uv3V4DO4shUhMj7nFQfI8sFHMZgzjX3YaDYoELc3adYt3x5MPWmzttr37hg==", "organization", new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(4806) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "Role", "UpdatedAt" },
                values: new object[] { "a567046a-f084-441c-aa42-de0a41bd5f76", new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(4810), "AQAAAAIAAYagAAAAEClaPu/Uv3V4DO4shUhMj7nFQfI8sFHMZgzjX3YaDYoELc3adYt3x5MPWmzttr37hg==", "moderator", new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(4810) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "Role", "UpdatedAt" },
                values: new object[] { "0f34371b-4e9c-4cd4-a74b-14dac9846846", new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(4820), "AQAAAAIAAYagAAAAEClaPu/Uv3V4DO4shUhMj7nFQfI8sFHMZgzjX3YaDYoELc3adYt3x5MPWmzttr37hg==", "admin", new DateTime(2023, 8, 2, 13, 21, 8, 520, DateTimeKind.Local).AddTicks(4821) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Organizations");

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6440), new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6441) });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6448), new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6448) });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6450), new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6451) });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6452), new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6453) });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6454), new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6455) });

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
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "Role", "UpdatedAt" },
                values: new object[] { "a0aa8c37-b350-4d87-a5d2-c6378ccd0054", new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6033), "AQAAAAIAAYagAAAAEChYzb3mkPlVn5Tyx/rI21tD1qjPZX0TfsXi2sU1NQgKL/Iv5br8viEgc2zOGmO2Ww==", "Admin", new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6085) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "Role", "UpdatedAt" },
                values: new object[] { "0b54ac36-ca26-4071-b07a-c224664f0db9", new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6124), "AQAAAAIAAYagAAAAEChYzb3mkPlVn5Tyx/rI21tD1qjPZX0TfsXi2sU1NQgKL/Iv5br8viEgc2zOGmO2Ww==", "Student", new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6126) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "Role", "UpdatedAt" },
                values: new object[] { "c9a85a1a-2677-445a-90ba-c6851141c38e", new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6129), "AQAAAAIAAYagAAAAEChYzb3mkPlVn5Tyx/rI21tD1qjPZX0TfsXi2sU1NQgKL/Iv5br8viEgc2zOGmO2Ww==", "Organization", new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6130) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "Role", "UpdatedAt" },
                values: new object[] { "4478b4d7-e14f-4d11-955b-6a0c0599fe69", new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6134), "AQAAAAIAAYagAAAAEChYzb3mkPlVn5Tyx/rI21tD1qjPZX0TfsXi2sU1NQgKL/Iv5br8viEgc2zOGmO2Ww==", "Moderator", new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6135) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "Role", "UpdatedAt" },
                values: new object[] { "0d62ea1c-2277-452a-a969-e6ffc95cebd1", new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6138), "AQAAAAIAAYagAAAAEChYzb3mkPlVn5Tyx/rI21tD1qjPZX0TfsXi2sU1NQgKL/Iv5br8viEgc2zOGmO2Ww==", "Admin", new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6139) });
        }
    }
}
