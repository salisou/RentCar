using System.Text.Json.Serialization;

namespace RentCar.Domain.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string AuthorName { get; set; } = string.Empty;
        public string BlogCoverImageUrl { get; set; } = string.Empty; // ✅ Aggiunto per evitare cicli di serializzazione

        public int BlogId { get; set; }

        // Navigation property - evita loop durante la serializzazione JSON
        [JsonIgnore] // ✅ Previene cicli quando restituisci dati via API
        public Blog Blog { get; set; } = new();

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string Content { get; set; } = string.Empty;
    }

}
