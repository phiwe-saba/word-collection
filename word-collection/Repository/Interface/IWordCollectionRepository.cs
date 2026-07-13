using System.Collections.Generic;
using word_collection.DTOs;
using word_collection.Model;

namespace word_collection.Repository.Interface
{
    public interface IWordCollectionRepository
    {
        Task<IEnumerable<WordCollection>> GetAllWordsAsync();
        Task<WordCollection?> GetWordByIdAsync(int id);
        Task<WordCollection?> GetWordByNameAsync(string word);
        Task<WordCollection> CreateWordAsync(CreateWordRequest wordRequest);
        Task<WordCollection?> UpdateWordCollectionAsync(int id, WordCollection wordCollection);
        Task<bool> DeleteWordAsync(int id);
    }
}
