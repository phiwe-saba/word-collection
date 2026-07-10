using word_collection.Model;

namespace word_collection.Orchestration.Interface
{
    public interface IWordCollectionOrchestration
    {
        Task<WordCollection> CreateWordAsync(WordCollection wordCollection);
        Task<List<WordCollection>> GetAllWordsAsync();
    }
}
