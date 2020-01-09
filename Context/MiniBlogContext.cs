using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MiniBlog.Models;

namespace MiniBlog.Context
{
    public class MiniBlogContext : DbContext
    {
        public MiniBlogContext(DbContextOptions<MiniBlogContext> options)
            : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
    }
}