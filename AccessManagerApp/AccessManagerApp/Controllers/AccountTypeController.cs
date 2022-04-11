using AccessManagerApp.Data;
using AccessManagerApp.DTOs;
using AccessManagerApp.Helpers;
using AccessManagerApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        [HttpGet("[action]")]
        public async Task<IEnumerable<AccountTypeDTO>> List() 
        {
            var list = await _accTypeService.ListTypes();        
            return list;
        }

        [HttpGet("[action]/{code}")]
        public async Task<ActionResult> Get([FromRoute] string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return BadRequest("mande un codigo valido");
            }

            var typeAcc = await _accTypeService.GetTypeAccount(code);

            if (typeAcc == null)
            {
                return NotFound();
            }

            return Ok(typeAcc);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Post([FromBody] AccountTypeDTO model) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _accTypeService.SaveTypeAccount(model);
            }
            catch (DbUpdateException ex)
            {
                if (_accTypeService.AccountTypeExist(model.Code))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
               
            }
            //return new CreatedAtRouteResult();
            return CreatedAtAction("List", model);
        }


     
    }
}
