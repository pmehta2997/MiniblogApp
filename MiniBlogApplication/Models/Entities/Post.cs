using System;
using System.ComponentModel.DataAnnotations;
namespace MiniBlogApplication.Models.Entities
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
