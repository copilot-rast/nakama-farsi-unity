using PolicePatrol.Sdk.Unity;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Buy Card")]
public sealed class BuyCard : ScriptableObject, IShopProductCard
{
    [SerializeField] private string id;
    [SerializeField] private string title;
    [SerializeField, TextArea] private string description;
    [SerializeField, TextArea] private string message;
    [SerializeField] private bool oneTime;
    [SerializeField] private Sprite icon;
    [SerializeField] private Sprite cover;

    public string ProductKey => id;
    public string Title => title;
    public string Description => description;
    public string PurchaseMessage => message;
    public bool IsOneTime => oneTime;
    public Object Icon => icon;
    public Object Cover => cover;
}
