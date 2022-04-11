using AccessManagerApp.Data;
using AccessManagerApp.DTOs;
using AccessManagerApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AccessManagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpGet("[action]/{guid}")]
        public async Task<ActionResult> Get([FromRoute] string guid)
        {
            if (string.IsNullOrEmpty(guid))            
                return NotFound();
            
            var account = await _accountService.GetAccount(guid);
            if (account == null)            
                return NotFound();            
         
            return Ok(account);
        }

        [HttpGet("[action]/{guid}")]
        public async Task<ActionResult> GetDetailAccount([FromRoute] string guid)
        {
            if (string.IsNullOrEmpty(guid))
                return NotFound();

            var details = await _accountService.GetDetailAccount(guid);
            if (details == null || details.Count < 0)
                return NotFound();

            return Ok(details);
        }


        [HttpPost("[action]")]
        public async Task<ActionResult> Post([FromBody] AccountPOSTDTO model)
        {
            if (!ModelState.IsValid)            
                return BadRequest(ModelState);            

            bool result = await _accountService.SaveAccount(model);
            if (!result)           
                return BadRequest();            
                           
            //return CreatedAtAction("List", model);
            return Ok();
        }

    }
}
