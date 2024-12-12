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










    }



    
}
