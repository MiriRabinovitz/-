
using Microsoft.EntityFrameworkCore;
using WebApplicationHBH.Models;

namespace WebApplicationHBH.DataContext;

public class ContacFormDbContext : DbContext
{

    public ContacFormDbContext(DbContextOptions<ContacFormDbContext> options) : base(options)
    {

    }
    public DbSet<ContactForm> ContactForm { get; set; }

}
