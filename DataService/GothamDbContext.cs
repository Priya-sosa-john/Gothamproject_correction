using DataService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService
{
    public class GothamDbContext : DbContext
    {
        public GothamDbContext(DbContextOptions<GothamDbContext> opt) : base(opt)
        {

        }

        public DbSet<outlet> outlets { get; set; }
        
    }
}
