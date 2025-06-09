using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ClickerUIManager : MonoBehaviour
{
    FacilityShop facilityShop;

    ClickerController controller;
    TextMeshProUGUI elementCntText;
    TextMeshProUGUI fireManaCntText;
    TextMeshProUGUI waterManaCntText;
    TextMeshProUGUI woodManaCntText;
    GameObject shopPanel;
    GameObject monsterPanel;
    [SerializeField] List<TextMeshProUGUI> facilityCostTextList;
    [SerializeField] List<TextMeshProUGUI> facilityLvTextList;

    bool openShop;
    bool openMonster;

    [SerializeField]
    List<Button> buttons = new List<Button>();

    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GameObject.Find("ManaStone").GetComponent<ClickerController>();
        elementCntText = GameObject.Find("ElementCntText").GetComponent<TextMeshProUGUI>();
        fireManaCntText = GameObject.Find("ManaFireCntText").GetComponent<TextMeshProUGUI>();
        waterManaCntText = GameObject.Find("ManaWaterCntText").GetComponent<TextMeshProUGUI>();
        woodManaCntText = GameObject.Find("ManaWoodCntText").GetComponent<TextMeshProUGUI>();
        facilityShop = GameObject.Find("UI").GetComponent<FacilityShop>();
        shopPanel = GameObject.Find("ShopPanel").gameObject;
        monsterPanel = GameObject.Find("MonsterCreatePanel").gameObject;
        animator = shopPanel.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        elementCntText.text = controller.elementCnt.ToString();
        fireManaCntText.text = controller.fireManaCnt.ToString();
        waterManaCntText.text = controller.waterManaCnt.ToString();
        woodManaCntText.text = controller.woodManaCnt.ToString();

        for (int i = 0; i < facilityCostTextList.Count; i++)
        {
            facilityCostTextList[i].text = facilityShop.facilityCosts[i].ToString();
        }

        for (int i = 0; i < facilityLvTextList.Count; i++)
        {
            facilityLvTextList[i].text = facilityShop.facilityLv[i].ToString();
        }
    }

    // �{�݂̍w���{�^���̗L���E�����؂�ւ�
    public void ButtonInactivate()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (facilityShop.CheckElementCnt(facilityShop.facilityCosts[i]))
            {
                buttons[i].interactable = true;     // �������Ă���Z���{�݂̃R�X�g�����̂Ƃ��A�{�^���𖳌�
            }
            else
            {
                buttons[i].interactable = false;    // �������Ă���Z���{�݂̃R�X�g�ȏ�̂Ƃ��A�{�^����L��
            }
        }
    }

    IEnumerator OpenShoping()
    {
        while (true)
        {
            ButtonInactivate();
            yield return null;
        }
    }

    public void OnClickButton(int num)
    {
        Animator animator = new Animator();

        switch(num)
        {
            case 0:
                animator = monsterPanel.GetComponent<Animator>();
                openMonster = true;
                SlideAnim(animator, true);
                break;
            case 1:
                animator = shopPanel.GetComponent<Animator>();
                openShop = true;
                SlideAnim(animator, true);
                break;
            case 2:
                if(openMonster)
                {
                    animator = monsterPanel.GetComponent<Animator>();
                    SlideAnim(animator, false);
                }
                if (openShop)
                {
                    animator = shopPanel.GetComponent<Animator>();
                    SlideAnim(animator, false);
                }
                break;
        }
    }

    // �w�����UI�A�j���[�V����
    public void SlideAnim(Animator animator, bool slide)
    {
        if (slide)
        {
            animator.SetTrigger("SlideIn");
        }
        else
        {
            animator.SetTrigger("SlideOut");
        }
    }
}
