using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DbController : ControllerBase
    {
        private readonly ILogger<DbController> _logger;
        private readonly IConfiguration _configuration;

        public DbController(ILogger<DbController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public Dictionary<int, string?> GetDb()
        {

            var connectionString = _configuration.GetConnectionString("MyDb");
            _logger.LogInformation($"ConnectionString: {connectionString}");

            using var connection = new SqlConnection(connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM MyTable";

            using var reader = command.ExecuteReader();

            var data = new Dictionary<int, string?>();
            while (reader.Read())
                data[reader.GetInt32(0)] = reader.GetString(1);
            return data;
        }
    }
}