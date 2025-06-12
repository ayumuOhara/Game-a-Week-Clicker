using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class ShopData
{
    public string itemName;
    public bool soldOut;
    public float elementCost;
}

[CreateAssetMenu(fileName = "ShopData", menuName = "Scriptable Objects/ShopData")]
public class Shop : ScriptableObject
{
    public List<ShopData> shopDatas;
}
