# Credit Card Pre-Qualification Demo

A demo of a Credit Card pre-qualification form.

# To run the project locally
 - Open the solution in Visual Studio
 - Set 'CreditCard.PreQualification.Demo.Web' as the startup project
 - In Package Manager console, run 'update-database' (this should create the database in LocalDb)
 - Run the web project

# To run tests
The web project has a suite of Unit tests and Acceptance tests built using XUnit.
These can be run in Visual Studio by right-clicking the solution and choosing 'Run Unit Tests'

# To view data locally
When running locally, the web project is configured to use LocalDb.
Data can be viewed in Visual Studio using SQL Server Object Explorer;
 - Open the database 'credit-card-pre-qualification-demo'
 - Right-click 'dbo.CustomerApplications', click 'View Data'