using Azure;
using BookManager.Application.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;

namespace BookManager.FunctionalTests;

public class UnitTest1
{
    [Fact]
    public async Task G_New_Author_W_Created_in_DB_T_Return_The_Created_Author()
    {
        var httpClient = new HttpClient();

        Author author = new Author
        {
            Name = "Andreas",
            LastName = "Spies",
            Birth = DateTime.Now,
            CountryCode = "DE"
        };

        var content = JsonConvert.SerializeObject(author);
        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var httpResponse = await httpClient.PostAsync("api/authors", byteContent);

        string responseText = await httpResponse.Content.ReadAsStringAsync();

        author.Should().Be(responseText);
    }
}