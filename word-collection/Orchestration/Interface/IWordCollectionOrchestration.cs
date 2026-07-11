using word_collection.Model;

namespace word_collection.Orchestration.Interface
{
    public interface IWordCollectionOrchestration
    {
        Task<WordCollection> CreateWordAsync(WordCollection wordCollection);
        Task<List<WordCollection>> GetAllWordsAsync();
        Task<WordCollection> GetWordByIdAsync(int id);
        Task<WordCollection> GetWordByNameAsync(string word);
        Task<WordCollection?> UpdateWordCollectionAsync(int id, WordCollection wordCollection);
        Task<bool> DeleteWordAsync(int id);
    }
}
