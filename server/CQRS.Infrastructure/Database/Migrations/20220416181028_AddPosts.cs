using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CQRS.Infrastructure.Migrations
{
    public partial class AddPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("1a900bcd-8875-4e9d-9419-b173f7db6d2c"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("5274a3ee-2258-4ce5-8007-e8ef9231603f"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("63c2e00b-56d6-4c73-a37d-065913ad0424"));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "Date" },
                values: new object[] { new Guid("3d43de6a-e1ef-4fc6-82f7-73d21541d866"), new Guid("f0a963b3-bdb6-448a-9a75-f73fb74b7902"), "Some conent", new DateTime(2022, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "Date" },
                values: new object[] { new Guid("743d243e-96ce-4424-b785-8b227461060e"), new Guid("02612cc2-e2c0-4282-800a-cabdfed2aa76"), "Some conent", new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "Date" },
                values: new object[] { new Guid("c281a47d-4c74-4168-9608-36fd627c1f56"), new Guid("c981af1f-26aa-4469-9871-6d9eef95955f"), "Some conent", new DateTime(2022, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("3d43de6a-e1ef-4fc6-82f7-73d21541d866"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("743d243e-96ce-4424-b785-8b227461060e"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("c281a47d-4c74-4168-9608-36fd627c1f56"));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "Date" },
                values: new object[] { new Guid("1a900bcd-8875-4e9d-9419-b173f7db6d2c"), new Guid("0327b7ed-849e-4883-bf41-e123cd6bacb9"), "Some conent", new DateTime(2022, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "Date" },
                values: new object[] { new Guid("5274a3ee-2258-4ce5-8007-e8ef9231603f"), new Guid("b5b76bec-851c-4e85-b6c3-a2d7baafb8d5"), "Some conent", new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "Date" },
                values: new object[] { new Guid("63c2e00b-56d6-4c73-a37d-065913ad0424"), new Guid("48562f14-e257-4edf-a852-21bc9a289187"), "Some conent", new DateTime(2022, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
