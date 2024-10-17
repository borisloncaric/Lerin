using Lerin.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace Lerin.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
     : base(options)
        {
        }


  
        //tablica u bazi
    public DbSet<UserViewModel> Users { get; set; }
    }
}
