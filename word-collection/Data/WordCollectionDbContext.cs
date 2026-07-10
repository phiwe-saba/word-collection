using Microsoft.EntityFrameworkCore;
using word_collection.Model;

namespace word_collection.Data
{
    public class WordCollectionDbContext : DbContext
    {
        public WordCollectionDbContext(DbContextOptions<WordCollectionDbContext> options) : base(options) { }

        public DbSet<WordCollection> WordCollections { get; set; }
    }
}
