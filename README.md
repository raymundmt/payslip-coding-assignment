# Payslip Coding Assignment

This document provides detailed instructions on setting up and running the Payslip Coding Assignment application, along with steps for testing both the backend and frontend components.

## Prerequisites

Before beginning, ensure the following are installed on your system:
- [.NET SDK](https://dotnet.microsoft.com/download) (version .NET 8.0)
- [Node.js](https://nodejs.org/) (LTS version recommended)

## Setting Up the Application

To set up the application on your local machine, follow these steps:

### 1. Clone the Repository

First, clone the repository to your local machine:

```sh
git clone https://github.com/raymundmt/payslip-coding-assignment.git
```

Then, navigate to the root directory of the cloned repository.

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

Execute the following steps to run the application:

### 1. Start the Backend Server

Navigate to the backend application directory and start the server:

```sh
cd "../PayslipCodingAssignment.Server" 
dotnet run
```

Wait until the backend server is up and listening for connections.

### 2. Access the Application

After the backend server and client console are running, access the Payslip Generator application in your web browser:

[Payslip Generator](https://localhost:5173/)

Ensure the URL matches the one output by Vite in your console.

## Testing the Application

### Backend Testing

- **Running Tests**: To execute backend tests, use `dotnet test` in the root source directory.
- **Running Tests with Coverage**: To execute tests with coverage, use `dotnet test --collect:"XPlat Code Coverage"` in the root source directory.

### Frontend Testing

Navigate to the frontend application directory (`/src/Web/payslipcodingassignment.client`) for frontend testing.

- **Running Tests**: Execute `npm test` to run the frontend tests.
- **Running Tests with Coverage**: Use `npm run coverage` to run tests with coverage analysis.

## Additional Information

- **Frontend Development**: For tasks like building or running a development server, use standard Node.js commands (e.g., `npm start` for starting a development server) in the front-end directory.