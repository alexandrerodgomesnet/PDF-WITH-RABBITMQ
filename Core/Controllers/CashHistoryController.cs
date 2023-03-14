using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [ApiController]
    [Route("api/v1/cash-history")]
    public class CashHistoryController : ControllerBase
    {
        private readonly ICashHistoryService _service;
        public CashHistoryController(ICashHistoryService service)
        {
            _service = service;
        }

        [HttpGet("List")]
        public async Task<ActionResult<List<CashHistory>>> List()
        {
            var result = await _service.ListAsync();
            return Ok(result);
        }
    }
}