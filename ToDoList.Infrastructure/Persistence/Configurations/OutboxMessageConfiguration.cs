using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Infrastructure.Outbox;

namespace ToDoList.Infrastructure.Persistence.Configurations;

public class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        builder.ToTable("OutboxMessages");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.EventType).IsRequired().HasMaxLength(200);
        builder.Property(o => o.Payload).IsRequired();
        builder.Property(o => o.ProcessedOn).IsRequired(false);
        builder.Property(o => o.AggregateId).IsRequired();
        builder.Property(o => o.AggregateType).IsRequired().HasMaxLength(200);
        builder.Property(o => o.RetryCount).IsRequired().HasDefaultValue(0);
        builder.Property(o => o.Error).IsRequired(false);
        builder.HasIndex(o => o.ProcessedOn);
    }
}
