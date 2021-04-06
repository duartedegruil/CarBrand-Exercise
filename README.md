# Car Brand Exercise
**Overview**

This project was developed as an exercise for the coding interview at Primavera BSS.

The solution consists in a three-tier architecture:

- Data Layer :: Microsoft SQL Server Database
- Application Layer :: ASP.NET Core Web API
- Presentation Layer :: Angular 11

It allows the user to persist car brands and their respective logos, and retrieve them by name.

**How to use**

This solution runs in Docker aggregated containers, allowing each service to run in its own environment.

In order to build and start the composed Docker containers, the *Run_DockerCompose.ps1* script is included in the Tools directory. Before running this script, a small tweak is needed to allow the Web API to communicate with the Database. The user will need to change the credentials set in the connection string of the Web API (then rebuild the solution), as well as the ones used to build the DB Docker Image. These changes need to be made in the following files:

- CarBrandAPI/CarBrandAPI/appsettings.json
- Tools/docker-compose.yml