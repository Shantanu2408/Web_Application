using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Assesment1_2.Models
{
    public class MoviesContextData : DbContext
    {
        public MoviesContextData() : base("MoviesConnection")
        { }
        public DbSet<Movies> movies { get; set; }
    }
}