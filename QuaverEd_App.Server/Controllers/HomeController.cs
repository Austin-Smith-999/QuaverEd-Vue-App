//using Microsoft.AspNetCore.Mvc;
//using static QuaverEd.Data.Objects.Class1;

//namespace QuaverEd_App.Server.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//using global::QuaverEd.Data.Objects;
    //public class HomeController : ControllerBase
    //{
    //    //[HttpGet(Name = "WelcomeHome")]
    //    [HttpGet(Name = "Home")]
    //    public string Get()
    //    {
    //        return "Welcome Home test";
    //    }
    //}
    //public class Class1
    //{
    //    [HttpGet(Name = "GitHubRepos")]
    //    public Task CreateDatabaseAndTableAsync()
    //    {
    //        return CreateDatabaseAndTableAsync();
    //    }
    //}

    using Microsoft.AspNetCore.Mvc;
    using QuaverEd.Data.Objects; 
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace QuaverEd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller

        {
        [HttpGet(Name = "GitHubRepos")]
        private readonly Class1 _repositoryService;

            public HomeController()
            {
                // Initialize the Class1 service (GitHub + MySQL logic)
                _repositoryService = new Class1();
            }

            // Action to Fetch and Display GitHub Repositories
            public async Task<IActionResult> Index()
            {
                try
                {
                    // Call GitHub API to fetch repositories
                    List<Class1.Repository> repositories = await Class1.FetchGitHubRepositoriesAsync();

                    if (repositories != null)
                    {
                        // Insert or update repositories in the database
                        Class1.InsertOrUpdateRepositories(repositories);
                        ViewBag.Message = "Repositories fetched and stored successfully!";
                    }
                    else
                    {
                        ViewBag.Message = "No repositories were returned.";
                    }

                    // Pass repositories to the View for display
                    return View(repositories);
                }
                catch (System.Exception ex)
                {
                    ViewBag.Error = $"An error occurred: {ex.Message}";
                    return View(new List<Class1.Repository>()); // Return an empty list on error
                }
            }
        }
    }

//}


//using Microsoft.AspNetCore.Mvc;
//using QuaverEd.Data.Objects;
//using static QuaverEd.Data.Objects.Class1;

//namespace QuaverEd_App.Server.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class HomeController : ControllerBase
//    {
//        [HttpGet(Name = "WelcomeHome")]
//        public string Get()
//        {
//            return "Welcome Home";
//        }

//        [HttpGet("repositories")]
//        public IEnumerable<Repository> GetRepositories()
//        {
//            // Simulating data for now
//            return new List<Repository>
//            {
//                new Repository
//                {
//                    Id = 1,
//                    Name = "Sample Repo",
//                    Description = "This is a sample repository",
//                    OwnerUsername = "owner1",
//                    Stars = 42,
//                    CreatedDate = DateTime.Now.AddYears(-1),
//                    LastPushDate = DateTime.Now.AddDays(-1)
//                },
//                new Repository
//                {
//                    Id = 2,
//                    Name = "Another Repo",
//                    Description = "Another sample repository",
//                    OwnerUsername = "owner2",
//                    Stars = 50,
//                    CreatedDate = DateTime.Now.AddYears(-2),
//                    LastPushDate = DateTime.Now.AddDays(-10)
//                }
//            };
//        }
//    }
//}
