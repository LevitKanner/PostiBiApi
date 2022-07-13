using Api.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Api;

public class ApplicationContext: DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
    {
        
    }

    public DbSet<Post>? Posts { get; set; }
}