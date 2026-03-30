using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Enums;

namespace ToDoList.Infrastructure.Persistence.Configurations;

public class TodoListItemConfiguration : IEntityTypeConfiguration<TodoListItem>
{
    public void Configure(EntityTypeBuilder<TodoListItem> builder)
    {
        builder.ToTable("TodoListItems");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Title).IsRequired().HasMaxLength(300);
        builder.Property(i => i.Description).IsRequired(false).HasMaxLength(2000);
        builder.Property(i => i.Priority).HasConversion<string>().HasDefaultValue(Priority.Low);
        builder.Property(i => i.IsCompleted).IsRequired().HasDefaultValue(false);
        builder.Property(i => i.UpdatedAt).IsRequired();
        builder.Property(i => i.DueDate).IsRequired(false);
        builder.Property(i => i.CompletedAt).IsRequired(false);
    }
}
