using System.Text.Json.Serialization;
using word_collection.Enums;

namespace word_collection.DTOs
{
    public class CreateWordRequest
    {
        public string Word { get; set; } = string.Empty;
        public WordType WordType { get; set; }
    }
}
