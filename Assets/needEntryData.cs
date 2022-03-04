using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class needEntryData : MonoBehaviour
{


    public gemSpawn board;

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

        if(gem.bonus > 0)
        {
            //Debug.Log(gem.gem);
            prefab = board.gems[gem.gem];
        }
        else
        {
            prefab = board.GetComponent<gemBonusSpawn>().paterns[gem.gem].bonusPrefab;
        }

        GameObject go = GameObject.Instantiate(prefab);
        go.transform.parent = needMesh.transform;
        go.transform.localPosition = Vector3.zero;

        gem.counted = gem.count;
        
    }

}
