using TMPro;
using UnityEngine;

public class MonsterButton : MonoBehaviour
{
    MonsterManager monsterManager;

    [SerializeField] TextMeshProUGUI monsterNameText;
    [SerializeField] TextMeshProUGUI elementCntText;
    [SerializeField] TextMeshProUGUI fireCntText;
    [SerializeField] TextMeshProUGUI waterCntText;
    [SerializeField] TextMeshProUGUI woodCntText;

    int monsterIndex;

    public void Initialize(MonsterData data, int index)
    {
        monsterManager = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
        monsterIndex = index;

        monsterNameText.text = data.monsterName;
        elementCntText.text = data.elementCost.ToString();
        fireCntText.text = data.fireManaCost.ToString();
        waterCntText.text = data.waterManaCost.ToString();
        woodCntText.text = data.woodManaCost.ToString();
    }

    public void OnClick()
    {
        monsterManager.SummonMonster(monsterIndex);
    }
}
