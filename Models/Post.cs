using System;

namespace MiniBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }
    }
}