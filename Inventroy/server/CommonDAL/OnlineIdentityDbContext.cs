using CommonDAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL
{
    public class OnlineIdentityDbContext: IdentityDbContext
    {
        public OnlineIdentityDbContext(DbContextOptions<OnlineIdentityDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<User> User { get; set; }
    }
}
