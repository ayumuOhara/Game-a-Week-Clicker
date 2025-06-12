using UnityEngine;
using System.Collections.Generic;
using System.Threading;

// ���s���p�̃f�[�^
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

    // �c�[���n
    public void BuyTools()
    {
        resourceManager.DoubleUpClickCnt();
    }
}
