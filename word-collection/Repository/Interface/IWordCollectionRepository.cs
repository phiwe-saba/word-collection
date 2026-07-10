using System.Collections.Generic;
using word_collection.Model;

namespace word_collection.Repository.Interface
{
    public interface IWordCollectionRepository
    {
        Task<List<WordCollection>> GetAllWordsAsync();
        Task<WordCollection> GetWordByIdAsync(int id);
        Task<WordCollection> GetWordByName(string word);
        Task<WordCollection> CreateWordAsync(WordCollection wordCollection);

    }
}
