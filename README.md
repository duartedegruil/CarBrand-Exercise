# Car Brand Exercise
**Overview**

This project was developed as an exercise for the coding interview at Primavera BSS.

The solution consists in a three-tier architecture:

- Data Layer - Microsoft SQL Server Database
- Application Layer - ASP.NET Core Web API
- Presentation Layer - Angular 11

It allows the user to persist car brands and their respective logos, and retrieve them by name.

**How to use**

This solution runs in Docker aggregated Linux containers, allowing each service to run in its own environment.

In order to build and start the composed Docker containers, the *Run_DockerCompose.ps1* script is included in the Tools directory. Before running this script, a small tweak is needed to allow the Web API to communicate with the Database. The user will need to change the credentials set in the connection string of the Web API (then rebuild the solution), as well as the ones used to build the DB Docker Image. These changes need to be made in the following files (Password was set to *Password@123* by default):

- CarBrandAPI/CarBrandAPI/appsettings.json
- Tools/docker-compose.yml

The ports configured by default are:

- Data Layer - 14331:1433
- Application Layer - 8080:80
- Presentation Layer - 4200:80
