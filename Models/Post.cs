using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace BlogApi.Models;

public class Post
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Title")]
    [JsonPropertyName("Name")]
    public string PostTitle { get; set; } = null!;

    //public decimal Price { get; set; }

    public string Content { get; set; } = null!;

    public string Author { get; set; } = null!;

    public DateTime PostTime { get; set; } = null!;
}