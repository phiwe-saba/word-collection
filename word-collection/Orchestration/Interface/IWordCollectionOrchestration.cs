using word_collection.DTOs;
using word_collection.Model;

namespace word_collection.Orchestration.Interface
{
    public interface IWordCollectionOrchestration
    {
        Task<WordCollection> CreateWordAsync(CreateWordRequest wordRequest);
        Task<IEnumerable<WordCollection>> GetAllWordsAsync();
        Task<WordCollection> GetWordByIdAsync(int id);
        Task<WordCollection> GetWordByNameAsync(string word);
        Task<WordCollection?> UpdateWordCollectionAsync(int id, WordCollection wordCollection);
        Task<bool> DeleteWordAsync(int id);
        IEnumerable<string> GetWordTypes();
        Task<PagedResponse<WordCollection>> SearchWordsAsync(WordFilterRequest request);
    }
}
