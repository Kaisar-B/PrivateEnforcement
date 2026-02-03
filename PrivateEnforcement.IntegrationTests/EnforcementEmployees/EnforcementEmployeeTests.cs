using Application.Employees.Commands.CreateEmployee.DTOs;
using Newtonsoft.Json;
using PrivateEnforcement.IntegrationTests.API.TestSetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PrivateEnforcement.IntegrationTests.API.EnforcementEmployees
{
    public class EnforcementEmployeeTests : BaseIntegrationTest
    {
        private readonly HttpClient _client;
        public EnforcementEmployeeTests(TestWebAppFactory factory): base(factory) 
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Create_ShouldAdd_NewEnforcementEmployee()
        {
            // Arrange
            var employees = new List<CreateEnforcementEmployeeRequestDto>
            {
                new CreateEnforcementEmployeeRequestDto
                {
                    PassportNumber = "P12345678",
                    Name = "John",
                    Surname = "Doe",
                    Login = "jdoe",
                    Password = "Pass@123",
                    Position = "Inspector",
                    EnforcementEmployerId = 1001
                },
                new CreateEnforcementEmployeeRequestDto
                {
                    PassportNumber = "P87654321",
                    Name = "Anna",
                    Surname = "Smith",
                    Login = "asmith",
                    Password = "Secure#456",
                    Position = "Senior Officer",
                    EnforcementEmployerId = 1001
                },
                new CreateEnforcementEmployeeRequestDto
                {
                    PassportNumber = "P11223344",
                    Name = "Michael",
                    Surname = "Brown",
                    Login = "mbrown",
                    Password = "StrongPwd!789",
                    Position = "Administrator",
                    EnforcementEmployerId = 1002
                }
            };

            var payload = JsonConvert.SerializeObject(employees);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("api/enforcement-employees/create", content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }

        [Fact]
        public async Task Delete_ShouldDelete_OldEnforcementFromDb()
        {
            // Arrange
            var dto = new List<long> { 1, 2, 3 };

            // Act
            var response = await _client.DeleteAsync($"api/enforcement-employees/delete?ids={dto[0]}&ids={dto[1]}&ids={dto[2]}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
