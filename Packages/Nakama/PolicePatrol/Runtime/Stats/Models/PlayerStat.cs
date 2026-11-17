using System;

namespace PolicePatrol.Sdk.Stats
{
    public sealed record PlayerStat(string Key, string Name, string Kind, double Total, double Best, DateTimeOffset? LastReportedAt);
}
