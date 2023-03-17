using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using ToDoApplication.Core.Entities;

namespace ToDoApplication.Infrastructure.Persistence;
public class ToDoContext: IdentityDbContext
{
    public ToDoContext(DbContextOptions options) : base(options){}

    public DbSet<Card> cards {get;set;}
    public DbSet<TodoGroup> todoGroups {get;set;}
    public DbSet<Todo> todos {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder options){}
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        new CardConfiguration().Configure(builder.Entity<Card>());
        new TodoGroupConfiguration().Configure(builder.Entity<TodoGroup>());
        new TodoCnfiguration().Configure(builder.Entity<Todo>());
    }
}
