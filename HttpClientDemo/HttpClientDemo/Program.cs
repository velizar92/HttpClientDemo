namespace HttpClientDemo
{
    public class Program
    {
        
        public static async Task Main(string[] args)
        {
            using var httpClient = new HttpClient();
            var postService = new PostService(httpClient);
            var postController = new PostController(postService);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Post Service Menu:");
                Console.WriteLine("1. Get All Posts");
                Console.WriteLine("2. Get Post By ID");
                Console.WriteLine("3. Create Post");
                Console.WriteLine("4. Update Post");
                Console.WriteLine("5. Delete Post");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        await postController.GetAllPosts();
                        break;
                    case "2":
                        await postController.GetPostById();
                        break;
                    case "3":
                        await postController.CreatePost();
                        break;
                    case "4":
                        await postController.UpdatePost();
                        break;
                    case "5":
                        await postController.DeletePost();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }    
    }
}

