using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutTheGC.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    DateJoined = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersVotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActivityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersVotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Destination = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Budget = table.Column<decimal>(type: "numeric", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TripId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Duration = table.Column<decimal>(type: "numeric", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTrips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TripId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTrips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTrips_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTrips_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActivityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("27b9d332-04d0-4c7e-8196-ef38fb4779cc"), "Adventure" },
                    { new Guid("48876876-6725-4225-9ae4-0279e87ce888"), "Food & Drinks" },
                    { new Guid("72ff3052-5d20-4996-afec-a837d4df2904"), "Relaxation & Wellness" },
                    { new Guid("973d6c63-ad42-475d-97bd-4197f484ad2a"), "Other" },
                    { new Guid("a0254d5f-f540-44df-908b-d33d7c0da285"), "Tours" },
                    { new Guid("a143452f-7b59-4082-8bfa-44faa0d963ed"), "Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "DateJoined", "Email", "FullName", "ImageUrl", "Uid" },
                values: new object[,]
                {
                    { new Guid("0eaed767-eecd-4d19-a853-9da895e78057"), "a ut erat id mauris vulputate elementumam varius.", new DateTime(2017, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "britnaygore268@gmail.com", "Britnay Gore", "", "" },
                    { new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5"), "Praesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.", new DateTime(2020, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "araya.west@rfsmart.com", "Araya West", "", "" },
                    { new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719"), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus.\n\nVestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.", new DateTime(2008, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "emariebroermann@gmail.com", "Emma Broermann", "", "" },
                    { new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85"), "Aenean lectus. Pellentesque eget nunc. Donec quis orci eget orci vehicula condimentum.\n\nCurabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo. Maecenas pulvinar lobortis est.", new DateTime(2006, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "nigel.henry@gmail.com", "Nigel Henry", "", "" },
                    { new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc"), "In sagittis dui vel nisl. Duis ac nibh. Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus.\n\nSuspendisse potenti. In eleifend quam a odio. In hac habitasse platea dictumst.", new DateTime(2009, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "liz.paquette08@gmail.com", "Liz Paquette", "", "" }
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

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Budget", "CreatedAt", "Destination", "EndDate", "ImageUrl", "Notes", "StartDate", "Status", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("0eb66928-c2b0-4eea-9e4a-f7363fc98778"), 4000.00m, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Switzerland", new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/images/alps.jpg", "An action-packed trip to the Swiss Alps for skiing and hiking.", new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed", "Adventure in the Alps", new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc") },
                    { new Guid("172d5607-5dbd-4361-bf3f-fa76bfb84f70"), 5000.00m, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahamas", new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/images/bahamas.jpg", "Escape to a private island in the Caribbean for rest and relaxation.", new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Planned", "Tropical Retreat", new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5") },
                    { new Guid("4da6ceb3-2c4d-475f-9afd-3eecd34d1523"), 2500.00m, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "USA", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/images/roadtrip.jpg", "A long road trip across the United States visiting national parks.", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Planned", "Road Trip USA", new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85") },
                    { new Guid("6f927882-1196-4d72-917d-972c6de3f1b4"), 3500.00m, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maldives", new DateTime(2024, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "https =//example.com/images/maldives.jpg", "A relaxing trip to the beach to unwind and explore new places.", new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Planned", "Summer Getaway", new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0eaed767-eecd-4d19-a853-9da895e78057") },
                    { new Guid("de59cf42-eb57-4045-b7bc-a578db398ad2"), 3200.00m, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Italy", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/images/italy.jpg", "A trip to explore the rich history and culture of Italy.", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed", "Cultural Escape", new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719") }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "CategoryId", "Cost", "CreatedAt", "Date", "Duration", "Location", "Notes", "Title", "TripId", "UpdatedAt", "UserId", "WebsiteUrl" },
                values: new object[,]
                {
                    { new Guid("175a8012-6200-4180-915b-f3e4d604923d"), new Guid("72ff3052-5d20-4996-afec-a837d4df2904"), 300m, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.5m, "Maldives Beach", "Spend a relaxing day on the beach, soaking in the sun and enjoying the ocean breeze.", "Beach Relaxation", new Guid("6f927882-1196-4d72-917d-972c6de3f1b4"), new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0eaed767-eecd-4d19-a853-9da895e78057"), "" },
                    { new Guid("343f58ed-97d1-4324-b231-71e7a3d577e5"), new Guid("a143452f-7b59-4082-8bfa-44faa0d963ed"), 75m, new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0m, "Cultural Center Theatre", "Attend an evening performance of traditional local dances and music.", "Cultural Dance Show", new Guid("de59cf42-eb57-4045-b7bc-a578db398ad2"), new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719"), "" },
                    { new Guid("4a7cb92b-2b6a-4316-8bb0-402497c47bdb"), new Guid("a143452f-7b59-4082-8bfa-44faa0d963ed"), 200m, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.0m, "Maldives Coral Reef", "Snorkeling in crystal clear waters, exploring coral reefs and marine life.", "Underwater Adventure", new Guid("6f927882-1196-4d72-917d-972c6de3f1b4"), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0eaed767-eecd-4d19-a853-9da895e78057"), "" },
                    { new Guid("64f3cda1-70cf-4b52-99b2-d9c60a5b5898"), new Guid("72ff3052-5d20-4996-afec-a837d4df2904"), 150m, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.0m, "Paradise Beach", "Spend a day on the pristine beach, enjoying the sun and clear blue waters.", "Beach Day", new Guid("172d5607-5dbd-4361-bf3f-fa76bfb84f70"), new DateTime(2024, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5"), "" },
                    { new Guid("8d69e4e8-62b1-465d-bfc7-1a94c3d07a71"), new Guid("48876876-6725-4225-9ae4-0279e87ce888"), 150m, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.0m, "Maldives Islands", "A day trip to visit nearby islands, enjoy different beaches, and local markets.", "Island Hopping", new Guid("6f927882-1196-4d72-917d-972c6de3f1b4"), new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0eaed767-eecd-4d19-a853-9da895e78057"), "" },
                    { new Guid("92d62312-4397-4c9d-9172-2c8a53e8c6a4"), new Guid("a143452f-7b59-4082-8bfa-44faa0d963ed"), 120m, new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.0m, "Coral Reef Bay", "Explore the underwater world, discovering vibrant marine life.", "Snorkeling Expedition", new Guid("172d5607-5dbd-4361-bf3f-fa76bfb84f70"), new DateTime(2024, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("24fda663-5bf9-4e0d-8efd-111ae512dff5"), "" },
                    { new Guid("9b0ecf93-c42d-4c45-9ecb-85b8fe7e2d7c"), new Guid("48876876-6725-4225-9ae4-0279e87ce888"), 70m, new DateTime(2024, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.5m, "Tropical Bar", "Savor the best tropical cocktails and exotic juices.", "Tropical Drinks Tasting", new Guid("172d5607-5dbd-4361-bf3f-fa76bfb84f70"), new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc"), "" },
                    { new Guid("a3c9c52c-038f-4b3e-a9bc-26496fcbfa0b"), new Guid("a143452f-7b59-4082-8bfa-44faa0d963ed"), 100m, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.5m, "Swiss Alps Trails", "A day hike through the picturesque alpine meadows and rugged terrain.", "Alpine Hiking", new Guid("0eb66928-c2b0-4eea-9e4a-f7363fc98778"), new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc"), "" },
                    { new Guid("b8d3c7d2-8a8e-45d0-8b1a-cbc32bc3b53d"), new Guid("48876876-6725-4225-9ae4-0279e87ce888"), 120m, new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0m, "Matterhorn Restaurant", "Enjoy a traditional Swiss meal at a mountaintop restaurant.", "Alpine Dining", new Guid("0eb66928-c2b0-4eea-9e4a-f7363fc98778"), new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc"), "" },
                    { new Guid("bfa47491-e758-4330-bc10-2e60d9a3479d"), new Guid("72ff3052-5d20-4996-afec-a837d4df2904"), 80m, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.5m, "Big Sur, California", "A leisurely drive along the Pacific Coast Highway to watch the sunset.", "Sunset Drive", new Guid("4da6ceb3-2c4d-475f-9afd-3eecd34d1523"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85"), "" },
                    { new Guid("d7e309b1-dde9-48f5-99b5-7d3c6f153032"), new Guid("27b9d332-04d0-4c7e-8196-ef38fb4779cc"), 400m, new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.0m, "Zermatt Ski Resort", "Hit the slopes for a thrilling day of skiing on the Swiss Alps.", "Skiing Adventure", new Guid("0eb66928-c2b0-4eea-9e4a-f7363fc98778"), new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8e98b8c4-6cf7-4817-b106-ffc59cbe83cc"), "" },
                    { new Guid("d7f9d8ed-4f65-4859-a837-d4a512bf7a6b"), new Guid("48876876-6725-4225-9ae4-0279e87ce888"), 40m, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.5m, "Route 66 Diner", "Stop at a famous American diner for a classic meal during the road trip.", "Local Diner Stop", new Guid("4da6ceb3-2c4d-475f-9afd-3eecd34d1523"), new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85"), "" },
                    { new Guid("da699d06-56b7-4fbd-89b1-b24fdf9b7ab2"), new Guid("a0254d5f-f540-44df-908b-d33d7c0da285"), 40m, new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.0m, "Old Town District", "Take a guided walking tour of the city's most iconic landmarks.", "Historic Walking Tour", new Guid("de59cf42-eb57-4045-b7bc-a578db398ad2"), new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719"), "" },
                    { new Guid("f2d85352-0c93-4f58-9739-4e0d63ca90d1"), new Guid("a0254d5f-f540-44df-908b-d33d7c0da285"), 50m, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0m, "National History Museum", "Explore the rich history of the region with a guided tour through the local museum.", "Museum Tour", new Guid("de59cf42-eb57-4045-b7bc-a578db398ad2"), new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("59c5b94d-8015-48cd-bd86-0dbe486c4719"), "" },
                    { new Guid("ff8f6c32-8e22-4a3c-8d8a-2f1e5b557477"), new Guid("a143452f-7b59-4082-8bfa-44faa0d963ed"), 200m, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.0m, "Yosemite National Park", "Visit several national parks in the western U.S. on a scenic road trip.", "National Park Tour", new Guid("4da6ceb3-2c4d-475f-9afd-3eecd34d1523"), new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("67a99b92-3485-4d39-8bce-33fe4fccfc85"), "" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CategoryId",
                table: "Activities",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TripId",
                table: "Activities",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserId",
                table: "Activities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ActivityId",
                table: "Comments",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_UserId",
                table: "Trips",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrips_TripId",
                table: "UserTrips",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrips_UserId",
                table: "UserTrips",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "UsersVotes");

            migrationBuilder.DropTable(
                name: "UserTrips");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
