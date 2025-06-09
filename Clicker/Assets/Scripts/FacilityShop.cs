using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class FacilityShop : MonoBehaviour
{
    [SerializeField] Facility facility;                     // 施設のデータ

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

        // Facilityのデータをコピー
        for (int i = 0; i < facility.facilityDatas.Count; i++)
        {
            facilityLv.Add(facility.facilityDatas[i].lv);
            facilityCosts.Add((int)facility.facilityDatas[i].cost);
            facilityStart.Add(facility.facilityDatas[i].start);
        }
    }

    // 施設の購入ボタン押下処理
    public void OnClickFacility(int num)
    {
        if (CheckElementCnt(facilityCosts[num]))
        {
            clickerController.RemoveElementCnt(facilityCosts[num]);
            AddFacilityLv(num);
        }

        clickerUIManager.ButtonInactivate();
    }

    // 所持〇が施設の必要コストを満たしているか
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

    // 施設のレベルを上げる
    public void AddFacilityLv(int num)
    {
        facilityLv[num]++;
        var addCost = facility.facilityDatas[num].cost * 0.1f;      // 購入時、元の金額の10%をプラス
        facilityCosts[num] += (int)addCost;

        // 初めて施設を買ったとき、処理を開始
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
