using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onBreakPrefab : MonoBehaviour
{
    public cellLink cell
    {
        get
        {
            return this.GetComponent<cellLink>();
        }
    }

    public bool sendBreak = false;
    bool readyToBreak = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToBreak)
        {
            GameObject.Instantiate(particul, transform.position, transform.rotation);
            GameObject.Instantiate(sound, transform.position, transform.rotation);

            needTo score = GameObject.FindObjectOfType<needTo>();
            if (score != null)
                score.onbreak(cell.board.container.getcell(cell.pos), -1);

            cell.board.container.setcell(cell.pos, -1);
            cell.board.gocontainer.setcell(cell.pos, null);

            GameObject.Destroy(this.gameObject);

            if(sendBreak)
            cell.board.SendMessage("isBreak", cell.pos);
        }

    }

    public GameObject particul;
    public GameObject sound;

    private void Onbreak()
    {

        //Debug.Log(cell.pos);

        readyToBreak = true;
    }
}
