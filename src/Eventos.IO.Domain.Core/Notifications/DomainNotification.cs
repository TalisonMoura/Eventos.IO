﻿using Eventos.IO.Domain.Core.Events;

namespace Eventos.IO.Domain.Core.Notifications;

public class DomainNotification : MEvent
{
    public Guid DomainNotiricationId { get; private set; }
    public string Key { get; private set; }
    public string Value { get; private set; }
    public int Version { get; private set; }

    public DomainNotification(string key, string value)
    {
        DomainNotiricationId = Guid.NewGuid();
        Key = key;
        Value = value;
        Version = 1;
    }
}