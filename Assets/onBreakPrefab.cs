using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onBreakPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject particul;
    public GameObject sound;

    private void OnDestroy()
    {
        GameObject.Instantiate(particul, transform.position,transform.rotation);
        GameObject.Instantiate(sound, transform.position, transform.rotation);
    }
}
