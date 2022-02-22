using AccessManagerApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccessManagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DbContextAccessManager _dbcontextAccessManager;
        public AccountController(DbContextAccessManager dbcontextAccessManager)
        {
            _dbcontextAccessManager = dbcontextAccessManager;
        }


    }
}
