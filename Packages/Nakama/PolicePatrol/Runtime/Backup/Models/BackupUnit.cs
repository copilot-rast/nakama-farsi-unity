using System;
using System.Collections.Generic;
using System.Linq;

namespace PolicePatrol.Sdk.Backup
{
    public sealed record BackupUnit(string Key, string Kind, string Title, string Icon, long Count)
    {
        public IReadOnlyList<string> UnityIds { get; init; } = Array.Empty<string>();

        public int Sort { get; init; }

        public int CallsPerMission { get; init; }

        public int SecondsBetweenCalls { get; init; }

        public int Used { get; init; }

        public int? CallsLeft { get; init; }

        public DateTimeOffset? NextCallAt { get; init; }

        public int SecondsUntilNextCall { get; init; }

        public bool IsGround => Kind == BackupKinds.Ground;

        public bool IsAir => Kind == BackupKinds.Air;

        public bool Serves(string unityId) => UnityIds.Count == 0 || (unityId != null && UnityIds.Contains(unityId));
    }
}
