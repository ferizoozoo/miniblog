using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiniBlog.Context;
using MiniBlog.Models;

namespace MiniBlog.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly MiniBlog.Context.MiniBlogContext _context;

        public IndexModel(MiniBlog.Context.MiniBlogContext context)
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
