namespace HttpClientDemo
{
    public class PostController
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public async Task GetAllPosts()
        {
            var posts = await _postService.GetPostsAsync();
            if (posts != null && posts.Any())
            {
                foreach (var post in posts)
                {
                    Console.WriteLine($"ID: {post.Id}\n Title: {post.Title}\n Body: {post.Body}");
                }
            }
            else
            {
                Console.WriteLine("No posts found.");
            }
        }

        public async Task GetPostById()
        {
            Console.Write("Enter Post ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var post = await _postService.GetPostByIdAsync(id);
                if (post != null)
                {
                    Console.WriteLine($"ID: {post.Id}\n Title: {post.Title}\n Body: {post.Body}");
                }
                else
                {
                    Console.WriteLine("Post not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
        }

        public async Task CreatePost()
        {
            Console.Write("Enter Post Title: ");
            var title = Console.ReadLine();
            Console.Write("Enter Post Body: ");
            var body = Console.ReadLine();
            var newPost = new Post
            {
                Title = title,
                Body = body
            };
            var createdPost = await _postService.CreatePostAsync(newPost);
            if (createdPost != null)
            {
                Console.WriteLine($"Created Post ID: {createdPost.Id}\n Title: {createdPost.Title}\n Body: {createdPost.Body}");
            }
            else
            {
                Console.WriteLine("Failed to create post.");
            }
        }

        public async Task UpdatePost()
        {
            Console.Write("Enter Post ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Enter new Post Title: ");
                var title = Console.ReadLine();
                Console.Write("Enter new Post Body: ");
                var body = Console.ReadLine();
                var updatedPost = new Post
                {
                    Id = id,
                    Title = title,
                    Body = body
                };
                var result = await _postService.UpdatePostAsync(id, updatedPost);
                if (result != null)
                {
                    Console.WriteLine($"Updated Post ID: {result.Id}\n Title: {result.Title}\n Body: {result.Body}");
                }
                else
                {
                    Console.WriteLine("Failed to update post.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
        }

        public async Task DeletePost()
        {
            Console.Write("Enter Post ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                await _postService.DeletePostAsync(id);
                Console.WriteLine($"Post with ID {id} deleted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
        }
    }
}
