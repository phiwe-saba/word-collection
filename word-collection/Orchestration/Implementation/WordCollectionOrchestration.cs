using word_collection.DTOs;
using word_collection.Enums;
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

        public async Task<WordCollection> CreateWordAsync(CreateWordRequest wordRequest)
        {
            try
            {
                return await _wordCollectionRepository.CreateWordAsync(wordRequest);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Failed to create new word inside CreateWordAsync() method");
                throw;
            }
        }

        public async Task<bool> DeleteWordAsync(int id)
        {
            try
            {
                return await _wordCollectionRepository.DeleteWordAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete record insode DeleteWordAsync()");
                throw;
            }
        }

        public Task<IEnumerable<WordCollection>> GetAllWordsAsync()
        {
            try
            {
                return _wordCollectionRepository.GetAllWordsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve words inside GetAllWordsAsync() method");
                throw;
            }
        }

        public Task<WordCollection> GetWordByIdAsync(int id)
        {
            try
            {
                return _wordCollectionRepository.GetWordByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured inside GetWordByIdAsync() meethod");
                throw;
            }
        }

        public Task<WordCollection> GetWordByNameAsync(string word)
        {
            try
            {
                return _wordCollectionRepository.GetWordByNameAsync(word);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured inside GetWordByNameAsync() method");
                throw;
            }
        }

        public IEnumerable<string> GetWordTypes()
        {
            return Enum.GetNames(typeof(WordType));
        }

        public Task<PagedResponse<WordCollection>> SearchWordsAsync(WordFilterRequest request)
        {
            try
            {
                return _wordCollectionRepository.SearchWordsAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured inside SearchWordsAsync() method");
                throw;
            }
        }

        public async Task<WordCollection?> UpdateWordCollectionAsync(int id, WordCollection wordCollection)
        {
            try
            {
                return await _wordCollectionRepository.UpdateWordCollectionAsync(id, wordCollection);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured inside UpdateWordCollectionAsync() method");
                throw;
            }
        }
    }
}
