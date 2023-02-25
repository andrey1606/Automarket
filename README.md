# Automarket
The application implements authorisation via a JWT token. All unauthorised users are redirected to the login page. 

Once authorised, users can start interacting with the application. 

The Brands page displays a list of all car brands (the names of inactive brands are displayed pale). Users can add a new brand by specifying its name and activity status. Each existing brand can be edited or deleted.

The Models page shows a list of all car models (names of inactive models are displayed pale). The user can add a new model by specifying its name, corresponding brand and activity status. Each existing model can be edited or deleted. It is also possible to get a list of car models of specific brands only.

## Technologies Used

This web application was built using the following technologies:

- ASP.NET Core MVC
- Entity Framework Core
- PostgreSQL
- HTML and Bootstrap

## Getting Started

To get started with this project, follow these steps:

1. Clone this repository to your local machine:
```
git clone https://github.com/andrey1606/Walking-Diary.git
```
2. Install and configure PostgreSQL according to the instructions on the [official website](https://www.postgresql.org/download/).
3. Update the connection string in the `appsettings.json` file with your database connection details. There is no need to create the specified database, it will be created automatically when the application is launched for the first time. Also, the Brands and Models tables will automatically be populated with a small number of entries. 
4. In the same file (`appsettings.json`), update the values under "Jwt" if necessary. These values affect the token created during JWT authentication.
5. Build and run the project.
