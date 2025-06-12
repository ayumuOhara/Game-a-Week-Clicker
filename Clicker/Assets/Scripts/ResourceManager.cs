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

    // �N���b�N����2�{
    public void DoubleUpClickCnt()
    {
        clickCnt *= 2;
    }

    // ���z�΂̑����̃}�i�𑝉�
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
                Debug.LogError("�s���Ȓl�ł�");
                break;
        }
    }

    /// <summary>
    /// �ȉ��̃��\�b�h�̓����X�^�[��p
    /// </summary>

    // �S�Ẵ��\�[�X�𑝉�
    public void AddResources(float elementAdd, float fireAdd, float waterAdd, float woodAdd)
    {
        elementCnt += elementAdd;
        fireManaCnt += fireAdd;
        waterManaCnt += waterAdd;
        woodManaCnt += woodAdd;
    }

    // ���b���\�[�X�쐬
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

    // �K�v�R�X�g�𖞂����Ă��邩
    public bool CheckCostCnt(RuntimeMonsterData data)
    {
        return elementCnt >= data.elementCost &&
               fireManaCnt >= data.fireManaCost &&
               waterManaCnt >= data.waterManaCost &&
               woodManaCnt >= data.woodManaCost;
    }

    // �쐬�ɕK�v�ȃR�X�g��������
    public void RemoveResource(RuntimeMonsterData data)
    {
        elementCnt -= data.elementCost;
        fireManaCnt -= data.fireManaCost;
        waterManaCnt -= data.waterManaCost;
        woodManaCnt -= data.woodManaCost;
    }

    /// <summary>
    /// �ȉ��̃��\�b�h�̓V���b�v��p
    /// </summary>

    // �K�v�R�X�g�𖞂����Ă��邩
    public bool CheckCostCnt(RuntimeShopData data)
    {
        return elementCnt >= data.elementCost;
    }

    // �쐬�ɕK�v�ȃR�X�g��������
    public void RemoveResource(RuntimeShopData data)
    {
        elementCnt -= data.elementCost;
    }
}
