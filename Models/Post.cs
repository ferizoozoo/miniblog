using System;
using System.ComponentModel.DataAnnotations;

namespace MiniBlog.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Author { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [MinLength(10)]
        public string Title { get; set; }

        [MinLength(10)]
        public string Content { get; set; }

        
        public int Likes { get; set; } = 0;

        [Display(Name = "Dislikes")]
        public int DisLikes { get; set; } = 0;
    }
}