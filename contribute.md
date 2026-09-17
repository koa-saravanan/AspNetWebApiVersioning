You can contribute through the standard fork-and-pull-request workflow. This repository is very new—its `main` branch currently has an initial commit, no open issues, and no visible `CONTRIBUTING.md`—so it’s a good opportunity to propose improvements directly.

## Suggested workflow

1. **Fork the repository**  
   [Fork `ezzylearning/AI_Agents_In_CSharp_Dotnet`](https://github.com/ezzylearning/AI_Agents_In_CSharp_Dotnet/fork)

2. **Clone your fork and create a branch**
   ```bash
   git clone https://github.com/<your-username>/AI_Agents_In_CSharp_Dotnet.git
   cd AI_Agents_In_CSharp_Dotnet
   git checkout -b improve-documentation
   ```

3. **Make a focused change**, test it locally, and commit it.

4. **Push your branch and open a pull request** against `main`:
   ```bash
   git push origin improve-documentation
   ```

## Good contribution opportunities

- **Add project documentation**: setup instructions, prerequisites, API usage, architecture, and how to run the AI agent.
- **Add a `CONTRIBUTING.md` file** describing coding standards, branch naming, testing, and pull-request expectations.
- **Add tests** for the support agent, API controller, order repository, and `OrderTools`.
- **Improve the API contract**: `SupportController` currently accepts `message` as a query parameter for `POST /api/support/ask`; a request DTO with validation and an explicit JSON body would make the endpoint clearer.
- **Improve local setup**: the project targets .NET 10 and uses SQL Server, Entity Framework Core, `Microsoft.Agents.AI`, and Ollama. Document the required SQL Server database, Ollama model, and configuration.
- **Add provider abstractions or implementations**: the current infrastructure registers `OllamaCustomerSupportAgent`, so support for another model/provider could be a useful extension.
- **Add observability and error handling**: validation, structured logging, cancellation handling, and safe user-facing errors would strengthen the API.
- **Add CI**: build and test the solution automatically with GitHub Actions.
- **Add database setup/migrations and sample data** for the Northwind database.

## Important security improvement

Before contributing code, I would open an issue or pull request to remove the hard-coded SQL Server connection string from [`Northwind.Api/appsettings.json`](https://github.com/ezzylearning/AI_Agents_In_CSharp_Dotnet/blob/main/Northwind.Api/appsettings.json). It contains a username and password. Replace it with a placeholder and document configuration through user secrets, environment variables, or another secure mechanism.

## Repository areas to start with

- API endpoint: [`Northwind.Api/Controllers/SupportController.cs`](https://github.com/ezzylearning/AI_Agents_In_CSharp_Dotnet/blob/main/Northwind.Api/Controllers/SupportController.cs)
- Agent abstraction: [`Northwind.Application/AI/Agents/ICustomerSupportAgent.cs`](https://github.com/ezzylearning/AI_Agents_In_CSharp_Dotnet/blob/main/Northwind.Application/AI/Agents/ICustomerSupportAgent.cs)
- AI tools: [`Northwind.Infrastructure/AI/Tools/OrderTools.cs`](https://github.com/ezzylearning/AI_Agents_In_CSharp_Dotnet/blob/main/Northwind.Infrastructure/AI/Tools/OrderTools.cs)
- Dependency registration: [`Northwind.Infrastructure/DependencyInjection.cs`](https://github.com/ezzylearning/AI_Agents_In_CSharp_Dotnet/blob/main/Northwind.Infrastructure/DependencyInjection.cs)

Since there are currently no open issues, you can either open an issue first to discuss a larger change or submit a focused pull request directly.
