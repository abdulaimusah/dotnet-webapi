using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace BlogApi.Models;

public class Post
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? _id { get; set; }

    public string title {get; set; } = null!;

    //[BsonElement("Title")]
    //[JsonPropertyName("Name")]
    public string author { get; set; } = null!;

    //public decimal Price { get; set; }

    public string content { get; set; } = null!;

    public string category { get; set; } = null!;

    public DateTime? createdAt { get; set; } 

    public DateTime? modified { get; set; } 

}