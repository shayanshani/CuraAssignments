# Authentication API

## Overview

Authentication API is an ASP.NET Core MVC application designed for managing user authentication and authorization using JWT (JSON Web Tokens). It provides role-based access control and integrates with Swagger for API documentation.

## Features

- JWT Authentication for secure user login.
- Role-Based Access Control (RBAC) with predefined roles.
- Integration with Swagger for API documentation and testing.
- Configuration management via `appsettings.json`.

## Getting Started

### Prerequisites

- .NET Core SDK
- IDE (Visual Studio, Visual Studio Code, etc.)
- Git

### Installation

1. Clone the repository:
``
git clone https://github.com/shayanshani/CuraAssignments.git
``

2. Restore dependencies and build the project

### Usage

### 1. Run the application

2. Access the Swagger UI:
Open a web browser and go to `http://localhost:5000/swagger` to view and interact with the API endpoints.

### Configuration

### Update `appsettings.json` with your JWT secret key:
``
{
"AppSettings": {
"JwtSecret": "YourSuperSecretKey"
}
}
``

### API Endpoints

Explore the API endpoints using Swagger UI (`http://localhost:5000/swagger`):

- **POST** `/api/auth/login`: User login endpoint to generate JWT token.

