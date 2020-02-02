using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniBlog.Context;
using MiniBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LikeController : ControllerBase
    {
        private readonly MiniBlogContext _context;
        
        public LikeController(MiniBlogContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Post([FromQuery] int itemid)
        {
            var post = _context.Posts.Find(itemid);
            post.Likes++;
            _context.Posts.Update(post);
            _context.SaveChanges();
            return RedirectToPage("/Index");
        }
    }
}