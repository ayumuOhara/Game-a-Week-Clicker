using UnityEngine;
using System.Collections.Generic;

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
    List<RuntimeMonsterData> runtimeData;

    ResourceManager resourceManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resourceManager = GameObject.Find("ManaStone").GetComponent<ResourceManager>();
        InvokeRepeating(nameof(GenerateResources), 1f, 1f);     // 毎秒リソースを作成

        runtimeData = new List<RuntimeMonsterData>();
       foreach(var data in monster.monsterDatas)
        {
            runtimeData.Add(new RuntimeMonsterData(data));
        }
    }

    void GenerateResources()
    {
        foreach (var data in runtimeData)
        {
            float cnt = data.monsterCnt;
            resourceManager.AddResources(
                data.elementGenarateCnt * cnt,
                data.fireManaGenarateCnt * cnt,
                data.waterManaGenarateCnt * cnt,
                data.woodManaGenarateCnt * cnt
            );
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
