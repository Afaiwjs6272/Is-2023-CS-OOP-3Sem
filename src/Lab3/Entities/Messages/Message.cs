using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class Message : IEquatable<Message>
{
    private Message(string header, string body, ImportanceLevel importanceLevel)
    {
        Header = header;
        Body = body;
        Importance = importanceLevel;
    }

    public string Header { get; }

    public string Body { get; }

    public ImportanceLevel Importance { get; }

    public bool Equals(Message? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Header == other.Header && Body == other.Body && Importance == other.Importance;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Message)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Header, Body, (int)Importance);
    }

    public class MessageBuilder
    {
        private string? _header;
        private string? _body;
        private ImportanceLevel _importance;

        public MessageBuilder WithHeader(string header)
        {
            _header = header;
            return this;
        }

        public MessageBuilder WithBody(string body)
        {
            _body = body;
            return this;
        }

        public MessageBuilder WithImportance(ImportanceLevel importanceLevel)
        {
            _importance = importanceLevel;
            return this;
        }

        public Message Build()
        {
            ArgumentNullException.ThrowIfNull(_header);
            ArgumentNullException.ThrowIfNull(_body);
            return new Message(_header, _body, _importance);
        }
    }
}