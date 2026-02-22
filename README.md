# devops-project

This project was created as part of DevOps coursework.  
It demonstrates a complete CI/CD pipeline for an ASP.NET Core Web API application deployed to Microsoft Azure.

---

## Application Overview

The application is a minimal ASP.NET Core Web API built with .NET 8.  
It exposes two HTTP endpoints:

- `GET /`  
  Returns a welcome message along with the current UTC timestamp.

- `GET /products`  
  Returns a static list of sample products in JSON format.

The purpose of the project is to demonstrate automated build, test, deployment, monitoring, and containerization processes.

---

## Continuous Integration (CI)

Continuous Integration is implemented using GitHub Actions.

The CI pipeline is triggered on Pull Requests and performs the following steps:

1. Restore NuGet dependencies
2. Build the solution in Release configuration
3. Execute unit tests

This process ensures that all changes are validated before being merged into the `main` branch.

---

## Continuous Deployment (CD)

Continuous Deployment is configured using GitHub Actions.

On every push to the `main` branch, the pipeline:

1. Restores dependencies
2. Builds the solution
3. Executes tests
4. Publishes the application
5. Deploys the build artifact to Azure App Service

### Production URL

The application is deployed to Azure App Service and is publicly available at:

https://devops-petir-123-bpbjb9c3bscffsew.polandcentral-01.azurewebsites.net/

---

## Monitoring

Application monitoring is implemented using Azure Application Insights.

The monitoring setup provides:

- HTTP request tracking
- Error logging
- Performance metrics
- Live telemetry data

The Application Insights connection string is stored securely as:

- A GitHub repository secret (for CI/CD)
- An environment variable in Azure App Service (for production)

No sensitive configuration values are stored in the repository.

---

## Docker Support

The project includes a multi-stage Dockerfile for containerization.

### Build the Docker image

docker build -t devops-project .

### Run the container

docker run --rm -p 8080:8080 devops-project

### Local Endpoints

http://localhost:8080/  
http://localhost:8080/products

The container runs the application on port 8080.

---

## Testing

The solution includes an xUnit test project.

To execute tests locally:

dotnet test

All tests are automatically executed as part of the CI pipeline.

---

## Security

Sensitive data such as deployment credentials and telemetry connection strings are not stored in the repository.

Secrets are managed using:

- GitHub Secrets
- Azure App Service environment variables

This approach ensures secure configuration management across environments.
