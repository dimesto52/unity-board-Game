using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m3BonusBreak : MonoBehaviour
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
        cell.container.Set_idObj(-1);
        GameObject.Destroy(this.gameObject);

        Cell curcell = null;

        curcell = cell.left;
        while (curcell != null)
        {
            if(curcell.gameObject != null)
                curcell.gameObject.SendMessage("Onbreak");
            curcell = curcell.left;
        }

        curcell = cell.right;
        while (curcell != null)
        {
            if (curcell.gameObject != null)
                curcell.gameObject.SendMessage("Onbreak");
            curcell = curcell.right;
        }




    }
}
