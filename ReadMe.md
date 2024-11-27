<h1 align="center" style="font-weight: bold;">Out The GC</h1>

<p align="center">This is the server-side for the fullstack application called **Out The GC** - a trip planner app that was designed to streamline travel planning for individuals and groups. </P>

<h3 align="center">Ideal User</h3>
The ideal user is someone who values organized and collaborative travel planning. This includes groups of friends or families coordinating vacations, coworkers planning team retreats, or even solo travelers who want to structure their itineraries efficiently. Users are likely tech-savvy individuals who appreciate streamlined tools to consolidate ideas, eliminate planning chaos, and ensure everyone's input is considered for a well-rounded travel experience.

## Table of Conetents
- <a href="#tech-stack">Tech Stack</a>
- <a href="#erd">Entity Relationship Diagram</a>
- <a href="#getting-started">Getting Started</a>
- <a href="#api-endpoints">API Endpoints</a>
- <a href="#postman-documentation">Postman Documentation</a>
- <a href="#colaborators">Collaborators</a>

<h2 id="erd">Entity Relationship Diagram</h2>
Here is the link to the ERD: <a href="https://dbdiagram.io/d/Full-Stack-Capstone-6583a0b156d8064ca06bd425"">ERD</a>

<h2 id="tech-stack">Tech Stack</h2>

- C#
- .NET
- Entity Framework Core
- Moq
- xUnit
- PostgreSQL
- pgAdmin
- Swagger
- Postman

<h2 id="getting-started">Getting started</h2>

<h3>Prerequisites</h3>

For this project to run, you'll need to install the following:

- [.NET](https://dotnet.microsoft.com/en-us)
- [PostgreSQL](https://www.postgresql.org/download)
- [pgAdmin](https://www.pgadmin.org)

<h3>1. Clone the Repo</h3>

Clone this repo using this command in your terminal:

```bash
git clone git@github.com:britnay268/OutTheGC.git
```

<h3>2. Install Required Packages</h3>

Once the repository is cloned, navigate to the project directory in your terminal and run the following commands to install necessary packages:

```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 6.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0
```

<h3>3. Set Up Secrets for PostgreSQL Connection</h3>

To store sensitive connection details, initialize the secret storage with:

```bash
dotnet user-secrets init
```

Then, set the connection string for your PostgreSQL database (replace with your actual PostgreSQL password):

```bash
dotnet user-secrets set "OutTheGCDbConnectionString" "Host=localhost;Port=5432;Username=postgres;Password=<your_postgresql_password>;Database=OutTheGC"
```

<h3>4. Apply Migrations to the Database</h3>

Run the following command to apply the database migrations:

```bash
dotnet ef database update
```

This will create the necessary tables and schema in your PostgreSQL database.

<h3>5. Run the Solution</h3>

Launch the project. Swagger should automatically launch and provide you with the API documentation.

<h2 id="api-endpoints">API Endpoints</h2>

| Endpoints                  |
|------------------------------------------|
| **Activity**                              |
| GET /activity/{activityId}               |
| GET /activity/{tripId}/search            |
| POST /activity                           |
| PUT /activity/{activityId}               |
| DELETE /activity/{activityId}            |
|                                          |
| **Category**                              |
| GET /categories                          |
|                                          |
| **Comment**                               |
| GET /comment/{commentId}                 |
| POST /comment                            |
| PUT /comment/{commentId}                 |
| DELETE /comment/{commentId}              |
|                                          |
| **Trip**                                  |
| GET /trips                               |
| GET /trip/{tripId}                       |
| POST /trip                               |
| PUT /trip/{tripId}                       |
| DELETE /trip/{tripId}                    |
| DELETE /trip/{tripId}/user/{userId}      |
|                                          |
| **User**                                  |
| GET /user/{userId}                       |
| GET /user/exists                         |
| POST /user                               |
| PUT /user/{userId}                       |
| DELETE /user/{userId}                    |


<h2 id="postman-documentation">Postman Documentation</h2>

Checkout the [Out The GC](https://documenter.getpostman.com/view/31929847/2sAYBViCP4) Postman Collction to learn more about the API endpoints mentioned above!

<h2 id="colaborators">Collaborators</h2>

<table>
<td align="center">
<a href="https://github.com/britnay268">
<img src="https://avatars.githubusercontent.com/u/153968439?v=4" width="100px;" alt="Britnay Gore's' Profile Picture"/><br>
<sub>
<b>Britnay Gore/b>
</sub>
</a>
</td>

</tr>
</table>
