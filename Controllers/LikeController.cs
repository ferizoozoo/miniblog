// Attention : The two DislikeController.cs and LikeController.cs should be definitely refactored.

using MiniBlog.Context;
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
            // Check if the user is signed in, in order to like the content.
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("Identity/Account/Login");
            }
            
            var post = _context.Posts.Find(itemid);
            post.Likes++;
            _context.Posts.Update(post);
            _context.SaveChanges();
            // Check the security of this code for production!
            return Redirect(Request.Headers["referer"].ToString().ToLower() + $"#{post.Id}");
        }
    }
}