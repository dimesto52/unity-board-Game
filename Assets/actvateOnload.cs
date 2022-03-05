using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actvateOnload : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.SendMessage("doBreak", SendMessageOptions.DontRequireReceiver);
        Destroy(this.gameObject);
    }
    
}
