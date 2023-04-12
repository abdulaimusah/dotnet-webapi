using BlogApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BlogApi.Services;

public class PostsService
{
    private readonly IMongoCollection<Post> _postsCollection;

    public BooksService(
        IOptions<BlogDatabaseSettings> blogDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            blogDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            blogDatabaseSettings.Value.DatabaseName);

        _postsCollection = mongoDatabase.GetCollection<Post>(
            blogDatabaseSettings.Value.CollectionName);
    }

    public async Task<List<Post>> GetAsync() =>
        await _postsCollection.Find(_ => true).ToListAsync();

    public async Task<Post?> GetAsync(string id) =>
        await _postsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Post newPost) =>
        await _postsCollection.InsertOneAsync(newPost);

    public async Task UpdateAsync(string id, Post updatedPost) =>
        await _postsCollection.ReplaceOneAsync(x => x.Id == id, updatedPost);

    public async Task RemoveAsync(string id) =>
        await _postsCollection.DeleteOneAsync(x => x.Id == id);
}