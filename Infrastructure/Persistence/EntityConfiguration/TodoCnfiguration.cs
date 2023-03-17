using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ToDoApplication.Core.Entities;
using ToDoApplication.Core.Enums;

namespace ToDoApplication.Infrastructure.Persistence;

class TodoCnfiguration: IEntityTypeConfiguration<Todo>
{
    public TodoCnfiguration(){}


    public void Configure(EntityTypeBuilder<Todo> todo)
    {
        todo.HasKey( t => t.id);
        todo.Property( t => t.title).IsRequired();
        todo.Property(t => t.priority).HasDefaultValue(Priority.Moderate);
        todo.Property(t => t.isDone).HasDefaultValue(false);
        todo.HasOne( t => t.todoGroup).WithMany( t => t.Todos);
        
        // TODO: Add db generated value for order (Max +1)
    }

}