using MailingList.Models;
using MailingList.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailingList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MailingListController : ControllerBase
    {
        private readonly IMailingListService _mailingListService;
        public MailingListController(IMailingListService mailingListService)
        {
            _mailingListService = mailingListService;
        }

        [HttpGet]
        [Route("v1/{lastName?}/{ascdesc?}")]
        public async Task<IActionResult> GetMailingList(string lastName, string ascdesc)
        {
            try
            {
                var result = await _mailingListService.GetMailingListsAsync(lastName, ascdesc);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("v2/{lastName?}/{ascdesc?}")]
        public IActionResult GetMailingListPersistentStorage([FromRoute] string lastName, [FromRoute] string ascdesc)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("v1")]
        public IActionResult AddMailingList([FromBody] MailingListRecord request)
        {
            try
            {
                var result = _mailingListService.AddMailingList(request);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("v2")]
        public IActionResult AddMailingListPersistentStorage([FromBody] MailingListRecord request)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
