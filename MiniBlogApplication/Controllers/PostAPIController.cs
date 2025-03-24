using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniBlogApplication.Data;
using MiniBlogApplication.Models;
using MiniBlogApplication.Models.Entities;

namespace MiniBlogApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostAPIController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public PostAPIController(ApplicationDbContext dbContext) { 
        this.dbContext = dbContext;
        }
        [HttpGet]
        [Route("api/Post/GetAllPost")]
        public IActionResult GetAllPost()
        {
            var AllPosts=dbContext.Posts.ToList();
            return Ok(AllPosts);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetPostById(int id)
        {
            var post=dbContext.Posts.Find(id);
            if(post is null)
            {
                return NotFound();
            }
            return Ok(post);    


        }
        [HttpPost]
        public IActionResult AddPost(Post post)
        {
            dbContext.Posts.Add(post);
            dbContext.SaveChanges();

            return Ok(post);
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdatePost(int id, Post post)
        {
            var GetPost = dbContext.Posts.Find(id);
            if (GetPost is null)
            {
                return NotFound();
            }
            //GetPost.Id = post.Id;
            GetPost.Title = post.Title;
            GetPost.Body = post.Body;
            dbContext.SaveChanges();
            return Ok(GetPost);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult actionResult(int id)
        {
            var GetPost = dbContext.Posts.Find(id);
            if (GetPost is null)
            {
                return NotFound();
            }
            dbContext.Posts.Remove(GetPost);
            dbContext.SaveChanges();
            return Ok(GetPost);
        }


    }
}
