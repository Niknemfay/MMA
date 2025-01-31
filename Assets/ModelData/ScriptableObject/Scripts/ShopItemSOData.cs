using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemSOData", menuName = "Data/ShopItemSOData")]
public class ShopItemSOData : ScriptableObject {
    public float priceShopItem;
    public Sprite imageShopItem;
    public bool isOpened;
}