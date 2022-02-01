using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destrucOverTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float TimeOver = 2.0f;

    // Update is called once per frame
    void Update()
    {
        TimeOver -= Time.deltaTime;

        if(TimeOver <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
