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












    }



    
}
