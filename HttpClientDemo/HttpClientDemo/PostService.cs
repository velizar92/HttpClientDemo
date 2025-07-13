using System.Net.Http.Json;

namespace HttpClientDemo
{
    public class PostService
    {
        private readonly HttpClient _httpClient;

        private const string BaseUrl = "https://jsonplaceholder.typicode.com/posts";

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<Post>>();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Post>();
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, post);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Post>();
        }

        public async Task<Post> UpdatePostAsync(int id, Post post)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", post);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Post>();
        }

        public async Task DeletePostAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
