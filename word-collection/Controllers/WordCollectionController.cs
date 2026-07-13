using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using word_collection.DTOs;
using word_collection.Model;
using word_collection.Orchestration.Implementation;
using word_collection.Orchestration.Interface;

namespace word_collection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordCollectionController : ControllerBase
    {
        private readonly IWordCollectionOrchestration _wordCollectionOrchestration;
        private readonly ILogger<WordCollectionController> _logger;

        public WordCollectionController(IWordCollectionOrchestration wordCollectionOrchestration, ILogger<WordCollectionController> logger)
        {
            _wordCollectionOrchestration = wordCollectionOrchestration;
            _logger = logger;
        }

        [HttpGet("getWordById/{id}", Name = "GetWordById")]
        public async Task<ActionResult<WordCollection>> GetWordByIdAsync(int id)
        {
            try
            {
                var result = await _wordCollectionOrchestration.GetWordByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured whilst retrieving data");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.");
            }
        }

        [HttpPost("createWord")]
        public async Task<ActionResult<WordCollection>> CreatWordAsync([FromBody] CreateWordRequest wordRequest)
        {
            try
            {
                var results = await _wordCollectionOrchestration.CreateWordAsync(wordRequest);
                return Ok(results);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error occured creating a new word.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.");
            }
        }

        [HttpGet("getAllWords")]
        public async Task<ActionResult<List<WordCollection>>> GetAllWordsAsync()
        {
            try
            {
                var results = await _wordCollectionOrchestration.GetAllWordsAsync();
                return Ok(results);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error occured whilst retrieving all the words.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.");
            }
        }

        [HttpGet("getWordByName/{name}")]
        public async Task<ActionResult> GetWordByNameAsync(string name)
        {
            try
            {
                var results = await _wordCollectionOrchestration.GetWordByNameAsync(name);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured whilst retrieving data");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.");
            }
        }

        [HttpPut("updateWordById/{id}")]
        public async Task<ActionResult> UpdateWordCollectionAsync(int id, WordCollection wordCollection)
        {
            try
            {
                var results = await _wordCollectionOrchestration.UpdateWordCollectionAsync(id, wordCollection);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured whilst updating record");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured");
            }
        }

        [HttpDelete("deleteWordById/{id}")]
        public async Task<IActionResult> DeleteWordAsync(int id)
        {
            try
            {
                var results = await _wordCollectionOrchestration.DeleteWordAsync(id);

                if (!results)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured whilst deleting record");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured");
            }
        }

        [HttpGet("getWordTypes")]
        public ActionResult<IEnumerable<string>> GetWordTypes()
        {
            try
            {
                var result = _wordCollectionOrchestration.GetWordTypes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve word types.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.");
            }
        }
    }
}
