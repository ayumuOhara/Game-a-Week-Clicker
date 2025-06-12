using System.Collections.Generic;
using System.Collections;
using System.Resources;
using UnityEngine;
using UnityEngine.Rendering;

public class ResourceManager : MonoBehaviour
{
    MonsterManager monsterManager;

    public float elementCnt { get; private set; } = 100000000;
    public float fireManaCnt { get; private set; } = 0;
    public float waterManaCnt { get; private set; } = 0;
    public float woodManaCnt { get; private set; } = 0;

    float clickCnt = 1;

    private void Start()
    {
        monsterManager = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
    }

    // クリック数を2倍
    public void DoubleUpClickCnt()
    {
        clickCnt *= 2;
    }

    // 魔鉱石の属性のマナを増加
    public void ClickStone(ManaStone stone)
    {
        switch (stone.stoneManaType)
        {
            case ManaStone.STONE_MANA_TYPE.ELEMENT:
                elementCnt += clickCnt;
                break;
            case ManaStone.STONE_MANA_TYPE.FIRE:
                fireManaCnt += clickCnt;
                break;
            case ManaStone.STONE_MANA_TYPE.WATER:
                waterManaCnt += clickCnt; 
                break;
            case ManaStone.STONE_MANA_TYPE.WOOD:
                woodManaCnt += clickCnt;
                break;
            default:
                Debug.LogError("不正な値です");
                break;
        }
    }

    /// <summary>
    /// 以下のメソッドはモンスター専用
    /// </summary>

    // 全てのリソースを増加
    public void AddResources(float elementAdd, float fireAdd, float waterAdd, float woodAdd)
    {
        elementCnt += elementAdd;
        fireManaCnt += fireAdd;
        waterManaCnt += waterAdd;
        woodManaCnt += woodAdd;
    }

    // 毎秒リソース作成
    public IEnumerator GenerateResources()
    {
        while (true)
        {
            foreach (var data in monsterManager.runtimeData)
            {
                float cnt = data.monsterCnt;
                AddResources(
                    data.elementGenarateCnt * cnt,
                    data.fireManaGenarateCnt * cnt,
                    data.waterManaGenarateCnt * cnt,
                    data.woodManaGenarateCnt * cnt
                );
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    // 必要コストを満たしているか
    public bool CheckCostCnt(RuntimeMonsterData data)
    {
        return elementCnt >= data.elementCost &&
               fireManaCnt >= data.fireManaCost &&
               waterManaCnt >= data.waterManaCost &&
               woodManaCnt >= data.woodManaCost;
    }

    // 作成に必要なコスト分を減少
    public void RemoveResource(RuntimeMonsterData data)
    {
        elementCnt -= data.elementCost;
        fireManaCnt -= data.fireManaCost;
        waterManaCnt -= data.waterManaCost;
        woodManaCnt -= data.woodManaCost;
    }

    /// <summary>
    /// 以下のメソッドはショップ専用
    /// </summary>

    // 必要コストを満たしているか
    public bool CheckCostCnt(RuntimeShopData data)
    {
        return elementCnt >= data.elementCost;
    }

    // 作成に必要なコスト分を減少
    public void RemoveResource(RuntimeShopData data)
    {
        elementCnt -= data.elementCost;
    }
}
