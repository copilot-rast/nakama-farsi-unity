using System;

namespace PolicePatrol.Sdk.Ledger
{
    public static class LedgerKinds
    {
        public const string Purchase = "purchase";
        public const string Gift = "gift";
        public const string Asset = "asset";
        public const string Stage = "stage";
        public const string Prize = "prize";
        public const string Admin = "admin";
        public const string Initial = "initial";
        public const string Other = "other";

        [Obsolete("Use LedgerKinds.Gift; the server has no gift_code kind")]
        public const string GiftCode = Gift;

        [Obsolete("The server has no cheat_code kind; cheat codes are logged under their own source kind")]
        public const string CheatCode = "cheat_code";

        [Obsolete("Use LedgerKinds.Admin; the server has one admin kind for grants and uses")]
        public const string AdminAdd = Admin;

        [Obsolete("Use LedgerKinds.Admin; the server has one admin kind for grants and uses")]
        public const string AdminUse = Admin;
    }
}
