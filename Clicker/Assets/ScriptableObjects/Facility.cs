using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class FacilityData
{
    public string name;
    public int lv;
    public bool start;
    public float cost;
}

[CreateAssetMenu(fileName = "FacilityData", menuName = "Scriptable Objects/FacilityData")]
public class Facility : ScriptableObject
{
    public List<FacilityData> facilityDatas;
}
