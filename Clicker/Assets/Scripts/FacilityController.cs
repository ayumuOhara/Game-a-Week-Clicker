using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FacilityController : MonoBehaviour
{
    ClickerController clickerController;
    FacilityShop facilityShop;
    [SerializeField] Facility facility;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clickerController = GameObject.Find("ManaStone").GetComponent<ClickerController>();
        facilityShop = GameObject.Find("UI").GetComponent<FacilityShop>();
    }

    public IEnumerator AutoGet5Sec()
    {
        while (facilityShop.facilityLv[1] > 0)
        {
            clickerController.AddElementCnt(10 * facilityShop.facilityLv[1]);
            yield return new WaitForSeconds(5);
        }
    }

    public IEnumerator AutoGet3Sec()
    {
        while (facilityShop.facilityLv[2] > 0)
        {
            clickerController.AddElementCnt(15 * facilityShop.facilityLv[2]);
            yield return new WaitForSeconds(3);
        }
    }

    public IEnumerator AutoGet1Sec()
    {
        while (facilityShop.facilityLv[3] > 0)
        {
            clickerController.AddElementCnt(20 * facilityShop.facilityLv[3]);
            yield return new WaitForSeconds(1);
        }
    }
}
