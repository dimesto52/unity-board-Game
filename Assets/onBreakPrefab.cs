using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onBreakPrefab : MonoBehaviour
{
    public Cell cell
    {
        get
        {
            return this.GetComponent<cellLink>().cell;
        }
    }
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

    private void Onbreak()
    {
        GameObject.Instantiate(particul, transform.position, transform.rotation);
        GameObject.Instantiate(sound, transform.position, transform.rotation);

        needTo score = GameObject.FindObjectOfType<needTo>();
        if (score != null)
            score.onbreak(cell.container.Get_idObj(), -1);

        cell.container.Set_idObj(-1);

        GameObject.Destroy(this.gameObject);
        
        

    }
}
