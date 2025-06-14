using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MonsterButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    MonsterManager monsterManager;

    [SerializeField] TextMeshProUGUI monsterNameText;
    [SerializeField] TextMeshProUGUI elementCntText;
    [SerializeField] TextMeshProUGUI fireCntText;
    [SerializeField] TextMeshProUGUI waterCntText;
    [SerializeField] TextMeshProUGUI woodCntText;

    TextMeshProUGUI elementGeneCntText;
    TextMeshProUGUI fireGeneCntText;
    TextMeshProUGUI waterGeneCntText;
    TextMeshProUGUI woodGeneCntText;

    [SerializeField] GameObject descriptionWindow;

    Transform windowPos;

    int monsterIndex;

    public void Initialize(MonsterData data, int index)
    {
        monsterManager = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
        monsterIndex = index;

        GameObject window = Instantiate(descriptionWindow, transform.position, Quaternion.identity);
        windowPos = GameObject.Find("WindowPos").transform;
        window.transform.SetParent(windowPos, false);

        elementGeneCntText = window.transform.Find("ElementGeneCntText").GetComponent<TextMeshProUGUI>();
        fireGeneCntText = window.transform.Find("FireManaGeneCntText").GetComponent<TextMeshProUGUI>();
        waterGeneCntText = window.transform.Find("WaterManaGeneCntText").GetComponent<TextMeshProUGUI>();
        woodGeneCntText = window.transform.Find("WoodManaGeneCntText").GetComponent<TextMeshProUGUI>();

        elementGeneCntText.text = data.elementGenarateCnt.ToString();
        fireGeneCntText.text = data.fireManaGenarateCnt.ToString();
        waterGeneCntText.text = data.waterManaGenarateCnt.ToString();
        woodGeneCntText.text = data.woodManaGenarateCnt.ToString();

        descriptionWindow = window;
        HideWindow(); // èâä˙èÛë‘ÇÕîÒï\é¶

        monsterNameText.text = data.monsterName;
        elementCntText.text = data.elementCost.ToString();
        fireCntText.text = data.fireManaCost.ToString();
        waterCntText.text = data.waterManaCost.ToString();
        woodCntText.text = data.woodManaCost.ToString();
    }

    public void ActiveWindow()
    {
        descriptionWindow.SetActive(true);
    }

    public void HideWindow()
    {
        descriptionWindow.SetActive(false);
    }

    public void OnClick()
    {
        monsterManager.SummonMonster(monsterIndex);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ActiveWindow();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideWindow();
    }
}
