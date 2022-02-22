using AccessManagerApp.Data;
using AccessManagerApp.DTOs;
using AccessManagerApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AccessManagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly AccountTypeService _accTypeService;

        public AccountTypeController(AccountTypeService accTypeService)
        {
            _accTypeService = accTypeService;
        }
  
    }
}
