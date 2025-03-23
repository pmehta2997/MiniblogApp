using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniBlogApplication.Models.Entities;
using Newtonsoft.Json;
using System.Net.Http;

namespace MiniBlogApplication.View
{
    public class PostsModel(HttpClient httpClient) : PageModel
    {
        private HttpClient _httpClient = httpClient;
        public List<Post> Posts { get; private set; }

        public async Task OnGet()
        {
            var response = await _httpClient.GetAsync("api/GetAllPost");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Posts = JsonConvert.DeserializeObject<List<Post>>(content);
            }
        }
    }
}
