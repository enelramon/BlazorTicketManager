using Microsoft.EntityFrameworkCore;
using TicketManager.Models;

namespace TicketManager.DAL
{
    public class TicketContext : DbContext
    {     
        public TicketContext(DbContextOptions<TicketContext> Options) 
            : base(Options) { }
   
        public DbSet<Sistemas> Sistemas { get; set; }
    }
}
