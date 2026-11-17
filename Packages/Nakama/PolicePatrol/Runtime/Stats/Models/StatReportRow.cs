namespace PolicePatrol.Sdk.Stats
{
    public sealed record StatReportRow(string Key, double Sent, double Accepted, double Total, double Best, string Status);
}
