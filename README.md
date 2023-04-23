# BallastLaneTest
-------------------------------------------------------------------------------------------------------------------------------------------------
Hello, my name is Gabriel Recagno and this is an brief explanation of what I did on this project.
-------------------------------------------------------------------------------------------------------------------------------------------------
Database:

In the scripts folder scripts folder there are 3 scripts for the creation of the database and tables structure, insert of mock data and creation of SP.
The database is created on SQL Server and will provide the processing of the CRUD operations for Books and Creation and Authentication of Users,
it uses stored procedures to work directly on the tables and return status and information to be listed.
-------------------------------------------------------------------------------------------------------------------------------------------------
Data Project:

The responsibility of this class library project built on .NET 6 is to resolve any operation that requires a database connection, it is secured
and optimized using Factory and Singleton combined.

Only interacts with Database.
-------------------------------------------------------------------------------------------------------------------------------------------------
Business Logic Project:

The responsibility of this class library project built on .NET 6 is to resolve any operation that has business logic involved as well as connect
to data layer, it is secured and optimized using Factory and Singleton combined.

Only interacts with Data Layer.
-------------------------------------------------------------------------------------------------------------------------------------------------
Web API Project:

This is an ASP.NET Core Web API that exposes CRUD operations for Books and Creation and Authentication of Users. It connects to Business Logic layer
in order to get the information needed on the request and leaves to it the responsibility of making the process.

Only interacts with Business Logic Layer.
-------------------------------------------------------------------------------------------------------------------------------------------------
Models:

Data, Business Logic and Web API Projects need to get access to Models to build the information that is used throw the execution flow and, 
to accomplish that, they use this Layer who is the only one referenced from the rest of the projects. The purpose of creating this Project
is to avoid rewriting the Models code for each Layer.
-------------------------------------------------------------------------------------------------------------------------------------------------