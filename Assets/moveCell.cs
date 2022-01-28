using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCell : MonoBehaviour
{
    public float speed = 2.0f;
    public Cell cell = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, cell.position, Time.deltaTime* speed);
    }
}
