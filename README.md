# CV Builder ASP.NET Core MVC

CV Builder ASP.NET Core MVC is a web application built using the ASP.NET Core MVC framework. It provides a user-friendly interface to create and manage professional CVs (curriculum vitae) online.

## Features

- User Registration and Authentication: Users can create accounts and authenticate to access the CV Builder.
- CV Creation: Users can easily create and customize their CVs using a user-friendly interface.
- Sections and Fields: CVs can be organized into various sections such as Education, Work Experience, Skills, etc., with customizable fields.
- Templates: Multiple CV templates are available to choose from, allowing users to select a design that suits their preferences.
- Download : Users can download their created CVs in PDF format.

## Installation

1. Clone the repository:
git clone https://github.com/NaimurRahman76/CvBuilder.git


2. Open the project in Visual Studio:

- Launch Visual Studio.
- Select "Open a project or solution" from the start menu or go to "File" > "Open" > "Project/Solution".
- Navigate to the cloned project directory and select the solution file (`Cv Maker.sln`).
- Click "Open" to load the project in Visual Studio.

3. Configure the database connection string:

- Open the `appsettings.json` file in the project.
- Locate the `ConnectionStrings` section.
- Update the database connection string with your desired configuration.

4. Apply database migrations:

- Open the Package Manager Console in Visual Studio (`Tools` > `NuGet Package Manager` > `Package Manager Console`).
- Ensure that the default project selected in the Package Manager Console is the project containing the migrations (e.g., `CvBuilder.Data`).
- Run the following command to apply the database migrations:

  ```
  Update-Database
  ```

5. Run the application:
   
   - Open the solution in Visual Studio.
   - Press the "Start" button or use the shortcut F5 to run the application.
   - The application will launch in your default browser at `https://localhost:5001`.


## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- HTML/CSS
- JavaScript

## Contributing

Contributions to the project are welcome. If you find any bugs or have suggestions for new features, please open an issue or submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).



