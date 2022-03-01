using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activLose : MonoBehaviour
{
    public BoardData board;
    public GameObject uiLose;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(uiLose != null)
        {
            if(board.alowMove <= 0 )
            {
                uiLose.SetActive(true);
            }
            else
            {
                uiLose.SetActive(false);
            }
        }
    }
}
