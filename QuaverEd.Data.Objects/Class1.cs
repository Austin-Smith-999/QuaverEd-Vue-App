// namespace QuaverEd.Data.Objects
// {
//     public class Class1
//     {

//     }
// }

namespace QuaverEd.Data.Objects
{
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

    public class Class1
    {
        private const string GitHubApiUrl = "https://api.github.com/search/repositories";
        private const string MySqlConnectionString = "Server=localhost;User ID=root;Password=password;Database=github_repos;";

        // main
        static async Task Main(string[] args)
    {
        await CreateDatabaseAndTableAsync();
        var repositories = await FetchGitHubRepositoriesAsync();
        if (repositories != null)
        {
            InsertOrUpdateRepositories(repositories);
        }
    }

    private static async Task CreateDatabaseAndTableAsync()
    {
        try
        {
            using var connection = new MySqlConnection("Server=localhost;User ID=root;Password=password;");
            await connection.OpenAsync();

            using var createDbCommand = new MySqlCommand("CREATE DATABASE IF NOT EXISTS github_repos;", connection);
            await createDbCommand.ExecuteNonQueryAsync();

            connection.ChangeDatabase("github_repos");

            string createTableSql = @"CREATE TABLE IF NOT EXISTS repositories (
                id BIGINT PRIMARY KEY,
                name VARCHAR(255) NOT NULL,
                owner_username VARCHAR(255) NOT NULL,
                url VARCHAR(255) NOT NULL,
                created_date DATETIME NOT NULL,
                last_push_date DATETIME NOT NULL,
                description TEXT,
                stars INT NOT NULL
            );";

            using var createTableCommand = new MySqlCommand(createTableSql, connection);
            await createTableCommand.ExecuteNonQueryAsync();

            Console.WriteLine("Database and table are ready.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }



    // private static async Task<List<Repository>> FetchGitHubRepositoriesAsync()
    // {
    //     try
    //     {
    //         using var httpClient = new HttpClient();
    //         httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
    //         httpClient.DefaultRequestHeaders.Add("User-Agent", "CSharpApp");

    //         var response = await httpClient.GetAsync($"{GitHubApiUrl}?q=language:c#&sort=stars&order=desc&per_page=100");
    //         response.EnsureSuccessStatusCode();

    //         var responseBody = await response.Content.ReadAsStringAsync();
    //         var jsonDoc = JsonDocument.Parse(responseBody);

    //         var items = jsonDoc.RootElement.GetProperty("items");
    //         var repositories = new List<Repository>();

    //         foreach (var item in items.EnumerateArray())
    //         {
    //             repositories.Add(new Repository
    //             {
    //                 Id = item.GetProperty("id").GetInt64(),
    //                 Name = item.GetProperty("name").GetString(),
    //                 OwnerUsername = item.GetProperty("owner").GetProperty("login").GetString(),
    //                 Url = item.GetProperty("html_url").GetString(),
    //                 CreatedDate = DateTime.Parse(item.GetProperty("created_at").GetString()),
    //                 LastPushDate = DateTime.Parse(item.GetProperty("pushed_at").GetString()),
    //                 Description = item.GetProperty("description").GetString(),
    //                 Stars = item.GetProperty("stargazers_url").GetInt32()
    //             });
    //         }

    //         return repositories;
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine($"Error fetching GitHub repositories: {ex.Message}");
    //         return null;
    //     }
    // }


private static async Task<List<Repository>> FetchGitHubRepositoriesAsync()
{
    try
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
        httpClient.DefaultRequestHeaders.Add("User-Agent", "CSharpApp");

        // Add GitHub Personal Access Token
        const string githubToken = "your_personal_access_token_here";
        httpClient.DefaultRequestHeaders.Add("Authorization", $"token {githubToken}");

        var response = await httpClient.GetAsync($"{GitHubApiUrl}?q=language:c#&sort=stars&order=desc&per_page=100");
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var jsonDoc = JsonDocument.Parse(responseBody);

        var items = jsonDoc.RootElement.GetProperty("items");
        var repositories = new List<Repository>();

        foreach (var item in items.EnumerateArray())
        {
            repositories.Add(new Repository
            {
                Id = item.GetProperty("id").GetInt64(),
                Name = item.GetProperty("name").GetString(),
                OwnerUsername = item.GetProperty("owner").GetProperty("login").GetString(),
                Url = item.GetProperty("html_url").GetString(),
                CreatedDate = DateTime.Parse(item.GetProperty("created_at").GetString()),
                LastPushDate = DateTime.Parse(item.GetProperty("pushed_at").GetString()),
                Description = item.GetProperty("description").GetString(),
                Stars = item.GetProperty("stargazers_count").GetInt32()
            });
        }

        return repositories;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error fetching GitHub repositories: {ex.Message}");
        return null;
    }
}




    private static void InsertOrUpdateRepositories(List<Repository> repositories)
    {
        try
        {
            using var connection = new MySqlConnection(MySqlConnectionString);
            connection.Open();

            // probably should match above
            string insertUpdateSql = @"INSERT INTO repositories (id, name, owner_username, url, created_date, last_push_date, description, stars)
                                        VALUES (@id, @name, @owner_username, @url, @created_date, @last_push_date, @description, @stars)
                                        ON DUPLICATE KEY UPDATE
                                            name = VALUES(name),
                                            owner_username = VALUES(owner_username),
                                            url = VALUES(url),
                                            created_date = VALUES(created_date),
                                            last_push_date = VALUES(last_push_date),
                                            description = VALUES(description),
                                            stars = VALUES(stars);";

            using var command = new MySqlCommand(insertUpdateSql, connection);

            foreach (var repo in repositories)
            {
                command.Parameters.Clear();

                command.Parameters.AddWithValue("@id", repo.Id);
                command.Parameters.AddWithValue("@name", repo.Name);
                command.Parameters.AddWithValue("@owner_username", repo.OwnerUsername);
                command.Parameters.AddWithValue("@url", repo.Url);
                command.Parameters.AddWithValue("@created_date", repo.CreatedDate);
                command.Parameters.AddWithValue("@last_push_date", repo.LastPushDate);
                command.Parameters.AddWithValue("@description", repo.Description);
                command.Parameters.AddWithValue("@stars", repo.Stars);

                command.ExecuteNonQuery();
            }

            Console.WriteLine("Repositories inserted/updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Database error: {ex.Message}");
        }
    }


    private class Repository
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string OwnerUsername { get; set; }
        public string Url { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastPushDate { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }
    }










    }

    
}
