using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class needEntryData : MonoBehaviour
{

    public m3BoardData board
    {
        get
        {
            return GameObject.FindObjectOfType<m3BoardData>();
        }
    }

    public GameObject needMesh;
    public Text count;

    gemCount gem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count.text = this.gem.counted.ToString();
    }

    public void setdata(gemCount gem)
    {
        this.gem = gem;
           GameObject prefab = null;
        if(gem.bonus == -1)
        {
            prefab = board.prefabCellContain[gem.gem];
        }
        else
        {
            prefab = board.prefabBonusContain[gem.bonus].prefab[gem.gem];
        }

        GameObject go = GameObject.Instantiate(prefab);
        go.transform.parent = needMesh.transform;
        go.transform.localPosition = Vector3.zero;

        gem.counted = gem.count;
    }

}
