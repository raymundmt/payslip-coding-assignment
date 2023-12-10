using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using PayslipCodingAssignment.Application.DTOs;

namespace PayslipCodingAssignment.Server.IntegrationTests;

[UsesVerify]
public class GeneratePaySlipIntegrationTests
{
    [Fact]
    public async Task GeneratePayslip_ReturnsCorrectData()
    {
        // Arrange
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var employeeDetails = new EmployeeInputDto
        {
            FirstName = "John",
            LastName = "Smith",
            AnnualSalary = 60050,
            SuperRate = 9M,
            PayPeriod = "March"
        };
        var content = new StringContent(JsonConvert.SerializeObject(employeeDetails), Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/generate-payslip", content);

        // Assert
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var payslip = JsonConvert.DeserializeObject<PaySlipDto>(responseString);

        await Verify(payslip);
    }

    [Fact]
    public async Task GeneratePayslip_ReturnsInternalServerError_ForInvalidInput()
    {
        // Arrange
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var invalidEmployeeDetails = new
        {
            FirstName = "", // Invalid input
            LastName = "Doe",
            AnnualSalary = -1, // Invalid input
            SuperRate = 60, // Invalid input
            PayPeriod = "InvalidMonth" // Invalid input
        };
        var content = new StringContent(JsonConvert.SerializeObject(invalidEmployeeDetails), Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/generate-payslip", content);

        // Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }
}
