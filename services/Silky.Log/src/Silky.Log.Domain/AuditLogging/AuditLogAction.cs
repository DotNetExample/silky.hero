﻿using System;
using Silky.EntityFrameworkCore.Entities;

namespace Silky.Log.Domain.AuditLogging;

public class AuditLogAction : IEntity
{
    public long Id { get; set; }
    public long AuditLogId { get; set; }

    public string HostName { get; set; }

    public string ServiceEntryId { get; set; }

    public string HostAddress { get; set; }

    public string ServiceName { get; set; }

    public string ServiceKey { get; set; }

    public string MethodName { get; set; }

    public string Parameters { get; set; }

    public bool IsDistributedTransaction { get; set; }

    public DateTimeOffset ExecutionTime { get; set; }

    public int ExecutionDuration { get; set; }

    public string ExceptionMessage { get; set; }

    public virtual AuditLog AuditLog { get; set; }

}