using word_collection.Enums;

namespace word_collection.DTOs
{
    public class WordFilterRequest
    {
        public string? Word { get; set; }
        public WordType? WordType { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
