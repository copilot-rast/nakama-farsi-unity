using System;

namespace PolicePatrol.Sdk.Ledger
{
    public sealed record LedgerEntry(
        string Id,
        string UserId,
        string Kind,
        string RefId,
        string Title,
        double? Amount,
        string Unit,
        string SourceId,
        DateTimeOffset CreatedAt);
}
