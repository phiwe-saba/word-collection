using word_collection.Model;
using word_collection.Orchestration.Interface;
using word_collection.Repository.Interface;

namespace word_collection.Orchestration.Implementation
{
    public class WordCollectionOrchestration : IWordCollectionOrchestration
    {
        private readonly IWordCollectionRepository _wordCollectionRepository;
        private readonly ILogger<WordCollectionOrchestration> _logger;

        public WordCollectionOrchestration(IWordCollectionRepository wordCollectionRepository, ILogger<WordCollectionOrchestration> logger)
        {
            _wordCollectionRepository = wordCollectionRepository;
            _logger = logger;
        }

        public async Task<WordCollection> CreateWordAsync(WordCollection wordCollection)
        {
            try
            {
                return await _wordCollectionRepository.CreateWordAsync(wordCollection);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public Task<List<WordCollection>> GetAllWordsAsync()
        {
            try
            {
                return _wordCollectionRepository.GetAllWordsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve words inside GetAllWordsAsync");
                throw;
            }
        }
    }
}
