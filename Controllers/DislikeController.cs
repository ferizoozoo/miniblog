using MiniBlog.Context;
using Microsoft.AspNetCore.Mvc;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DislikeController : ControllerBase
    {
        private readonly MiniBlogContext _context;
        
        public DislikeController(MiniBlogContext context)
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
            post.DisLikes++;
            _context.Posts.Update(post);
            _context.SaveChanges();
            return RedirectToPage("/Index");
        }
    }
}