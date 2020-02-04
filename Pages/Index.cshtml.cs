using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MiniBlog.Context;
using MiniBlog.Models;

namespace MiniBlog.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MiniBlogContext _context;
        int pageSize = 3;

        public IndexModel(ILogger<IndexModel> logger, MiniBlogContext context)
        {
            _logger = logger;
            _context = context;
        }

        public PaginatedList<Post> Posts { get; private set; }

        public async Task OnGetAsync(int? pageIndex)
        {
            IQueryable<Post> AllPosts = from s in _context.Posts
                                        orderby s.Id descending
                                        select s;

            Posts = await PaginatedList<Post>.CreateAsync(
                AllPosts.AsNoTracking(), pageIndex ?? 1, pageSize);        
        }

    }
}
