using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutTheGC.Migrations
{
    public partial class AddedStatusToTripInvitation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("150e712f-55c0-46c1-8697-121f3f014abf"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("3278e7d5-4ca9-46d2-87fc-2e7211c77836"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("3aeffaa2-c370-4213-8637-304104d3ca94"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("46bc90d6-e7af-4260-83ec-da7be9c458cc"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("569d3756-8e80-46a3-b4c0-337e1ead80f0"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("5db02ddb-fd00-4f64-8d54-e6aa56d49562"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("6864b8f0-6514-4c16-98d4-466d6f1ad7e6"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("814cdcca-4650-4038-aa01-f990bd50497c"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("94e99cf4-d332-410e-aa14-934b19ddbd4d"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("a24004d8-9dd0-4193-bdc3-c04ee866c151"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("b1bd26fb-d563-4fb0-8ac5-ca9ba39ebe5c"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c203268f-ebc9-4baf-abea-5e5aa0491433"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c20baa60-5e0c-465c-a31a-e50e97f8756f"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c8116aff-57c3-4f06-923b-3a9c4121e1f1"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("e5cc13e3-5f71-4608-b450-4f7b36d5675b"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("01cad319-df4b-4370-abfe-514293f38d39"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("0d7b8b12-f570-46e5-a71c-bc2775de05e4"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("90353124-48cf-4cba-86d5-db0b206f1475"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("b0efd82d-9e29-465d-bed8-5045320ecdcf"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("438b139c-48f4-45d7-842a-2f0cc2bc3de7"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("5545539f-b61c-4241-a569-0bb2691b803d"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("7799699d-5acb-49b7-9ffd-70bca31abf2f"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("b3150126-9986-4dce-a92a-cffffadeeb11"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "TripInvitations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ActivityId", "Content", "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("2d32cfe7-d537-4264-b2be-022bcb71e9aa"), new Guid("f2d85352-0c93-4f58-9739-4e0d63ca90d1"), "I’ve always wanted to visit this museum. The history here is so rich!", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("56c91246-7bed-4839-80c1-26b9961fb741"), new Guid("a3c9c52c-038f-4b3e-a9bc-26496fcbfa0b"), "I’m excited for the hiking trip. The views are going to be breathtaking!", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("57a6ffe1-fe80-4e37-9efa-12015440cbdc"), new Guid("b8d3c7d2-8a8e-45d0-8b1a-cbc32bc3b53d"), "Alpine dining sounds so cozy. Can’t wait to try the Swiss specialties.", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("5eaaf086-621e-4ec5-9471-958f0c975836"), new Guid("da699d06-56b7-4fbd-89b1-b24fdf9b7ab2"), "Exploring the old town will be such a charming experience. Can’t wait!", new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("69f6738e-ddc1-47d6-b726-1ca8ecd54545"), new Guid("4a7cb92b-2b6a-4316-8bb0-402497c47bdb"), "The underwater adventure is a must-try! The reefs look amazing.", new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("6a6396a5-bd09-4266-ab64-d82ea72ac757"), new Guid("343f58ed-97d1-4324-b231-71e7a3d577e5"), "The cultural dance show will be such a treat. I love traditional performances.", new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("a829b201-04e8-4d66-8b1d-726f6438373f"), new Guid("92d62312-4397-4c9d-9172-2c8a53e8c6a4"), "Snorkeling at Coral Reef Bay will be a highlight of the trip for sure!", new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5") },
                    { new Guid("ae426b06-094a-49dd-9a86-c5d8e0d8411c"), new Guid("175a8012-6200-4180-915b-f3e4d604923d"), "The beach day sounds so relaxing! Can’t wait to enjoy the sun and sea breeze.", new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("bbc4ed5b-535f-4e9b-ae0b-1b3e42596aef"), new Guid("d7f9d8ed-4f65-4859-a837-d4a512bf7a6b"), "Looking forward to the classic diner experience on Route 66!", new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85") },
                    { new Guid("c62a97ba-d224-477a-9b6a-f2b051141618"), new Guid("ff8f6c32-8e22-4a3c-8d8a-2f1e5b557477"), "The national park tour will be such a scenic experience. Looking forward to it!", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85") },
                    { new Guid("c8a0970c-943a-4230-909f-038723c75bc1"), new Guid("9b0ecf93-c42d-4c45-9ecb-85b8fe7e2d7c"), "Tasting tropical drinks will be a refreshing break. Can’t wait!", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5") },
                    { new Guid("cc78771f-bace-48d1-b7db-0ce895e7d6ff"), new Guid("8d69e4e8-62b1-465d-bfc7-1a94c3d07a71"), "Island hopping will be such a fun way to explore the Maldives!", new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("e42e4412-13cb-45ee-8276-687e7d4071fa"), new Guid("d7e309b1-dde9-48f5-99b5-7d3c6f153032"), "Skiing in the Alps is a dream come true! Can’t wait for this adventure.", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("ef3a9d07-082b-4bc2-a340-80a37f98f392"), new Guid("bfa47491-e758-4330-bc10-2e60d9a3479d"), "A sunset drive along the coast sounds like the perfect way to relax.", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85") },
                    { new Guid("f5be65e2-5d85-48a9-a9f4-6a6aa631d942"), new Guid("64f3cda1-70cf-4b52-99b2-d9c60a5b5898"), "Beach day with blue waters and sun? Yes, please!", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5") }
                });

            migrationBuilder.InsertData(
                table: "UserTrips",
                columns: new[] { "Id", "CreatedAt", "TripId", "UserId" },
                values: new object[,]
                {
                    { new Guid("286be131-ea5a-4099-afa7-26db4efdd6eb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f927882-1196-4d72-917d-972c6de3f1b4"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("4918405d-c748-415c-9492-bc96a9aa02cd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("de59cf42-eb57-4045-b7bc-a578db398ad2"), new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("6522e40a-bac2-4567-908d-dcd071166cb8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("172d5607-5dbd-4361-bf3f-fa76bfb84f70"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("68840bbc-076e-437b-8f0a-c9216899fd91"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f927882-1196-4d72-917d-972c6de3f1b4"), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") }
                });

            migrationBuilder.InsertData(
                table: "UsersVotes",
                columns: new[] { "Id", "ActivityId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4828ac00-f59d-4993-a5de-03eae2816b1f"), new Guid("8d69e4e8-62b1-465d-bfc7-1a94c3d07a71"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("58f3986c-2027-4a80-8559-87e669817032"), new Guid("4a7cb92b-2b6a-4316-8bb0-402497c47bdb"), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("aaaca29b-657e-4b67-8fcf-68864cb1b07b"), new Guid("64f3cda1-70cf-4b52-99b2-d9c60a5b5898"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("e7730dd4-0dbd-45ca-937a-3ff9af6ba29b"), new Guid("175a8012-6200-4180-915b-f3e4d604923d"), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("2d32cfe7-d537-4264-b2be-022bcb71e9aa"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("56c91246-7bed-4839-80c1-26b9961fb741"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("57a6ffe1-fe80-4e37-9efa-12015440cbdc"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("5eaaf086-621e-4ec5-9471-958f0c975836"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("69f6738e-ddc1-47d6-b726-1ca8ecd54545"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("6a6396a5-bd09-4266-ab64-d82ea72ac757"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("a829b201-04e8-4d66-8b1d-726f6438373f"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("ae426b06-094a-49dd-9a86-c5d8e0d8411c"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("bbc4ed5b-535f-4e9b-ae0b-1b3e42596aef"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c62a97ba-d224-477a-9b6a-f2b051141618"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c8a0970c-943a-4230-909f-038723c75bc1"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("cc78771f-bace-48d1-b7db-0ce895e7d6ff"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("e42e4412-13cb-45ee-8276-687e7d4071fa"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("ef3a9d07-082b-4bc2-a340-80a37f98f392"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("f5be65e2-5d85-48a9-a9f4-6a6aa631d942"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("286be131-ea5a-4099-afa7-26db4efdd6eb"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("4918405d-c748-415c-9492-bc96a9aa02cd"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("6522e40a-bac2-4567-908d-dcd071166cb8"));

            migrationBuilder.DeleteData(
                table: "UserTrips",
                keyColumn: "Id",
                keyValue: new Guid("68840bbc-076e-437b-8f0a-c9216899fd91"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("4828ac00-f59d-4993-a5de-03eae2816b1f"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("58f3986c-2027-4a80-8559-87e669817032"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("aaaca29b-657e-4b67-8fcf-68864cb1b07b"));

            migrationBuilder.DeleteData(
                table: "UsersVotes",
                keyColumn: "Id",
                keyValue: new Guid("e7730dd4-0dbd-45ca-937a-3ff9af6ba29b"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TripInvitations");

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ActivityId", "Content", "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("150e712f-55c0-46c1-8697-121f3f014abf"), new Guid("da699d06-56b7-4fbd-89b1-b24fdf9b7ab2"), "Exploring the old town will be such a charming experience. Can’t wait!", new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("3278e7d5-4ca9-46d2-87fc-2e7211c77836"), new Guid("8d69e4e8-62b1-465d-bfc7-1a94c3d07a71"), "Island hopping will be such a fun way to explore the Maldives!", new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("3aeffaa2-c370-4213-8637-304104d3ca94"), new Guid("a3c9c52c-038f-4b3e-a9bc-26496fcbfa0b"), "I’m excited for the hiking trip. The views are going to be breathtaking!", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("46bc90d6-e7af-4260-83ec-da7be9c458cc"), new Guid("b8d3c7d2-8a8e-45d0-8b1a-cbc32bc3b53d"), "Alpine dining sounds so cozy. Can’t wait to try the Swiss specialties.", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("569d3756-8e80-46a3-b4c0-337e1ead80f0"), new Guid("9b0ecf93-c42d-4c45-9ecb-85b8fe7e2d7c"), "Tasting tropical drinks will be a refreshing break. Can’t wait!", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5") },
                    { new Guid("5db02ddb-fd00-4f64-8d54-e6aa56d49562"), new Guid("92d62312-4397-4c9d-9172-2c8a53e8c6a4"), "Snorkeling at Coral Reef Bay will be a highlight of the trip for sure!", new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5") },
                    { new Guid("6864b8f0-6514-4c16-98d4-466d6f1ad7e6"), new Guid("64f3cda1-70cf-4b52-99b2-d9c60a5b5898"), "Beach day with blue waters and sun? Yes, please!", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5") },
                    { new Guid("814cdcca-4650-4038-aa01-f990bd50497c"), new Guid("ff8f6c32-8e22-4a3c-8d8a-2f1e5b557477"), "The national park tour will be such a scenic experience. Looking forward to it!", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85") },
                    { new Guid("94e99cf4-d332-410e-aa14-934b19ddbd4d"), new Guid("175a8012-6200-4180-915b-f3e4d604923d"), "The beach day sounds so relaxing! Can’t wait to enjoy the sun and sea breeze.", new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("a24004d8-9dd0-4193-bdc3-c04ee866c151"), new Guid("bfa47491-e758-4330-bc10-2e60d9a3479d"), "A sunset drive along the coast sounds like the perfect way to relax.", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85") },
                    { new Guid("b1bd26fb-d563-4fb0-8ac5-ca9ba39ebe5c"), new Guid("343f58ed-97d1-4324-b231-71e7a3d577e5"), "The cultural dance show will be such a treat. I love traditional performances.", new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("c203268f-ebc9-4baf-abea-5e5aa0491433"), new Guid("4a7cb92b-2b6a-4316-8bb0-402497c47bdb"), "The underwater adventure is a must-try! The reefs look amazing.", new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("c20baa60-5e0c-465c-a31a-e50e97f8756f"), new Guid("f2d85352-0c93-4f58-9739-4e0d63ca90d1"), "I’ve always wanted to visit this museum. The history here is so rich!", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("c8116aff-57c3-4f06-923b-3a9c4121e1f1"), new Guid("d7f9d8ed-4f65-4859-a837-d4a512bf7a6b"), "Looking forward to the classic diner experience on Route 66!", new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85") },
                    { new Guid("e5cc13e3-5f71-4608-b450-4f7b36d5675b"), new Guid("d7e309b1-dde9-48f5-99b5-7d3c6f153032"), "Skiing in the Alps is a dream come true! Can’t wait for this adventure.", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") }
                });

            migrationBuilder.InsertData(
                table: "UserTrips",
                columns: new[] { "Id", "CreatedAt", "TripId", "UserId" },
                values: new object[,]
                {
                    { new Guid("01cad319-df4b-4370-abfe-514293f38d39"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f927882-1196-4d72-917d-972c6de3f1b4"), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("0d7b8b12-f570-46e5-a71c-bc2775de05e4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("172d5607-5dbd-4361-bf3f-fa76bfb84f70"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("90353124-48cf-4cba-86d5-db0b206f1475"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f927882-1196-4d72-917d-972c6de3f1b4"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("b0efd82d-9e29-465d-bed8-5045320ecdcf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("de59cf42-eb57-4045-b7bc-a578db398ad2"), new Guid("0eaed767-eecd-4d19-a853-9da895e78057") }
                });

            migrationBuilder.InsertData(
                table: "UsersVotes",
                columns: new[] { "Id", "ActivityId", "UserId" },
                values: new object[,]
                {
                    { new Guid("438b139c-48f4-45d7-842a-2f0cc2bc3de7"), new Guid("8d69e4e8-62b1-465d-bfc7-1a94c3d07a71"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("5545539f-b61c-4241-a569-0bb2691b803d"), new Guid("4a7cb92b-2b6a-4316-8bb0-402497c47bdb"), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("7799699d-5acb-49b7-9ffd-70bca31abf2f"), new Guid("175a8012-6200-4180-915b-f3e4d604923d"), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") },
                    { new Guid("b3150126-9986-4dce-a92a-cffffadeeb11"), new Guid("64f3cda1-70cf-4b52-99b2-d9c60a5b5898"), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") }
                });
        }
    }
}
