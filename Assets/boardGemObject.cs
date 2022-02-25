using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "gem", menuName = "board/gemObject", order = 1)]
public class boardGemObject : ScriptableObject
{
    public GameObject prefab;
    public boardGemBonusPrefab[] bonusList;
}

[System.Serializable]
public class boardGemBonusPrefab
{
    public boardGemBonusType type;
    public int minval;

    public GameObject prefab;
}
public enum boardGemBonusType
{
    horizontal, vertical,cross, square
}
