using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using word_collection.Data;
using word_collection.DTOs;
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

        public async Task<WordCollection> CreateWordAsync(CreateWordRequest wordRequest)
        {
            try
            {
                var entity = new WordCollection();
                entity.Word = wordRequest.Word;
                entity.WordType = wordRequest.WordType;

                _wordCollectionDbContext.WordCollections.Add(entity);
                await _wordCollectionDbContext.SaveChangesAsync();

                _logger.LogInformation($"Successfully created a new record: {entity}");
                return entity;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Failed to create new record");
                throw;
            }
        }

        public async Task<bool> DeleteWordAsync(int id)
        {
            try
            {
                var value = await _wordCollectionDbContext.WordCollections.FindAsync(id);

                if (value == null) 
                {
                    _logger.LogInformation($"Word with id: {id} was not found");
                    return false;
                }

                _wordCollectionDbContext.WordCollections.Remove(value);
                await _wordCollectionDbContext.SaveChangesAsync();

                _logger.LogInformation($"Successfully deleted word with id: {id}");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to delete word with id: {id}.");
                throw;
            }
        }

        public async Task<IEnumerable<WordCollection>> GetAllWordsAsync()
        {
            try
            {
                var result = await _wordCollectionDbContext.WordCollections.ToListAsync();

                _logger.LogInformation($"Retrieved words {result}");

                if (result is null)
                {
                    _logger.LogInformation("No words exist in the database");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve all the words");
                throw;
            }
        }

        public async Task<WordCollection?> GetWordByIdAsync(int id)
        {
            try
            {
                var result = await _wordCollectionDbContext.WordCollections.FindAsync(id);

                _logger.LogInformation($"Retrieved word with id: {result}");

                if (result is null)
                {
                    _logger.LogInformation("Results value is null");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to find word with id: {id}");
                throw;
            }
        }

        public async Task<WordCollection?> GetWordByNameAsync(string word)
        {
            try
            {
                var result = await _wordCollectionDbContext.WordCollections.FirstOrDefaultAsync(x => x.Word == word);

                _logger.LogInformation($"Retrieved word: {result}");

                if (result is null)
                {
                    _logger.LogInformation($"No word found with name: {word}");
                }

                return result; 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to find word with name: {word}");
                throw;
            }
        }

        public async Task<PagedResponse<WordCollection>> SearchWordsAsync(WordFilterRequest request)
        {
            IQueryable<WordCollection> query = _wordCollectionDbContext.WordCollections;

            if (!string.IsNullOrWhiteSpace(request.Word))
            {
                query = query.Where(x =>
                    x.Word.Contains(request.Word));
            }

            if (request.WordType.HasValue)
            {
                query = query.Where(x =>
                    x.WordType == request.WordType.Value);
            }

            int totalRecords = await query.CountAsync();

            List<WordCollection> data = await query
                .OrderBy(x => x.Word)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return new PagedResponse<WordCollection>
            {
                Data = data,
                TotalRecords = totalRecords,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }

        public async Task<WordCollection?> UpdateWordCollectionAsync(int id, WordCollection wordCollection)
        {
            try
            {
                var entity = await _wordCollectionDbContext.WordCollections.FindAsync(id);

                if (entity == null)
                {
                    _logger.LogInformation($"Record with id {id} not found");
                    return null;
                }

                entity.Word = wordCollection.Word;
                entity.WordType = wordCollection.WordType;

                await _wordCollectionDbContext.SaveChangesAsync();

                _logger.LogInformation($"Updated record with id {id} successfully");

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to update record with id: {id}");
                throw;
            }
        }
    }
}
