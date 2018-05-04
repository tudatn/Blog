using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog
{
    public class Comment
    {
        public int ID { get; set; }
        // relationship
        public int PostID { get; set; }
        public DateTime Posted { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }

        public Post Post { get; set; }
    }
}
