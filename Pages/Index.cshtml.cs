using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public MiniBlogContext _context { get; }

        public IndexModel(ILogger<IndexModel> logger, MiniBlogContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IEnumerable<Post> Posts { get; private set; }

        public void OnGet()
        {
            Posts = from post in _context.Posts
                    orderby post descending
                    select post;
        }
    }
}
