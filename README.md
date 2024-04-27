# FunPokedex

FunPokedex is a C# project aimed at providing a playful interface for exploring Pokémon data. It consists of a Web API, a library for handling Pokémon data, and a unit test project for ensuring the correctness of the library.

## Project Structure
The solution is organized into three projects:

FunPokedex.WebAPI: This project contains the Web API implementation. It serves as the entry point for interacting with the FunPokedex functionality over HTTP.
FunPokedex.Library: The library project encapsulates the core logic for fetching and manipulating Pokémon data. It's designed for reuse across different applications and platforms.
FunPokedex.Library.UnitTest: This project contains unit tests written in xUnit framework to verify the correctness of the library's functionalities.

## Dependencies
The project relies on the following external libraries:

Newtonsoft.Json: Used for JSON serialization and deserialization, essential for handling Pokémon data in JSON format.
Microsoft.AspNet.WebApi.Client: Required for building and consuming HTTP services within the Web API project.

## Setup Instructions
To set up the FunPokedex project locally, follow these steps:

Clone the repository from GitHub:
git clone https://github.com/federicopessina/FunPokedex.git

2. Open the solution in your preferred IDE or text editor.
3. Ensure that you have Docker installed on your machine if you intend to deploy the application using Docker containers.
4. Install the required NuGet packages for each project. You can do this by restoring NuGet packages using the following command in the package manager console:
dotnet restore

5. Build the solution to ensure everything is set up correctly.
6. Run the unit tests to verify the correctness of the library project.

## Running the Web API
To run the FunPokedex Web API locally, follow these steps:

Set FunPokedex.WebAPI project as the startup project in your IDE.
Build the solution to ensure that all dependencies are resolved.
Start the application. This will launch the Web API and make it available for HTTP requests.
You can now send HTTP requests to the API endpoints to interact with the FunPokedex functionality.

## Contributing
Contributions to the FunPokedex project are welcome! If you find any bugs, have feature requests, or would like to contribute enhancements, feel free to submit a pull request or open an issue on the GitHub repository.
