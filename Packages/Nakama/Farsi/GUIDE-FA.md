# راهنمای کوتاه یونیتی

این پکیج همان کلاینت رسمی Nakama است که لایهٔ nakama-farsi داخلش قرار گرفته. فقط همین یک پکیج را نصب کنید.

## ۱. نصب

این خط را به `Packages/manifest.json` اضافه کنید:

```json
"com.nakamafarsi.unity": "<آدرس ریپو>?path=/Packages/Nakama#dev"
```

پکیج `com.heroiclabs.nakama-unity` را جداگانه نصب نکنید؛ داخل همین پکیج هست.

## ۲. تنظیم

۱. از منوی Tools > Nakama Farsi > Create SDK Config فایل تنظیمات را بسازید.
۲. آدرس سرور، کلید سرور (server key) و زبان `fa` را وارد کنید.
۳. اگر بازی درگاه زرین‌پال یا زیبال دارد، آدرس برگشت (مثلاً `mygame://payment`) را هم بنویسید.

## ۳. ورود

```csharp
var client = NakamaFarsiRunner.Initialize(NakamaFarsiConfig.Load());
await client.LoginWithDeviceAsync(SystemInfo.deviceUniqueIdentifier);
```

نشست خودش ذخیره و تمدید می‌شود و سوکت هم خودش وصل می‌شود.

ورود با پیامک:

```csharp
var sent = await client.Phone.RequestCodeAsync("09121234567");
var result = await client.Phone.VerifyAsync(sent.Phone, code);
```

پیشرفت بازیکن مهمان روی همان شماره می‌ماند. اگر `result.NeedsProfile` درست بود، نام نمایشی بازیکن را بپرسید.

## ۴. صدا زدن سرور

برای هر RPC سرور یک تابع آماده هست:

```csharp
var boards = await client.Rpcs.Leaderboardx.ListAsync();
var tasks = await client.Rpcs.Economy.TasksListAsync();
```

* همه‌چیز اول از سوکت می‌رود و اگر سوکت قطع بود از HTTP.
* جواب خام سرور همیشه در `Raw` هست.
* خطای سرور به شکل `ApiException` می‌آید. کد خطا در `Error.Code` و متن آن در `Error.Message` است.

## ۵. خرید

```csharp
await client.Payments.BuyAsync(productId, PaymentMethods.Coins);          // با سکه
await NakamaFarsiStore.SetupAsync(client);                               // یک بار بعد از ورود
await NakamaFarsiStore.BuyAsync(productId);                              // کافه‌بازار یا مایکت
await NakamaFarsiGateway.BuyAsync(productId, PaymentMethods.ZarinPal);   // درگاه
```

* برای بازار از منوی Tools > Nakama Farsi > Store > Install Poolakey (Cafe Bazaar) کتابخانهٔ پولکی را نصب کنید.
* برای مایکت گزینهٔ Build for Myket را بزنید.
* وقتی سرور در حالت آزمایشی است یا بازی روی گوشی اندروید اجرا نمی‌شود، یک فروشگاه آزمایشی جای بازار و مایکت کار می‌کند و پولی گرفته نمی‌شود.
* ارسال خرید به سرور، تلاش دوباره و مصرف خرید (consume) را خود پکیج انجام می‌دهد. خریدی که به سرور نرسیده باشد، در اجرای بعدی بازی خودش ثبت می‌شود.

## ۶. چت و استیکر

```csharp
var room = await client.Chat.JoinRoomAsync("lobby");
client.Chat.MessageReceived += m => Show(m.IsSticker ? m.StickerUrl : m.Text);
await client.Chat.SendTextAsync(room.Id, "سلام");
await client.Chat.SendStickerAsync(room.Id, "happy/smile");
```

اگر سقف پیام روزانه پر شده باشد یا بازیکن آن استیکر را نداشته باشد، `ApiException` با کد و متن سرور می‌آید.

## ۷. نمونه‌ها

از Package Manager دو نمونهٔ Quick Start و Payments را وارد پروژه کنید.
