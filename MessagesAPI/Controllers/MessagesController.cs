using MessagesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MessagesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {

        private readonly ILogger<MessagesController> _logger;
        private readonly IMessagesService _service;

        public MessagesController(ILogger<MessagesController> logger, IMessagesService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var messages = await _service.GetMessages();
                if (messages == null) return NotFound();
                return Ok(messages);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting messages");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Message message)
        {
            if (message == null) return BadRequest();
            try
            {
                var insertedMessage = await _service.InsertMessage(message);
                return Ok(insertedMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inserting message");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}