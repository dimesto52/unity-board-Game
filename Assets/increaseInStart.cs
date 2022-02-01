using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseInStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float TimeOver = 0;

    // Update is called once per frame
    void Update()
    {
        if (TimeOver != 1.0f)
        {
            TimeOver += Time.deltaTime;
            if (TimeOver > 1.0f)
                TimeOver = 1.0f;
            transform.localScale = TimeOver * Vector3.one;
        }
    }
}
