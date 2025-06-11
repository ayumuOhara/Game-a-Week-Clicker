using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MonsterData
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
}


[CreateAssetMenu(fileName = "MonsterData", menuName = "Scriptable Objects/MonsterData")]
public class Monster : ScriptableObject
{
    public List<MonsterData> monsterDatas;
}
