using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutTheGC.Migrations
{
    public partial class ManyToManyForUserVotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("1a647d9a-c035-465e-8cf6-a2447a0fc7b2"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("2664abbc-e395-4789-ad2f-b9c0487080c7"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("28a61d61-3359-4a02-8863-d126c6a47b32"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("373a2ec7-396c-4c53-8a36-bae0a3647ddc"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("44ee9880-ad94-4477-83b0-8e41bfca84b6"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("455398d4-5b59-4f70-bb14-3c7367f041f1"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("5146bbe7-fa9c-4427-9149-12bb56df62d0"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("5753367a-7d04-4956-a536-69c521c499ca"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7bb6c46b-e9cd-47cc-953e-f05baf0d131a"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("84967592-044c-4089-a772-d60bdd78c463"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("be73b9bd-1b63-4403-a58e-678916f443b6"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("d42998ab-ca04-4875-8dd9-605b7ee6c2a0"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("de0a2a88-f336-43a5-b521-90ff60b04e92"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("e767a3bb-601d-498f-9ebb-cee945c54a9d"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("f483e145-9f5e-48b2-bd4d-10100df744fb"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("1aaf6198-6799-40f2-989d-0bf75ce74560"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("85125a62-df84-4faa-b404-fa52f9173662"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("8de682ca-c542-4bb5-98a7-dba0769e1d18"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("c7e9b254-f66d-4df4-ad9e-aabed4f85c79"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("90e1fd23-416f-4faa-9e11-62c8d00f0414"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("a9fa3207-68b8-4790-a1e4-a51eef983ba7"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("c605809b-4612-49f8-8b00-2cd7d095cb08"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("f3c6383e-e19d-4a30-aca8-eec6be3c81e2"));

            migrationBuilder.AddColumn<bool>(
                name: "isArchived",
                table: "Activities",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Activities",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ActivityId", "Content", "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("099d1cf9-d264-45cd-8d55-297664b84fa0"), new Guid("9b0ecf93-c42d-4c45-9ecb-85b8fe7e2d7c"), "Tasting tropical drinks will be a refreshing break. Can’t wait!", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5") },
                    { new Guid("0e4fbe69-2384-49a7-b8b1-abb3825e9b5e"), new Guid("4a7cb92b-2b6a-4316-8bb0-402497c47bdb"), "The underwater adventure is a must-try! The reefs look amazing.", new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("32f959b2-1323-4645-b47c-1725e13382e8"), new Guid("b8d3c7d2-8a8e-45d0-8b1a-cbc32bc3b53d"), "Alpine dining sounds so cozy. Can’t wait to try the Swiss specialties.", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("46c991b5-547d-4e7f-b6c4-e75e7be52ba3"), new Guid("92d62312-4397-4c9d-9172-2c8a53e8c6a4"), "Snorkeling at Coral Reef Bay will be a highlight of the trip for sure!", new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5") },
                    { new Guid("5a033e6e-ff50-4802-a837-7f104eced4f7"), new Guid("ff8f6c32-8e22-4a3c-8d8a-2f1e5b557477"), "The national park tour will be such a scenic experience. Looking forward to it!", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85") },
                    { new Guid("7e86155e-bf2c-4d31-8cbb-f35b744f64be"), new Guid("8d69e4e8-62b1-465d-bfc7-1a94c3d07a71"), "Island hopping will be such a fun way to explore the Maldives!", new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("93767c36-8f0f-464d-8216-a7584e1fce3f"), new Guid("175a8012-6200-4180-915b-f3e4d604923d"), "The beach day sounds so relaxing! Can’t wait to enjoy the sun and sea breeze.", new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("a19a1550-2e2a-4a5a-9702-cb61ff8f126a"), new Guid("bfa47491-e758-4330-bc10-2e60d9a3479d"), "A sunset drive along the coast sounds like the perfect way to relax.", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85") },
                    { new Guid("b02e1feb-06d2-40e5-b008-951c8666c93a"), new Guid("d7f9d8ed-4f65-4859-a837-d4a512bf7a6b"), "Looking forward to the classic diner experience on Route 66!", new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85") },
                    { new Guid("b7ce7445-fe38-4a39-b5bd-3b6ebb61823d"), new Guid("f2d85352-0c93-4f58-9739-4e0d63ca90d1"), "I’ve always wanted to visit this museum. The history here is so rich!", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("bdaed5a2-8844-43b3-8a32-51104ce4ec0f"), new Guid("64f3cda1-70cf-4b52-99b2-d9c60a5b5898"), "Beach day with blue waters and sun? Yes, please!", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5") },
                    { new Guid("becd931a-832b-47da-bcac-65aab09fa68f"), new Guid("343f58ed-97d1-4324-b231-71e7a3d577e5"), "The cultural dance show will be such a treat. I love traditional performances.", new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("cd0096d6-259e-4d7d-99df-482029425099"), new Guid("a3c9c52c-038f-4b3e-a9bc-26496fcbfa0b"), "I’m excited for the hiking trip. The views are going to be breathtaking!", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("d0b4daba-734a-4a6b-b441-ef37399acdc1"), new Guid("da699d06-56b7-4fbd-89b1-b24fdf9b7ab2"), "Exploring the old town will be such a charming experience. Can’t wait!", new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("f3ca6a14-964a-4815-834d-57961e8c869c"), new Guid("d7e309b1-dde9-48f5-99b5-7d3c6f153032"), "Skiing in the Alps is a dream come true! Can’t wait for this adventure.", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") }
                });

            migrationBuilder.InsertData(
                table: "UserTrips",
                columns: new[] { "Id", "CreatedAt", "TripId", "UserId" },
                values: new object[,]
                {
                    { new Guid("546436a3-f40e-4544-9e7c-5894cb9774a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f927882-1196-4d72-917d-972c6de3f1b4"), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("73647772-2113-49a7-a1b9-3c0a3baf9273"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("172d5607-5dbd-4361-bf3f-fa76bfb84f70"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("be5c9d29-046c-419e-ada6-d85f286a627c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f927882-1196-4d72-917d-972c6de3f1b4"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("e6fc24c2-e23c-41bd-af19-b63d32afb338"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("de59cf42-eb57-4045-b7bc-a578db398ad2"), new Guid("0eaed767-eecd-4d19-a853-9da895e78057") }
                });

            migrationBuilder.InsertData(
                table: "UsersVotes",
                columns: new[] { "Id", "ActivityId", "UserId" },
                values: new object[,]
                {
                    { new Guid("6bb33ad7-bd61-44dd-a499-1eabe1d47ff0"), new Guid("4a7cb92b-2b6a-4316-8bb0-402497c47bdb"), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("897260c5-cff8-411d-aac3-f728fa751d97"), new Guid("64f3cda1-70cf-4b52-99b2-d9c60a5b5898"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("af6e834a-e185-410e-9c93-50c6ceae8c38"), new Guid("175a8012-6200-4180-915b-f3e4d604923d"), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("d20434fa-eb88-49a7-a856-f110e83d4bae"), new Guid("8d69e4e8-62b1-465d-bfc7-1a94c3d07a71"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersVotes_ActivityId",
                table: "UsersVotes",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersVotes_UserId",
                table: "UsersVotes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersVotes_Activities_ActivityId",
                table: "UsersVotes",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersVotes_Users_UserId",
                table: "UsersVotes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersVotes_Activities_ActivityId",
                table: "UsersVotes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersVotes_Users_UserId",
                table: "UsersVotes");

            migrationBuilder.DropIndex(
                name: "IX_UsersVotes_ActivityId",
                table: "UsersVotes");

            migrationBuilder.DropIndex(
                name: "IX_UsersVotes_UserId",
                table: "UsersVotes");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("099d1cf9-d264-45cd-8d55-297664b84fa0"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("0e4fbe69-2384-49a7-b8b1-abb3825e9b5e"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("32f959b2-1323-4645-b47c-1725e13382e8"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("46c991b5-547d-4e7f-b6c4-e75e7be52ba3"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("5a033e6e-ff50-4802-a837-7f104eced4f7"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7e86155e-bf2c-4d31-8cbb-f35b744f64be"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("93767c36-8f0f-464d-8216-a7584e1fce3f"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("a19a1550-2e2a-4a5a-9702-cb61ff8f126a"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("b02e1feb-06d2-40e5-b008-951c8666c93a"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("b7ce7445-fe38-4a39-b5bd-3b6ebb61823d"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("bdaed5a2-8844-43b3-8a32-51104ce4ec0f"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("becd931a-832b-47da-bcac-65aab09fa68f"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("cd0096d6-259e-4d7d-99df-482029425099"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("d0b4daba-734a-4a6b-b441-ef37399acdc1"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("f3ca6a14-964a-4815-834d-57961e8c869c"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("546436a3-f40e-4544-9e7c-5894cb9774a0"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("73647772-2113-49a7-a1b9-3c0a3baf9273"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("be5c9d29-046c-419e-ada6-d85f286a627c"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("e6fc24c2-e23c-41bd-af19-b63d32afb338"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("6bb33ad7-bd61-44dd-a499-1eabe1d47ff0"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("897260c5-cff8-411d-aac3-f728fa751d97"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("af6e834a-e185-410e-9c93-50c6ceae8c38"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("d20434fa-eb88-49a7-a856-f110e83d4bae"));

            migrationBuilder.DropColumn(
                name: "isArchived",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Activities");

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ActivityId", "Content", "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("1a647d9a-c035-465e-8cf6-a2447a0fc7b2"), new Guid("f2d85352-0c93-4f58-9739-4e0d63ca90d1"), "I’ve always wanted to visit this museum. The history here is so rich!", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("2664abbc-e395-4789-ad2f-b9c0487080c7"), new Guid("d7e309b1-dde9-48f5-99b5-7d3c6f153032"), "Skiing in the Alps is a dream come true! Can’t wait for this adventure.", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("28a61d61-3359-4a02-8863-d126c6a47b32"), new Guid("64f3cda1-70cf-4b52-99b2-d9c60a5b5898"), "Beach day with blue waters and sun? Yes, please!", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5") },
                    { new Guid("373a2ec7-396c-4c53-8a36-bae0a3647ddc"), new Guid("175a8012-6200-4180-915b-f3e4d604923d"), "The beach day sounds so relaxing! Can’t wait to enjoy the sun and sea breeze.", new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("44ee9880-ad94-4477-83b0-8e41bfca84b6"), new Guid("b8d3c7d2-8a8e-45d0-8b1a-cbc32bc3b53d"), "Alpine dining sounds so cozy. Can’t wait to try the Swiss specialties.", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("455398d4-5b59-4f70-bb14-3c7367f041f1"), new Guid("bfa47491-e758-4330-bc10-2e60d9a3479d"), "A sunset drive along the coast sounds like the perfect way to relax.", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85") },
                    { new Guid("5146bbe7-fa9c-4427-9149-12bb56df62d0"), new Guid("9b0ecf93-c42d-4c45-9ecb-85b8fe7e2d7c"), "Tasting tropical drinks will be a refreshing break. Can’t wait!", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5") },
                    { new Guid("5753367a-7d04-4956-a536-69c521c499ca"), new Guid("8d69e4e8-62b1-465d-bfc7-1a94c3d07a71"), "Island hopping will be such a fun way to explore the Maldives!", new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("7bb6c46b-e9cd-47cc-953e-f05baf0d131a"), new Guid("343f58ed-97d1-4324-b231-71e7a3d577e5"), "The cultural dance show will be such a treat. I love traditional performances.", new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("84967592-044c-4089-a772-d60bdd78c463"), new Guid("ff8f6c32-8e22-4a3c-8d8a-2f1e5b557477"), "The national park tour will be such a scenic experience. Looking forward to it!", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85") },
                    { new Guid("be73b9bd-1b63-4403-a58e-678916f443b6"), new Guid("92d62312-4397-4c9d-9172-2c8a53e8c6a4"), "Snorkeling at Coral Reef Bay will be a highlight of the trip for sure!", new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5") },
                    { new Guid("d42998ab-ca04-4875-8dd9-605b7ee6c2a0"), new Guid("d7f9d8ed-4f65-4859-a837-d4a512bf7a6b"), "Looking forward to the classic diner experience on Route 66!", new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85") },
                    { new Guid("de0a2a88-f336-43a5-b521-90ff60b04e92"), new Guid("da699d06-56b7-4fbd-89b1-b24fdf9b7ab2"), "Exploring the old town will be such a charming experience. Can’t wait!", new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("e767a3bb-601d-498f-9ebb-cee945c54a9d"), new Guid("4a7cb92b-2b6a-4316-8bb0-402497c47bdb"), "The underwater adventure is a must-try! The reefs look amazing.", new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("f483e145-9f5e-48b2-bd4d-10100df744fb"), new Guid("a3c9c52c-038f-4b3e-a9bc-26496fcbfa0b"), "I’m excited for the hiking trip. The views are going to be breathtaking!", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") }
                });

            migrationBuilder.InsertData(
                table: "UserTrips",
                columns: new[] { "Id", "CreatedAt", "TripId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1aaf6198-6799-40f2-989d-0bf75ce74560"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f927882-1196-4d72-917d-972c6de3f1b4"), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("85125a62-df84-4faa-b404-fa52f9173662"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("de59cf42-eb57-4045-b7bc-a578db398ad2"), new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("8de682ca-c542-4bb5-98a7-dba0769e1d18"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("172d5607-5dbd-4361-bf3f-fa76bfb84f70"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("c7e9b254-f66d-4df4-ad9e-aabed4f85c79"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f927882-1196-4d72-917d-972c6de3f1b4"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") }
                });

            migrationBuilder.InsertData(
                table: "UsersVotes",
                columns: new[] { "Id", "ActivityId", "UserId" },
                values: new object[,]
                {
                    { new Guid("90e1fd23-416f-4faa-9e11-62c8d00f0414"), new Guid("8d69e4e8-62b1-465d-bfc7-1a94c3d07a71"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("a9fa3207-68b8-4790-a1e4-a51eef983ba7"), new Guid("4a7cb92b-2b6a-4316-8bb0-402497c47bdb"), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("c605809b-4612-49f8-8b00-2cd7d095cb08"), new Guid("64f3cda1-70cf-4b52-99b2-d9c60a5b5898"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("f3c6383e-e19d-4a30-aca8-eec6be3c81e2"), new Guid("175a8012-6200-4180-915b-f3e4d604923d"), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") }
                });
        }
    }
}
