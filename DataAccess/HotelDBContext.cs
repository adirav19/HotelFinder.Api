using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HotelDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost; Database=HotelDB; Integrated Security = True;");
        }
        public DbSet<Hotel> Hotels { get; set; }

    }
}
