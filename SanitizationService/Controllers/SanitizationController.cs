using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SanitizationService.SanitizationService.Core.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SanitizationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanitizationController : ControllerBase
    {
        private readonly ISanitizationService _sanitizationService;
        private readonly ILogger<SanitizationController> _logger;

        public SanitizationController(ISanitizationService sanitizationService, ILogger<SanitizationController> logger)
        {
            _sanitizationService = sanitizationService;
            _logger = logger;
        }

        // POST api/<SanitizationController>
        [HttpPost]
        public async Task<ActionResult<SanitizationResponse>> Post([FromBody] SanitizationRequest sanitizationRequest)
        {
            try
            {
                await _sanitizationService.SanitizeFile(sanitizationRequest.Path);
                return Ok(new SanitizationResponse(){SanitizedFilePath = sanitizationRequest.Path});
            }
            catch (Exception e)
            {
                _logger.LogError($"failed to sanitize file {sanitizationRequest.Path}.");
                _logger.LogError($"Sanitizer throw exception: {e.Message}.");
                return StatusCode(500, $"Internal Server Error");
            }
        }
    }
}
