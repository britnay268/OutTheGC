using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutTheGC.Migrations
{
    public partial class AddTripInvitationSetupandRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("0626535e-bfef-4c56-8649-c2c8955a0548"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("0a68d441-b6d8-4aee-94d9-588a78503339"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("1415f391-5706-4d17-9dc1-9a0ca9dd959f"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("61e77449-68bc-4ee8-a115-84fb69698844"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("6cbb56c1-21ef-4645-805f-5c2f77b2e41a"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("6ccb7170-468a-470e-86be-aece11ef5060"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("6e1d49b6-14bb-4246-936f-b1ad1adef6a1"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("76ffdd31-49d2-4b81-baac-d9e01bcad706"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("97a73515-b2e7-4de5-b417-988c52263146"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("ab715466-7ed3-4995-a158-9e50db011d4a"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("b7bf8bf9-68cc-41cf-9876-bacb8fa8c09b"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c8d9f296-599e-4e12-be08-5bba378bc65b"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("dc2881c8-4ccf-4b71-a51b-7898647a1aea"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("ec039a91-3bd5-4c80-9e21-7bdb3e3585f0"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("f22ca3bc-fec7-4219-a4c4-3b21fa17ef6c"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("8b1f4483-522f-4915-8097-ab1e376018e9"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("e476c277-d922-452d-882f-94bb39629c80"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("e889f9cd-d869-41cc-b9a5-382fb9320b59"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("fe1a48a8-5fd5-409f-a185-141de5fe49da"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("9db26828-e839-460a-921f-3a5d790d34fd"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("a104fc89-bf9e-4689-965c-74ce54a46f83"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("a2cdbc07-ce86-4a5b-9d2a-954b369fa963"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("b99ade08-7fe6-45cb-b584-7593cddcd7b2"));

            migrationBuilder.CreateTable(
                name: "TripInvitations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    TripId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipientId = table.Column<Guid>(type: "uuid", nullable: true),
                    RecipientEmail = table.Column<string>(type: "text", nullable: false),
                    SentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripInvitations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripInvitations_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripInvitations_Users_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ActivityId", "Content", "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("07992edc-634d-4bd4-8e86-84ccb41b86b7"), new Guid("d7e309b1-dde9-48f5-99b5-7d3c6f153032"), "Skiing in the Alps is a dream come true! Can’t wait for this adventure.", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("10785720-23e1-4986-89df-4cd216daa1c0"), new Guid("da699d06-56b7-4fbd-89b1-b24fdf9b7ab2"), "Exploring the old town will be such a charming experience. Can’t wait!", new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("13b02483-51e7-4c00-92a3-82cdd60cabfe"), new Guid("343f58ed-97d1-4324-b231-71e7a3d577e5"), "The cultural dance show will be such a treat. I love traditional performances.", new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("48f01399-d687-4b03-9ce7-ef948390815e"), new Guid("8d69e4e8-62b1-465d-bfc7-1a94c3d07a71"), "Island hopping will be such a fun way to explore the Maldives!", new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("5e632e58-cbd4-40a3-9257-8494fbbf1df3"), new Guid("f2d85352-0c93-4f58-9739-4e0d63ca90d1"), "I’ve always wanted to visit this museum. The history here is so rich!", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("76b5b3d5-4d3c-4d63-b878-1f670e8fe6c0"), new Guid("ff8f6c32-8e22-4a3c-8d8a-2f1e5b557477"), "The national park tour will be such a scenic experience. Looking forward to it!", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85") },
                    { new Guid("7c3ec1c2-118a-4a18-908d-01a2b0627899"), new Guid("9b0ecf93-c42d-4c45-9ecb-85b8fe7e2d7c"), "Tasting tropical drinks will be a refreshing break. Can’t wait!", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5") },
                    { new Guid("7e5ee41b-e7b0-4b66-bfd4-4e36ab29a0d1"), new Guid("b8d3c7d2-8a8e-45d0-8b1a-cbc32bc3b53d"), "Alpine dining sounds so cozy. Can’t wait to try the Swiss specialties.", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("9740337f-0f4f-45d1-a0a2-0bf5d239b9f8"), new Guid("bfa47491-e758-4330-bc10-2e60d9a3479d"), "A sunset drive along the coast sounds like the perfect way to relax.", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85") },
                    { new Guid("9a720164-0ab2-4776-bff4-b7f4b04b051e"), new Guid("64f3cda1-70cf-4b52-99b2-d9c60a5b5898"), "Beach day with blue waters and sun? Yes, please!", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5") },
                    { new Guid("b20397e7-c492-4107-8d45-01b922fdb9f0"), new Guid("a3c9c52c-038f-4b3e-a9bc-26496fcbfa0b"), "I’m excited for the hiking trip. The views are going to be breathtaking!", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("c6ab0a26-4d82-4def-964d-5d8f40cc8dac"), new Guid("92d62312-4397-4c9d-9172-2c8a53e8c6a4"), "Snorkeling at Coral Reef Bay will be a highlight of the trip for sure!", new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5") },
                    { new Guid("c6c19abd-417f-41ca-b804-38a7b20e5ce3"), new Guid("175a8012-6200-4180-915b-f3e4d604923d"), "The beach day sounds so relaxing! Can’t wait to enjoy the sun and sea breeze.", new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("d864d2d5-2380-431f-b81b-22c7117c21a5"), new Guid("d7f9d8ed-4f65-4859-a837-d4a512bf7a6b"), "Looking forward to the classic diner experience on Route 66!", new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85") },
                    { new Guid("f9548010-c4f5-48b8-9964-f046ec3daa1d"), new Guid("4a7cb92b-2b6a-4316-8bb0-402497c47bdb"), "The underwater adventure is a must-try! The reefs look amazing.", new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0eaed767-eecd-4d19-a853-9da895e78057") }
                });

            migrationBuilder.InsertData(
                table: "UserTrips",
                columns: new[] { "Id", "CreatedAt", "TripId", "UserId" },
                values: new object[,]
                {
                    { new Guid("01f9c8e2-c69e-4d7e-b94f-23ab360ee58b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f927882-1196-4d72-917d-972c6de3f1b4"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("12575639-c74b-4cfb-b608-38285c00f6a9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("172d5607-5dbd-4361-bf3f-fa76bfb84f70"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("9ae11b67-e0de-4aed-ab66-a16b806de012"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("de59cf42-eb57-4045-b7bc-a578db398ad2"), new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("a619623c-a3a4-468d-b883-2f9576629680"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f927882-1196-4d72-917d-972c6de3f1b4"), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") }
                });

            migrationBuilder.InsertData(
                table: "UsersVotes",
                columns: new[] { "Id", "ActivityId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3f810c2a-0fc1-4571-982a-53562af2c71d"), new Guid("4a7cb92b-2b6a-4316-8bb0-402497c47bdb"), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("5883a3b0-75ee-4997-942d-f758489db5a8"), new Guid("175a8012-6200-4180-915b-f3e4d604923d"), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("b542e86a-607a-426a-84db-bb603c48163e"), new Guid("8d69e4e8-62b1-465d-bfc7-1a94c3d07a71"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("c3dd5bec-5291-4d00-b98f-0000bda8d11a"), new Guid("64f3cda1-70cf-4b52-99b2-d9c60a5b5898"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TripInvitations_RecipientId",
                table: "TripInvitations",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_TripInvitations_TripId",
                table: "TripInvitations",
                column: "TripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripInvitations");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("07992edc-634d-4bd4-8e86-84ccb41b86b7"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("10785720-23e1-4986-89df-4cd216daa1c0"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("13b02483-51e7-4c00-92a3-82cdd60cabfe"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("48f01399-d687-4b03-9ce7-ef948390815e"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("5e632e58-cbd4-40a3-9257-8494fbbf1df3"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("76b5b3d5-4d3c-4d63-b878-1f670e8fe6c0"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7c3ec1c2-118a-4a18-908d-01a2b0627899"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7e5ee41b-e7b0-4b66-bfd4-4e36ab29a0d1"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("9740337f-0f4f-45d1-a0a2-0bf5d239b9f8"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("9a720164-0ab2-4776-bff4-b7f4b04b051e"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("b20397e7-c492-4107-8d45-01b922fdb9f0"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c6ab0a26-4d82-4def-964d-5d8f40cc8dac"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c6c19abd-417f-41ca-b804-38a7b20e5ce3"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("d864d2d5-2380-431f-b81b-22c7117c21a5"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("f9548010-c4f5-48b8-9964-f046ec3daa1d"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("01f9c8e2-c69e-4d7e-b94f-23ab360ee58b"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("12575639-c74b-4cfb-b608-38285c00f6a9"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("9ae11b67-e0de-4aed-ab66-a16b806de012"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("a619623c-a3a4-468d-b883-2f9576629680"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("3f810c2a-0fc1-4571-982a-53562af2c71d"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("5883a3b0-75ee-4997-942d-f758489db5a8"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("b542e86a-607a-426a-84db-bb603c48163e"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("c3dd5bec-5291-4d00-b98f-0000bda8d11a"));

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ActivityId", "Content", "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("0626535e-bfef-4c56-8649-c2c8955a0548"), new Guid("d7e309b1-dde9-48f5-99b5-7d3c6f153032"), "Skiing in the Alps is a dream come true! Can’t wait for this adventure.", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("0a68d441-b6d8-4aee-94d9-588a78503339"), new Guid("f2d85352-0c93-4f58-9739-4e0d63ca90d1"), "I’ve always wanted to visit this museum. The history here is so rich!", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("1415f391-5706-4d17-9dc1-9a0ca9dd959f"), new Guid("64f3cda1-70cf-4b52-99b2-d9c60a5b5898"), "Beach day with blue waters and sun? Yes, please!", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5") },
                    { new Guid("61e77449-68bc-4ee8-a115-84fb69698844"), new Guid("8d69e4e8-62b1-465d-bfc7-1a94c3d07a71"), "Island hopping will be such a fun way to explore the Maldives!", new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("6cbb56c1-21ef-4645-805f-5c2f77b2e41a"), new Guid("da699d06-56b7-4fbd-89b1-b24fdf9b7ab2"), "Exploring the old town will be such a charming experience. Can’t wait!", new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("6ccb7170-468a-470e-86be-aece11ef5060"), new Guid("343f58ed-97d1-4324-b231-71e7a3d577e5"), "The cultural dance show will be such a treat. I love traditional performances.", new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("6e1d49b6-14bb-4246-936f-b1ad1adef6a1"), new Guid("4a7cb92b-2b6a-4316-8bb0-402497c47bdb"), "The underwater adventure is a must-try! The reefs look amazing.", new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("76ffdd31-49d2-4b81-baac-d9e01bcad706"), new Guid("92d62312-4397-4c9d-9172-2c8a53e8c6a4"), "Snorkeling at Coral Reef Bay will be a highlight of the trip for sure!", new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5") },
                    { new Guid("97a73515-b2e7-4de5-b417-988c52263146"), new Guid("bfa47491-e758-4330-bc10-2e60d9a3479d"), "A sunset drive along the coast sounds like the perfect way to relax.", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85") },
                    { new Guid("ab715466-7ed3-4995-a158-9e50db011d4a"), new Guid("b8d3c7d2-8a8e-45d0-8b1a-cbc32bc3b53d"), "Alpine dining sounds so cozy. Can’t wait to try the Swiss specialties.", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("b7bf8bf9-68cc-41cf-9876-bacb8fa8c09b"), new Guid("a3c9c52c-038f-4b3e-a9bc-26496fcbfa0b"), "I’m excited for the hiking trip. The views are going to be breathtaking!", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("c8d9f296-599e-4e12-be08-5bba378bc65b"), new Guid("175a8012-6200-4180-915b-f3e4d604923d"), "The beach day sounds so relaxing! Can’t wait to enjoy the sun and sea breeze.", new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("dc2881c8-4ccf-4b71-a51b-7898647a1aea"), new Guid("9b0ecf93-c42d-4c45-9ecb-85b8fe7e2d7c"), "Tasting tropical drinks will be a refreshing break. Can’t wait!", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5") },
                    { new Guid("ec039a91-3bd5-4c80-9e21-7bdb3e3585f0"), new Guid("d7f9d8ed-4f65-4859-a837-d4a512bf7a6b"), "Looking forward to the classic diner experience on Route 66!", new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85") },
                    { new Guid("f22ca3bc-fec7-4219-a4c4-3b21fa17ef6c"), new Guid("ff8f6c32-8e22-4a3c-8d8a-2f1e5b557477"), "The national park tour will be such a scenic experience. Looking forward to it!", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85") }
                });

            migrationBuilder.InsertData(
                table: "UserTrips",
                columns: new[] { "Id", "CreatedAt", "TripId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8b1f4483-522f-4915-8097-ab1e376018e9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("172d5607-5dbd-4361-bf3f-fa76bfb84f70"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("e476c277-d922-452d-882f-94bb39629c80"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("de59cf42-eb57-4045-b7bc-a578db398ad2"), new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("e889f9cd-d869-41cc-b9a5-382fb9320b59"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f927882-1196-4d72-917d-972c6de3f1b4"), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("fe1a48a8-5fd5-409f-a185-141de5fe49da"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f927882-1196-4d72-917d-972c6de3f1b4"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") }
                });

            migrationBuilder.InsertData(
                table: "UsersVotes",
                columns: new[] { "Id", "ActivityId", "UserId" },
                values: new object[,]
                {
                    { new Guid("9db26828-e839-460a-921f-3a5d790d34fd"), new Guid("175a8012-6200-4180-915b-f3e4d604923d"), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("a104fc89-bf9e-4689-965c-74ce54a46f83"), new Guid("8d69e4e8-62b1-465d-bfc7-1a94c3d07a71"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("a2cdbc07-ce86-4a5b-9d2a-954b369fa963"), new Guid("4a7cb92b-2b6a-4316-8bb0-402497c47bdb"), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("b99ade08-7fe6-45cb-b584-7593cddcd7b2"), new Guid("64f3cda1-70cf-4b52-99b2-d9c60a5b5898"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") }
                });
        }
    }
}
