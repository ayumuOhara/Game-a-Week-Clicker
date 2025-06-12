using UnityEngine;
using System.Collections.Generic;

// 実行中用のデータ
[System.Serializable]
public class RuntimeMonsterData
{
    public string monsterName;
    public int monsterCnt;

    public float elementCost;
    public float fireManaCost;
    public float waterManaCost;
    public float woodManaCost;

    public float elementGenarateCnt;
    public float fireManaGenarateCnt;
    public float waterManaGenarateCnt;
    public float woodManaGenarateCnt;

    public RuntimeMonsterData(MonsterData original)
    {
        monsterName = original.monsterName;
        monsterCnt = 0;

        elementCost = original.elementCost;
        fireManaCost = original.fireManaCost;
        waterManaCost = original.waterManaCost;
        woodManaCost = original.woodManaCost;

        elementGenarateCnt = original.elementGenarateCnt;
        fireManaGenarateCnt = original.fireManaGenarateCnt;
        waterManaGenarateCnt = original.waterManaGenarateCnt;
        woodManaGenarateCnt = original.woodManaGenarateCnt;
    }
}

public class MonsterManager : MonoBehaviour
{
    [SerializeField] Monster monster;
    public List<RuntimeMonsterData> runtimeData;

    ResourceManager resourceManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resourceManager = GameObject.Find("ManaStone").GetComponent<ResourceManager>();
        runtimeData = new List<RuntimeMonsterData>();

        foreach(var data in monster.monsterDatas)
        {
            runtimeData.Add(new RuntimeMonsterData(data));
        }
    }

    // 作成したモンスターを+1体
    public void SummonMonster(int index)
    {
        var data = runtimeData[index];
        if (resourceManager.CheckCostCnt(data))
        {
            resourceManager.RemoveResource(data);
            data.monsterCnt += 1;
        }
    }
}
