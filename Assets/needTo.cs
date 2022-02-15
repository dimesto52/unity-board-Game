using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needTo : MonoBehaviour
{


    public List<gemCount> gemNeed = new List<gemCount>();

    public GameObject listneed;
    public GameObject entryList;

    public GameObject win;

    // Start is called before the first frame update
    void Start()
    {
        
        foreach(gemCount gem in gemNeed)
        {
            GameObject go = GameObject.Instantiate(entryList);
            go.transform.parent = listneed.transform;
            go.transform.localScale = Vector3.one;

            if (go.GetComponent<needEntryData>() == null)
                go.AddComponent<needEntryData>();

            go.GetComponent<needEntryData>().setdata(gem);

        }
        win.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        bool noWin = false;
        foreach (gemCount gem in gemNeed)
        {
            if (gem.counted > 0)
            {
                noWin = true;
            }
        }

        if(!noWin)
        {
            win.SetActive(true);
        }
        else
        {
            win.SetActive(false);
        }

    }

    internal void onbreak(int id, int type)
    {

        foreach (gemCount gem in gemNeed)
        {
            if(gem.gem == id && gem.bonus == type)
            {
                gem.counted--;
                if (gem.counted <= 0)
                    gem.counted = 0;
            }
        }
    }
}

[System.Serializable]
public class gemCount
{
    public int gem;
    public int bonus;
    public int count;
    public int counted;
}
