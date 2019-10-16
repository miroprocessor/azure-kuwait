using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VoteRonaldoVsMessi.Infrastructure.Models;

namespace VoteRonaldoVsMessi.Infrastructure
{
    public class VoteContextDbApp : DbContext
    {
        public VoteContextDbApp(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Vote> Votes { get; set; }
    }
}
