
namespace ToDoList.Infrastructure.Outbox;

public class OutboxMessage
{
    private OutboxMessage() { }
    public Guid Id { get; private set; }
    public string EventType { get; private set; } = string.Empty;
    public string Payload { get; private set; } = string.Empty;
    public DateTime OccurredOn { get; private set; }
    public DateTime? ProcessedOn { get; private set; }
    public Guid AggregateId { get; private set; }
    public string AggregateType { get; private set; } = string.Empty;
    public int RetryCount { get; private set; }
    public string? Error { get; private set; }

    public OutboxMessage (Guid id, string eventType, string payload, DateTime occurredOn, Guid aggregateId, string aggregateType)
    {
        Id = id;
        EventType = eventType;
        Payload = payload;
        AggregateId = aggregateId;
        AggregateType = aggregateType;
        OccurredOn = occurredOn;
    }

    public void MarkAsProcessed()
    {
        ProcessedOn = DateTime.UtcNow;
        Error = null;
    }
    public void MarkAsFailed(string error)
    {
        RetryCount++;
        Error = error;
    }
}