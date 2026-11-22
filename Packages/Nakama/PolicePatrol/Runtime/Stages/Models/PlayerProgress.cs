using System;
using System.Linq;

namespace PolicePatrol.Sdk.Stages
{
    public sealed record PlayerProgress(long Xp, int Level, long? NextLevelXp, PlayerChapter[] Chapters)
    {
        public int MaxStars { get; init; }

        public DateTimeOffset? ServerTime { get; init; }

        public PlayerChapter FreeRideChapter => Chapters?.FirstOrDefault(c => c.Key == StageProvider.FreeRideChapterKey) ?? Chapters?.FirstOrDefault(c => c.Kind == ChapterKinds.FreeRide);

        public FreeRideOfferSettings FreeRideOffers => FreeRideChapter?.FreeRideOffers ?? FreeRideOfferSettings.Defaults;

        public PlayerStage FindStage(string stageKey) => Chapters?.SelectMany(c => c.Stages).FirstOrDefault(s => s.Key == stageKey);

        public PlayerStage FindByUnityLevel(string unityLevelId, string context = null) =>
            Chapters?.SelectMany(c => c.Stages).FirstOrDefault(s => s.UnityLevelId == unityLevelId && (context == null || s.Context == context));

        public PlayerChapter[] PoiChapters(string poi = null) =>
            (Chapters ?? Array.Empty<PlayerChapter>()).Where(c => c.IsPoi && (poi == null || c.Settings.Poi == poi || J.Str(c.Metadata, "poi") == poi)).ToArray();
    }
}
