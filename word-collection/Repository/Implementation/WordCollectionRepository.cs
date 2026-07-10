using Microsoft.EntityFrameworkCore;
using word_collection.Data;
using word_collection.Model;
using word_collection.Repository.Interface;

namespace word_collection.Repository.Implementation
{
    public class WordCollectionRepository : IWordCollectionRepository
    {
        private readonly WordCollectionDbContext _wordCollectionDbContext;
        private readonly ILogger<WordCollectionRepository> _logger;

        public WordCollectionRepository(WordCollectionDbContext wordCollectionDbContext, ILogger<WordCollectionRepository> logger)
        {
            _wordCollectionDbContext = wordCollectionDbContext;
            _logger = logger;
        }

        public async Task<WordCollection> CreateWordAsync(WordCollection wordCollection)
        {
            try
            {
                var entity = new WordCollection();
                entity.Word = wordCollection.Word;
                entity.WordType = wordCollection.WordType;

                _wordCollectionDbContext.WordCollections.Add(entity);
                await _wordCollectionDbContext.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Failed to create new word");
                throw;
            }
        }

        public async Task<List<WordCollection>> GetAllWordsAsync()
        {
            try
            {
                return await _wordCollectionDbContext.WordCollections.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve all the words");
                throw;
            }
        }

        public async Task<WordCollection> GetWordByIdAsync(int id)
        {
            try
            {
                return await _wordCollectionDbContext.WordCollections.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to find word with id: {id}");
                throw;
            }
        }

        public async Task<WordCollection> GetWordByName(string word)
        {
            try
            {
                return await _wordCollectionDbContext.WordCollections.FindAsync(word);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
