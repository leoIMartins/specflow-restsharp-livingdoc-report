public class Post
{
      // Atributos
    public string Id { get; set; }
    public string UserId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public Post(string id, string userId, string title, string body)
    {
        Id = id;
        UserId = userId;
        Title = title;
        Body = body;
    }
}