using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseInStart : MonoBehaviour
{

    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {

        transform.localScale = Vector3.zero;
    }

    float TimeOver = 0;

    // Update is called once per frame
    void Update()
    {
        if (TimeOver != 1.0f)
        {
            TimeOver += Time.deltaTime* speed;
            if (TimeOver > 1.0f)
                TimeOver = 1.0f;
            transform.localScale = TimeOver * Vector3.one;
        }
    }
}
