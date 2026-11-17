namespace PolicePatrol.Sdk.Editor
{
    public sealed class ShopCardRow
    {
        public string Key { get; set; }

        public string Action { get; set; }

        public string ErrorCode { get; set; }

        public string Code
        {
            get => ErrorCode;
            set => ErrorCode = value;
        }
    }
}
