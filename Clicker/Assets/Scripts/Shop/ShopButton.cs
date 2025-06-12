using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    ShopManager shopManager;
    ResourceManager resourceManager;

    [SerializeField] TextMeshProUGUI itemNameText;
    [SerializeField] TextMeshProUGUI elementCntText;

    int itemIndex;

    public void Initialize(ShopData data, int index)
    {
        resourceManager = GameObject.Find("ManaStone").GetComponent<ResourceManager>();
        shopManager = GameObject.Find("ShopManager").GetComponent<ShopManager>();
        itemIndex = index;

        itemNameText.text = data.itemName;
        elementCntText.text = data.elementCost.ToString();
    }

    public void OnClick()
    {
        // マナ以外は買い切り
        if(itemIndex < 8)
        {
            if (resourceManager.CheckCostCnt(shopManager.runtimeData[itemIndex]))
            {
                resourceManager.RemoveResource(shopManager.runtimeData[itemIndex]);
                shopManager.runtimeData[itemIndex].soldOut = true;

                if(itemIndex >= 3 && itemIndex <= 7)
                {
                    shopManager.BuyTools();
                }

                Button button = GetComponent<Button>();
                button.interactable = false;
            }
        }

        switch (itemIndex)
        {
            case 8:     // 火のマナ
                resourceManager.AddResources(0, 10, 0, 0);
                break;
            case 9:     // 水のマナ
                resourceManager.AddResources(0, 0, 10, 0);
                break;
            case 10:     // 木のマナ
                resourceManager.AddResources(0, 0, 0, 10);
                break;
            default:
                break;

        }
    }
}
