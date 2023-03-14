using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.Services.DTOs;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [ApiController]
    [Route("api/v1/cash-history")]
    public class CashHistoryController : ControllerBase
    {
        private readonly ICashHistoryService _service;
        private readonly IMessageSender _sender;
        public CashHistoryController(ICashHistoryService service, IMessageSender sender)
        {
            _service = service;
            _sender = sender;            
        }

        [HttpGet("List")]
        public async Task<ActionResult<List<CashHistory>>> List()
        {
            var result = await _service.ListAsync();
            return Ok(result);
        }

        [HttpPost("Generate-Report")]
        public void GenerateReport(int lines)
        {
            var data = new MessageSenderDataDto(lines);
            _sender.Publish(data);
        }
    }
}