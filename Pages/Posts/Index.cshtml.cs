using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MiniBlog.Context;
using MiniBlog.Models;

namespace MiniBlog.Pages.Posts
{
    [Authorize(Roles = "Administrator")]
    public class IndexModel : PageModel
    {
        private readonly MiniBlogContext _context;

        public IndexModel(MiniBlogContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            Post = await _context.Posts.ToListAsync();
        }

    }
}
