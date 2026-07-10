using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<ActionResult<WordCollection>> CreatWordAsync(WordCollection wordCollection)
        {
            try
            {
                var results = await _wordCollectionOrchestration.CreateWordAsync(wordCollection);
                return Ok(results);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error occured creating a new word.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured.");
            }
        }

        [HttpGet]
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
    }
}
