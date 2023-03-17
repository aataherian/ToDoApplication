using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApplication.Core.Entities;

namespace ToDoApplication.Infrastructure.Persistence;

public class TodoGroupConfiguration: IEntityTypeConfiguration<TodoGroup>
{
    public TodoGroupConfiguration(){}


    public void Configure(EntityTypeBuilder<TodoGroup> todoGroup)
    {
        todoGroup.HasKey( t => t.id);
        todoGroup.Property( t => t.title).IsRequired();
        todoGroup.HasOne(t=> t.card).WithMany();
        //TODO: Add Db generated value for order ( Max +1)
    }
}