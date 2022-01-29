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
        Debug.DrawLine(transform.position, cell.position, Color.yellow);

        if (Vector3.Distance(transform.position, cell.position) > 0.1f)
            transform.position = Vector3.Lerp(transform.position, cell.position, Time.deltaTime * speed);
        else
            transform.position = cell.position;
    }
}
