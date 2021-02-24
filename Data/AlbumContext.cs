using Microsoft.EntityFrameworkCore;
using Mom3._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mom3._2.Data
{
    public class AlbumContext : DbContext
    {

        public AlbumContext(DbContextOptions<AlbumContext> options) : base(options)
        {

        }
        public DbSet<Album> Album { get; set; }
        public DbSet<Loan> Loan { get; set; }
        
    }
}
