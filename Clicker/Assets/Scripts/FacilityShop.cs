using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class FacilityShop : MonoBehaviour
{
    [SerializeField] Facility facility;                     // �{�݂̃f�[�^

    ClickerController clickerController; 
    ClickerUIManager clickerUIManager;
    FacilityController facilityController;

    public List<int> facilityLv = new List<int>();
    public List<int> facilityCosts = new List<int>();
    public List<bool> facilityStart = new List<bool>();

    private void Start()
    {
        clickerController = GameObject.Find("ManaStone").GetComponent<ClickerController>();
        clickerUIManager = GameObject.Find("UI").GetComponent <ClickerUIManager>();
        facilityController = GameObject.Find("FacilityController").GetComponent <FacilityController>();

        // Facility�̃f�[�^���R�s�[
        for (int i = 0; i < facility.facilityDatas.Count; i++)
        {
            facilityLv.Add(facility.facilityDatas[i].lv);
            facilityCosts.Add((int)facility.facilityDatas[i].cost);
            facilityStart.Add(facility.facilityDatas[i].start);
        }
    }

    // �{�݂̍w���{�^����������
    public void OnClickFacility(int num)
    {
        if (CheckElementCnt(facilityCosts[num]))
        {
            clickerController.RemoveElementCnt(facilityCosts[num]);
            AddFacilityLv(num);
        }

        clickerUIManager.ButtonInactivate();
    }

    // �����Z���{�݂̕K�v�R�X�g�𖞂����Ă��邩
    public bool CheckElementCnt(int num)
    {
        if(clickerController.elementCnt >= num)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // �{�݂̃��x�����グ��
    public void AddFacilityLv(int num)
    {
        facilityLv[num]++;
        var addCost = facility.facilityDatas[num].cost * 0.1f;      // �w�����A���̋��z��10%���v���X
        facilityCosts[num] += (int)addCost;

        // ���߂Ď{�݂𔃂����Ƃ��A�������J�n
        if (facilityLv[num] > 0 && !facilityStart[num])
        {
            switch (num)
            {
                case 1:
                    StartCoroutine(facilityController.AutoGet5Sec());
                    break;
                case 2:
                    StartCoroutine(facilityController.AutoGet3Sec());
                    break;
                case 3:
                    StartCoroutine(facilityController.AutoGet1Sec());
                    break;
                default:
                    break;
            }

            facilityStart[num] = true;
        }
    }
}
