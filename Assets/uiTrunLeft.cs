using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiTrunLeft : MonoBehaviour
{

    public Text txt
    {
        get
        {
            return this.GetComponent<Text>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Turn Left : " + m3BoardData.allowTurn;
    }
}
