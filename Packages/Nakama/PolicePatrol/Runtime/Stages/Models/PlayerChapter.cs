using System;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Stages
{
    public sealed record PlayerChapter(
        string Key,
        string Name,
        int Order,
        bool Unlocked,
        int UnlockLevel,
        double StarPercent,
        PlayerMilestone[] Milestones,
        PlayerStage[] Stages)
    {
        public string Description { get; init; }

        public string IconUrl { get; init; }

        public string Address { get; init; }

        public JObject Metadata { get; init; } = new JObject();

        public StageLock[] Locks { get; init; } = Array.Empty<StageLock>();

        public int Stars { get; init; }

        public int MaxStars { get; init; }

        public ChapterSettings Settings { get; init; } = ChapterSettings.Empty;

        public string Kind => J.Str(Metadata, "kind");

        public bool IsPoi => Kind == ChapterKinds.Poi;

        public bool IsFreeRide => Key == StageProvider.FreeRideChapterKey || Kind == ChapterKinds.FreeRide;

        public FreeRideOfferSettings FreeRideOffers => IsFreeRide ? new FreeRideOfferSettings(Settings.Raw) : null;
    }
}
