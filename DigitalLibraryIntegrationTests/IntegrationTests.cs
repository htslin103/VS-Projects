using Microsoft.AspNetCore.Mvc.Testing;

namespace DigitalLibraryIntegrationTests
{
    public class IntegrationTests
    {
        public HttpClient _client;
        public IntegrationTests()
        {

        }

        [Fact]
        public async Task Description_NoCondition_Success()
        {
            //Setup 
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();

            //Called /Welcome/Description route
            var response = await httpClient.GetAsync("/Welcome/Description");
            //Ensure we get success msg
            response.EnsureSuccessStatusCode();
            
            //Read the content and assert that it's what we expect
            var stringResult = await response.Content.ReadAsStringAsync();
            Assert.Equal("This is the application for managing digital books", stringResult);
        }
    }
}