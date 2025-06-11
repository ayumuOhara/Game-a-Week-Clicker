using UnityEngine;
using UnityEngine.Rendering;

public class ResourceManager : MonoBehaviour
{
    public float elementCnt { get; private set; } = 0;
    public float fireManaCnt { get; private set; } = 0;
    public float waterManaCnt { get; private set; } = 0;
    public float woodManaCnt { get; private set; } = 0;

    // 魔鉱石の属性のマナを増加
    public void ClickStone(ManaStone stone)
    {
        elementCnt++;

        switch (stone.stoneManaType)
        {
            case ManaStone.STONE_MANA_TYPE.FIRE:
                fireManaCnt++;
                break;
            case ManaStone.STONE_MANA_TYPE.WATER:
                waterManaCnt++; 
                break;
            case ManaStone.STONE_MANA_TYPE.WOOD:
                woodManaCnt++;
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
}
