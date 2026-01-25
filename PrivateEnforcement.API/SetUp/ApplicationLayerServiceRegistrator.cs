using Application.Administration.Commands.CreateEnforcement;
using Application.Administration.Commands.DeleteEnforcement.Block;
using Application.Administration.Commands.UpdateEnforcement;
using Application.Administration.Queries.EnforcementList;
using Application.Employees.Commands.CreateEmployee;
using Application.EnforcementEmployees.Commands.DeleteEmployee;
using Application.EnforcementEmployees.Commands.UpdateEmployee;
using Application.EnforcementEmployees.Queries.EmployeesList;
using Application.ObligatorAssets.Commands.CreateObligatorAsset;
using Application.ObligatorAssets.Commands.DeleteObligatorAsset;
using Application.ObligatorAssets.Commands.UpdateObligatorAsset;
using Application.ObligatorAssets.Queries;
using Application.Obligators.Commands.CreateObligator;
using Application.Obligators.Commands.DeleteObligator;
using Application.Obligators.Commands.UpdateObligator;
using Application.Obligators.Queries.ObligatorsList;
using Domain.DAL;

namespace PrivateEnforcement.API.SetUp;

/// <summary>
///     Static class that encapsulates service registration from Application.csproj.
///     Internal class in Application.csproj is accessiable via modification its .csproj file,
///     making its internal classes visible for PrivateEnforcement.API.
/// </summary>
public static class ApplicationLayerServiceRegistrator
{
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        // Services for Administration.
        services.AddScoped<ICreateEnforcement, CreateEnforcementCommand>();
        services.AddScoped<IBlockEnforcement, BlockEnforcement>();
        services.AddScoped<IUpdateEnforcement, UpdateEnforcementCommand>();
        services.AddScoped<IEnforcementList,  EnforcementListCommand>();

        // Services for EnforcementEmployees.
        services.AddScoped<ICreateEmployee, CreateEmployeeCommand>();
        services.AddScoped<IDeleteEmployee, DeleteEmployeeCommand>();
        services.AddScoped<IUpdateEmployee, UpdateEmployeeCommand>();
        services.AddScoped<IEmployeesList, EmployeeListCommand>();

        // Services for ObligatorAssets.
        services.AddScoped<ICreateObligatorAsset, CreateObligatorAssetCommand>();
        services.AddScoped<IDeleteObligatorAsset, DeleteObligatorAssetCommand>();
        services.AddScoped<IUpdateObligatorAsset, UpdateObligatorAssetCommandAsync>();
        services.AddScoped<IQueryObligatorAsset, QueryObligatorAssetCommand>();

        // Services for Obligators.
        services.AddScoped<ICreateObligator, CreateObligatorCommand>();
        services.AddScoped<IDeleteObligator,  DeleteObligatorCommand>();
        services.AddScoped<IUpdateObligator, UpdateObligatorCommand>();
        services.AddScoped<IObligatorsList, ObligatorsListHandler>();

    }
}
