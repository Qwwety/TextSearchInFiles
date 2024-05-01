using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TextSearchInFiles.DTOs;
using TextSearchInFiles.Services;

namespace TextSearchInFiles.Controllers
{
    [Route("api/[controller]")]
    public class NameSearchController : Controller
    {

        private INameSearchService nameSearchService;

        public NameSearchController(INameSearchService nameSearchService_)
        {
            nameSearchService= nameSearchService_;
        }

        [HttpGet]
        [Route("GetFileNameByKeyWord/{KeyName}")]
        public async Task<ActionResult<TotalResultDTO>> GetFileNameByKeyWord(string KeyName)
        {
            if (!String.IsNullOrEmpty(KeyName))
            {
                var result= await nameSearchService.GetFilesWithKeyWord(KeyName);
                return Ok(JsonSerializer.Serialize(result));
            }
            else
                return BadRequest("KeyName is null.");
        }
    }
}
