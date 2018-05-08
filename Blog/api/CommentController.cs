using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data;
using Blog.Models.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.api
{
    [Route("api/posts/{postID}/comments")]
    public class CommentController : Controller
    {
        private readonly BlogContext _context;
        public CommentController(BlogContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IQueryable<Comment> Get(int postID)
        {
            return _context.Comments.Where(x => x.Post.ID == postID);
        }

        [HttpPost]
        public Comment Post(int postID, [FromBody]Comment comment)
        {
            var post = _context.Posts.FirstOrDefault(x => x.ID == postID);
            if (post == null)
                return null;
            comment.Post = post;
            comment.Posted = DateTime.Now;
            comment.Author = User.Identity.Name;
            _context.Comments.Add(comment);
            _context.SaveChanges();

            return comment;
        }

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
