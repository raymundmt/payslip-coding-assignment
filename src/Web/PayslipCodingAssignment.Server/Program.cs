using Newtonsoft.Json;
using PayslipCodingAssignment.Application.DTOs;
using PayslipCodingAssignment.Application.Interfaces;
using PayslipCodingAssignment.Application.Services;
using PayslipCodingAssignment.Application.Validators;
using PayslipCodingAssignment.Domain.Calculators;
using PayslipCodingAssignment.Domain.Interfaces;
using PayslipCodingAssignment.Infrastructure.Loggers;
using PayslipCodingAssignment.Infrastructure.Services;
using Serilog;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(typeof(IAppLogger<>), typeof(SerilogLogger<>));
builder.Services.AddScoped<IIncomeTaxCalculator, IncomeTaxCalculator>();
builder.Services.AddScoped<IGrossIncomeCalculator, GrossIncomeCalculator>();
builder.Services.AddScoped<ISuperCalculator, SuperCalculator>();
builder.Services.AddScoped<ITaxBracketService, TaxBracketService>(provider => new TaxBracketService(@"Resources\tax-brackets.json"));
builder.Services.AddScoped<IDtoValidator<EmployeeInputDto>, EmployeeInputValidator>();
builder.Services.AddScoped<PayslipService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/generate-payslip", (EmployeeInputDto input, HttpContext context, PayslipService payslipService, IAppLogger<Program> logger) =>
{
    try
    {
        logger.LogInformation($"generate-payslip input {JsonConvert.SerializeObject(input, Formatting.Indented)}");
        var payslip = payslipService.GeneratePayslip(input);
        logger.LogInformation($"generate-payslip output {JsonConvert.SerializeObject(payslip, Formatting.Indented)}");
        return Results.Ok(payslip);
    }
    catch (Exception ex) when (ex is ValidationException || ex is ArgumentException)
    {
        logger.LogError($"Error occured: {ex.Message}");
        return Results.Problem(ex.Message);
    }
});

app.Run();

public partial class Program { }
