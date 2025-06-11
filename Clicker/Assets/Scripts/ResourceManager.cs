using UnityEngine;
using UnityEngine.Rendering;

public class ResourceManager : MonoBehaviour
{
    public float elementCnt { get; private set; } = 0;
    public float fireManaCnt { get; private set; } = 0;
    public float waterManaCnt { get; private set; } = 0;
    public float woodManaCnt { get; private set; } = 0;

    // ���z�΂̑����̃}�i�𑝉�
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
}
