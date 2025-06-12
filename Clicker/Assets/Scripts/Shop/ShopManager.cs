using UnityEngine;
using System.Collections.Generic;
using System.Threading;

// 実行中用のデータ
[System.Serializable]
public class RuntimeShopData
{
    public string itemName;
    public bool soldOut;
    public float elementCost;

    public RuntimeShopData(ShopData original)
    {
        itemName = original.itemName;
        soldOut = original.soldOut;
        elementCost = original.elementCost;
    }
}

public class ShopManager : MonoBehaviour
{
    [SerializeField] Shop shop;
    public List<RuntimeShopData> runtimeData;

    ResourceManager resourceManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resourceManager = GameObject.Find("ManaStone").GetComponent<ResourceManager>();
        runtimeData = new List<RuntimeShopData>();

        foreach (var data in shop.shopDatas)
        {
            runtimeData.Add(new RuntimeShopData(data));
        }
    }

    // ツール系
    public void BuyTools()
    {
        resourceManager.DoubleUpClickCnt();
    }
}
