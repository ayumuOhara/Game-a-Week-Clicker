using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEditor.UI;
using Unity.VisualScripting;

public class ClickerUIManager : MonoBehaviour
{
    //FacilityShop facilityShop;
    [SerializeField] Monster monster;
    [SerializeField] GameObject monsterCreateButton;

    ResourceManager resourceManager;
    TextMeshProUGUI elementCntText;
    TextMeshProUGUI fireManaCntText;
    TextMeshProUGUI waterManaCntText;
    TextMeshProUGUI woodManaCntText;
    [SerializeField] List<TextMeshProUGUI> facilityCostTextList;
    [SerializeField] List<TextMeshProUGUI> facilityLvTextList;

    //[SerializeField]
    //List<Button> buttons = new List<Button>();

    Animator animator;

    void CreateMonsterButtons()
    {
        for(int i = 0; i < monster.monsterDatas.Count; i++)
        {
            Transform parent = GameObject.Find("MonsterContent").transform;
            GameObject button = Instantiate(monsterCreateButton, parent);
            MonsterButton monsterButton = button.GetComponent<MonsterButton>();
            monsterButton.Initialize(monster.monsterDatas[i], i);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resourceManager = GameObject.Find("ManaStone").GetComponent<ResourceManager>();
        elementCntText = GameObject.Find("ElementCntText").GetComponent<TextMeshProUGUI>();
        fireManaCntText = GameObject.Find("ManaFireCntText").GetComponent<TextMeshProUGUI>();
        waterManaCntText = GameObject.Find("ManaWaterCntText").GetComponent<TextMeshProUGUI>();
        woodManaCntText = GameObject.Find("ManaWoodCntText").GetComponent<TextMeshProUGUI>();
        //facilityShop = GameObject.Find("UI").GetComponent<FacilityShop>();
        CreateMonsterButtons();
    }

    // Update is called once per frame
    void Update()
    {
        elementCntText.text = resourceManager.elementCnt.ToString("F0");
        fireManaCntText.text = resourceManager.fireManaCnt.ToString("F0");
        waterManaCntText.text = resourceManager.waterManaCnt.ToString("F0");
        woodManaCntText.text = resourceManager.woodManaCnt.ToString("F0");

        //for (int i = 0; i < facilityCostTextList.Count; i++)
        //{
        //    facilityCostTextList[i].text = facilityShop.facilityCosts[i].ToString();
        //}

        //for (int i = 0; i < facilityLvTextList.Count; i++)
        //{
        //    facilityLvTextList[i].text = facilityShop.facilityLv[i].ToString();
        //}
    }

    //// 施設の購入ボタンの有効・無効切り替え
    //public void ButtonInactivate()
    //{
    //    for (int i = 0; i < buttons.Count; i++)
    //    {
    //        if (facilityShop.CheckElementCnt(facilityShop.facilityCosts[i]))
    //        {
    //            buttons[i].interactable = true;     // 所持している〇が施設のコスト未満のとき、ボタンを無効
    //        }
    //        else
    //        {
    //            buttons[i].interactable = false;    // 所持している〇が施設のコスト以上のとき、ボタンを有効
    //        }
    //    }
    //}

    //IEnumerator OpenShoping()
    //{
    //    while (true)
    //    {
    //        ButtonInactivate();
    //        yield return null;
    //    }
    //}
}
