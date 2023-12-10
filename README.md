# Payslip Coding Assignment

This document provides instructions on how to set up and run the Payslip Coding Assignment application.

## Prerequisites

Before you begin, ensure you have the following installed:
- [.NET SDK](https://dotnet.microsoft.com/download) (.NET 8.0)
- [Node.js](https://nodejs.org/) (LTS version recommended)

## Setting Up the Application

Follow these steps to set up the application on your local machine.

### 1. Clone the Repository

If you haven't already, clone the repository to your local machine:

```sh
git clone https://github.com/raymundmt/payslip-coding-assignment.git
```

Navigate to the root directory of the cloned repository.

### 2. Load NuGet Dependencies

Restore the NuGet packages required by the backend application:

```sh
cd "<path-to-your-clone>"  # Replace with the actual path
dotnet restore
```

### 3. Load Node Dependencies

Install the Node.js dependencies for the front-end application:

```sh
cd "./src/Web/payslipcodingassignment.client" 
npm install
```

## Running the Application

To run the application, execute the following steps:

### 1. Start the Backend Server

Navigate to the backend application directory and start the server:

```sh
cd "../PayslipCodingAssignment.Server" 
dotnet run
```

Wait for the backend server to start and listen for connections.

### 2. Access the Application

Once the backend server and client console are running, you can access the Payslip Generator application in your web browser:

[Payslip Generator](https://localhost:5173/)

Ensure that the URL matches the one outputted by Vite in your console.

## Additional Information

- **Running Tests**: To execute tests, use `dotnet test` in the root source directory.
- **Running Tests with Coverage**: To execute tests with coverage, use `dotnet test --collect:"XPlat Code Coverage"` in the root source directory.
- **Frontend Development**: For frontend development tasks like building or running a development server, navigate to the front-end directory (/src/Web/payslipcodingassignment.client) and use standard Node.js commands (e.g., `npm start` for starting a development server).