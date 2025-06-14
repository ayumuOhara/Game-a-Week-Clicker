using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEditor.UI;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class ClickerUIManager : MonoBehaviour
{
    ClickerController clickerController;

    [SerializeField] Monster monster;
    [SerializeField] GameObject monsterCreateButton;
    [SerializeField] Shop shop;
    [SerializeField] GameObject itemBuyButton;

    [SerializeField] List<GameObject> StoneTypeButtonList;

    ResourceManager resourceManager;
    TextMeshProUGUI elementCntText;
    TextMeshProUGUI fireManaCntText;
    TextMeshProUGUI waterManaCntText;
    TextMeshProUGUI woodManaCntText;

    Animator animator;

    void CreateButtons()
    {
        for(int i = 0; i < monster.monsterDatas.Count; i++)
        {
            Transform parent = GameObject.Find("MonsterContent").transform;
            GameObject button = Instantiate(monsterCreateButton, parent);
            MonsterButton monsterButton = button.GetComponent<MonsterButton>();
            monsterButton.Initialize(monster.monsterDatas[i], i);
        }

        for(int i = 0; i < shop.shopDatas.Count; i++)
        {
            Transform parent = GameObject.Find("ShopContent").transform;
            GameObject button = Instantiate(itemBuyButton, parent);
            ShopButton shopButton = button.GetComponent<ShopButton>();
            shopButton.Initialize(shop.shopDatas[i], i);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clickerController = GameObject.Find("ManaStone").GetComponent<ClickerController>();
        resourceManager = GameObject.Find("ManaStone").GetComponent<ResourceManager>();
        elementCntText = GameObject.Find("ElementCntText").GetComponent<TextMeshProUGUI>();
        fireManaCntText = GameObject.Find("ManaFireCntText").GetComponent<TextMeshProUGUI>();
        waterManaCntText = GameObject.Find("ManaWaterCntText").GetComponent<TextMeshProUGUI>();
        woodManaCntText = GameObject.Find("ManaWoodCntText").GetComponent<TextMeshProUGUI>();
        //facilityShop = GameObject.Find("UI").GetComponent<FacilityShop>();
        CreateButtons();
    }

    // Update is called once per frame
    void Update()
    {
        elementCntText.text = resourceManager.elementCnt.ToString("F0");
        fireManaCntText.text = resourceManager.fireManaCnt.ToString("F0");
        waterManaCntText.text = resourceManager.waterManaCnt.ToString("F0");
        woodManaCntText.text = resourceManager.woodManaCnt.ToString("F0");
    }

    void ActiveStoneButton()
    {
        for(int i = 0; i <= StoneTypeButtonList.Count; i++)
        {
            if(clickerController.manaStones[i].hasType == true)
            {
                StoneTypeButtonList[i].SetActive(true);
            }
        }
    }
}
