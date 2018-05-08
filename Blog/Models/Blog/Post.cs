using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog
{
    public class Post
    {
        [Required]
        public int ID { get; set; }
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MinLength(50, ErrorMessage = "Body must be minimum of 50 chars")]
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime Posted { get; set; }
    }
}
