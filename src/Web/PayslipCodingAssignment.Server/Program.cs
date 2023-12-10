using PayslipCodingAssignment.Application.DTOs;
using PayslipCodingAssignment.Application.Interfaces;
using PayslipCodingAssignment.Application.Services;
using PayslipCodingAssignment.Application.Validators;
using PayslipCodingAssignment.Domain.Calculators;
using PayslipCodingAssignment.Domain.Interfaces;
using PayslipCodingAssignment.Infrastructure.Services;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapPost("/generate-payslip", (EmployeeInputDto input, HttpContext context, PayslipService payslipService) =>
{
    try
    {
        var payslip = payslipService.GeneratePayslip(input);
        return Results.Ok(payslip);
    }
    catch (Exception ex) when (ex is ValidationException || ex is ArgumentException)
    {
        return Results.Problem(ex.Message);
    }
});

app.Run();

public partial class Program { }
