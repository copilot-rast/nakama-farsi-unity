namespace PolicePatrol.Sdk
{
    public sealed record PagedResult<T>(T[] Items, int Total, int Page, int PageSize)
    {
        public bool HasNextPage => Page * PageSize < Total;
    }
}
