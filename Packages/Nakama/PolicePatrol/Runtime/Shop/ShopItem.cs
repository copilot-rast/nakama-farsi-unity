using PolicePatrol.Sdk.Prizes;

namespace PolicePatrol.Sdk.Shop
{
    public sealed class ShopItem
    {
        public ShopItem(Product product, string method, string storeSku)
        {
            Product = product;
            Method = method;
            StoreSku = storeSku;
        }

        public Product Product { get; }

        public string Method { get; }

        public string StoreSku { get; }

        public string Id => Product.Id;

        public string Name => Product.Name;

        public double OriginalPrice => Product.Price?.Amount ?? 0d;

        public double FinalPrice => Product.FinalPrice;

        public double DiscountPercent => Product.DiscountPercent;

        public bool HasDiscount => Product.HasDiscount || (Product.DiscountPercent > 0d && FinalPrice < OriginalPrice);

        public bool IsSubscription => Product.IsSubscription;

        public Prize Prize => Product.Prize;

        public string[] AssetIds => Product.AssetIds ?? new string[0];

        public string MediaSource => Product.MediaSource == ProductMediaSources.Asset || Product.MediaSource == ProductMediaSources.Addressable
            ? Product.MediaSource
            : ProductMediaSources.Upload;

        public bool UsesAssetMedia => MediaSource == ProductMediaSources.Asset;

        public bool UsesAddressableMedia => MediaSource == ProductMediaSources.Addressable;

        public string MediaAssetId => UsesAssetMedia ? Product.MediaAssetId : null;

        public string IconUrl => MediaSource == ProductMediaSources.Upload ? Product.Icon?.Url : null;

        public string CoverUrl => MediaSource == ProductMediaSources.Upload ? Product.Cover?.Url : null;

        public string IconAddress => UsesAddressableMedia ? Product.IconAddress : null;

        public string CoverAddress => UsesAddressableMedia ? Product.CoverAddress : null;

        public int MinLevel => Product.MinLevel;

        public int? MaxLevel => Product.MaxLevel;

        public bool Owned => Product.Owned == true;

        public bool LevelLocked => Product.LevelLocked == true;

        public bool IsOneTime => Product.IsOneTime;

        public string[] PhoneRequiredFor => Product.PhoneRequiredFor ?? new string[0];

        public bool NeedsPhone => Product.NeedsPhoneFor(Method);

        public string Title => TitleFor(null);

        public string TitleFor(string languageId) => LocalizedValues.Pick(Product.Names, languageId) ?? Product.Name;

        public string Description => DescriptionFor(null);

        public string DescriptionFor(string languageId) => LocalizedValues.Pick(Product.Descriptions, languageId);

        public string PurchaseMessage => PurchaseMessageFor(null);

        public string PurchaseMessageFor(string languageId) => LocalizedValues.Pick(Product.PurchaseMessages, languageId);
    }
}
