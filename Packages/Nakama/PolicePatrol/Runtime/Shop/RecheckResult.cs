using System.Collections.Generic;

namespace PolicePatrol.Sdk.Shop
{
    public sealed class RecheckResult
    {
        public RecheckResult(int confirmed, int alreadyDone, IReadOnlyList<string> pendingErrorCodes)
        {
            Confirmed = confirmed;
            AlreadyDone = alreadyDone;
            PendingErrorCodes = pendingErrorCodes ?? new List<string>();
        }

        public int Confirmed { get; }

        public int AlreadyDone { get; }

        public int StillPending => PendingErrorCodes.Count;

        public IReadOnlyList<string> PendingErrorCodes { get; }

        public bool HasRecovered => Confirmed > 0;
    }
}
