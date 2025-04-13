using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PropertyGalla.Migrations
{
    /// <inheritdoc />
    public partial class SeedDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactMessages_Users_ReceiverId",
                table: "ContactMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactMessages_Users_SenderId",
                table: "ContactMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Users_OwnerId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Users_ReviewerId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Users_OwnerId",
                table: "Properties");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "Name", "Password", "Phone", "Role" },
                values: new object[,]
                {
                    { "USE0001", new DateTime(2025, 4, 13, 13, 18, 35, 232, DateTimeKind.Utc).AddTicks(5358), "alice@admin.com", "Alice Admin", "JAvlGPq9JyTdtvBO6x2llnRI1+gxwIyPqCKAn3THIKk=", null, "admin" },
                    { "USE0002", new DateTime(2025, 4, 13, 13, 18, 35, 232, DateTimeKind.Utc).AddTicks(5942), "bob@buyer.com", "Bob Buyer", "5Ue9EyKCUN+0x98dHrt4z9nyraVuuwxCXTWCndOsSug=", null, "user" },
                    { "USE0003", new DateTime(2025, 4, 13, 13, 18, 35, 232, DateTimeKind.Utc).AddTicks(5965), "carol@customer.com", "Carol Customer", "sEHArrNbsPpKpmjKWpILWQGW/a+aAOuFLJt/TRI8xtY=", null, "user" },
                    { "USE0004", new DateTime(2025, 4, 13, 13, 18, 35, 232, DateTimeKind.Utc).AddTicks(5976), "dan@dev.com", "Dan Developer", "hydK8Bh2NBRVsy2AWUbycocbtC7/pmBNzPKLsCevqCs=", null, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "FeedbackId", "Comment", "OwnerId", "Rating", "ReviewerId", "SubmittedAt" },
                values: new object[,]
                {
                    { "FED0001", "Great communication!", "USE0001", 4, "USE0002", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(5222) },
                    { "FED0002", "Loved the property!", "USE0001", 5, "USE0003", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(5344) },
                    { "FED0003", "Nice but overpriced.", "USE0004", 3, "USE0002", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(5345) },
                    { "FED0004", "Helpful owner.", "USE0004", 4, "USE0003", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(5346) }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "PropertyId", "CreatedAt", "Description", "Location", "OwnerId", "Price", "Status", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { "PRO0001", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(1293), "Stylish loft in the city center", "Kuala Lumpur", "USE0001", 3500.00m, "available", "Modern Loft", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(1408) },
                    { "PRO0002", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(1514), "Beautiful view of the sea", "Penang", "USE0001", 7500.00m, "available", "Beach House", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(1515) },
                    { "PRO0003", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(1517), "Cozy studio for singles", "Cyberjaya", "USE0004", 1800.00m, "rented", "Studio Flat", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(1517) },
                    { "PRO0004", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(1519), "5-bedroom premium villa", "Shah Alam", "USE0004", 12000.00m, "available", "Luxury Villa", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(1519) }
                });

            migrationBuilder.InsertData(
                table: "ContactMessages",
                columns: new[] { "MessageId", "Message", "PropertyId", "ReceiverId", "SenderId", "SentAt" },
                values: new object[,]
                {
                    { "MSG0001", "Can you send more photos?", "PRO0001", "USE0001", "USE0002", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(4181) },
                    { "MSG0002", "Is the villa available next month?", "PRO0004", "USE0004", "USE0003", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(4293) },
                    { "MSG0003", "I want to negotiate the price.", "PRO0003", "USE0004", "USE0002", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(4294) },
                    { "MSG0004", "Is parking included?", "PRO0002", "USE0001", "USE0003", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(4295) }
                });

            migrationBuilder.InsertData(
                table: "PropertyImages",
                columns: new[] { "Id", "ImageUrl", "PropertyId" },
                values: new object[,]
                {
                    { 1, "loft1.jpg", "PRO0001" },
                    { 2, "beach1.jpg", "PRO0002" },
                    { 3, "studio1.jpg", "PRO0003" },
                    { 4, "villa1.jpg", "PRO0004" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "CreatedAt", "PropertyId", "Reason", "ReporterId", "Status" },
                values: new object[,]
                {
                    { "REP0001", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(6375), "PRO0001", "Fake images", "USE0003", "pending" },
                    { "REP0002", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(6486), "PRO0002", "Wrong location info", "USE0002", "reviewed" },
                    { "REP0003", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(6487), "PRO0004", "Price too high", "USE0002", "dismissed" },
                    { "REP0004", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(6488), "PRO0003", "Spam listing", "USE0003", "pending" }
                });

            migrationBuilder.InsertData(
                table: "SavedProperties",
                columns: new[] { "Id", "PropertyId", "UserId" },
                values: new object[,]
                {
                    { 1, "PRO0001", "USE0002" },
                    { 2, "PRO0002", "USE0002" },
                    { 3, "PRO0004", "USE0003" },
                    { 4, "PRO0001", "USE0003" }
                });

            migrationBuilder.InsertData(
                table: "ViewRequests",
                columns: new[] { "ViewRequestId", "CreatedAt", "PropertyId", "Status", "Text", "UserId" },
                values: new object[,]
                {
                    { "VRQ0001", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(3176), "PRO0001", "pending", "I'd like to schedule a visit.", "USE0002" },
                    { "VRQ0002", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(3302), "PRO0002", "pending", "Is this property still available?", "USE0003" },
                    { "VRQ0003", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(3304), "PRO0003", "handled", "Interested in long-term rental.", "USE0002" },
                    { "VRQ0004", new DateTime(2025, 4, 13, 13, 18, 35, 233, DateTimeKind.Utc).AddTicks(3305), "PRO0001", "pending", "Can I see it this weekend?", "USE0003" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ContactMessages_Users_ReceiverId",
                table: "ContactMessages",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactMessages_Users_SenderId",
                table: "ContactMessages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Users_OwnerId",
                table: "Feedbacks",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Users_ReviewerId",
                table: "Feedbacks",
                column: "ReviewerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Users_OwnerId",
                table: "Properties",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactMessages_Users_ReceiverId",
                table: "ContactMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactMessages_Users_SenderId",
                table: "ContactMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Users_OwnerId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Users_ReviewerId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Users_OwnerId",
                table: "Properties");

            migrationBuilder.DeleteData(
                table: "ContactMessages",
                keyColumn: "MessageId",
                keyValue: "MSG0001");

            migrationBuilder.DeleteData(
                table: "ContactMessages",
                keyColumn: "MessageId",
                keyValue: "MSG0002");

            migrationBuilder.DeleteData(
                table: "ContactMessages",
                keyColumn: "MessageId",
                keyValue: "MSG0003");

            migrationBuilder.DeleteData(
                table: "ContactMessages",
                keyColumn: "MessageId",
                keyValue: "MSG0004");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "FeedbackId",
                keyValue: "FED0001");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "FeedbackId",
                keyValue: "FED0002");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "FeedbackId",
                keyValue: "FED0003");

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "FeedbackId",
                keyValue: "FED0004");

            migrationBuilder.DeleteData(
                table: "PropertyImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PropertyImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PropertyImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PropertyImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: "REP0001");

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: "REP0002");

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: "REP0003");

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "ReportId",
                keyValue: "REP0004");

            migrationBuilder.DeleteData(
                table: "SavedProperties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SavedProperties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SavedProperties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SavedProperties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ViewRequests",
                keyColumn: "ViewRequestId",
                keyValue: "VRQ0001");

            migrationBuilder.DeleteData(
                table: "ViewRequests",
                keyColumn: "ViewRequestId",
                keyValue: "VRQ0002");

            migrationBuilder.DeleteData(
                table: "ViewRequests",
                keyColumn: "ViewRequestId",
                keyValue: "VRQ0003");

            migrationBuilder.DeleteData(
                table: "ViewRequests",
                keyColumn: "ViewRequestId",
                keyValue: "VRQ0004");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: "PRO0001");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: "PRO0002");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: "PRO0003");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "PropertyId",
                keyValue: "PRO0004");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "USE0002");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "USE0003");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "USE0001");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "USE0004");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactMessages_Users_ReceiverId",
                table: "ContactMessages",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactMessages_Users_SenderId",
                table: "ContactMessages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Users_OwnerId",
                table: "Feedbacks",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Users_ReviewerId",
                table: "Feedbacks",
                column: "ReviewerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Users_OwnerId",
                table: "Properties",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
