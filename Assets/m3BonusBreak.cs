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

    public int type;

    public bool alreadyDestroy = false;

    private void Onbreak()
    {
        if (!alreadyDestroy)
        {
            alreadyDestroy = true;

            GameObject.Instantiate(particul, transform.position, transform.rotation);
            GameObject.Instantiate(sound, transform.position, transform.rotation);
            cell.container.Set_idObj(-1);
            GameObject.Destroy(this.gameObject);


            if (type == 0)
            {
                Cell curcell = null;
                curcell = cell.left;
                while (curcell != null)
                {
                    if (curcell.gameObject != null)
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
            else if (type == 1)
            {
                Cell curcell = null;
                curcell = cell.up;
                while (curcell != null)
                {
                    if (curcell.gameObject != null)
                        curcell.gameObject.SendMessage("Onbreak");
                    curcell = curcell.up;
                }

                curcell = cell.down;
                while (curcell != null)
                {
                    if (curcell.gameObject != null)
                        curcell.gameObject.SendMessage("Onbreak");
                    curcell = curcell.down;
                }
            }
            else if (type == 2)
            {
                Cell curcell1 = null;
                curcell1 = cell.left;
                while (curcell1 != null)
                {
                    if (curcell1.gameObject != null)
                        curcell1.gameObject.SendMessage("Onbreak");

                    Cell curcell = null;
                    curcell = curcell1.up;
                    while (curcell != null)
                    {
                        if (curcell.gameObject != null)
                            curcell.gameObject.SendMessage("Onbreak");
                        curcell = curcell.up;
                    }

                    curcell = curcell1.down;
                    while (curcell != null)
                    {
                        if (curcell.gameObject != null)
                            curcell.gameObject.SendMessage("Onbreak");
                        curcell = curcell.down;
                    }

                    curcell1 = curcell1.left;
                }

                curcell1 = cell.right;
                while (curcell1 != null)
                {
                    if (curcell1.gameObject != null)
                        curcell1.gameObject.SendMessage("Onbreak");

                    Cell curcell = null;
                    curcell = curcell1.up;
                    while (curcell != null)
                    {
                        if (curcell.gameObject != null)
                            curcell.gameObject.SendMessage("Onbreak");
                        curcell = curcell.up;
                    }

                    curcell = curcell1.down;
                    while (curcell != null)
                    {
                        if (curcell.gameObject != null)
                            curcell.gameObject.SendMessage("Onbreak");
                        curcell = curcell.down;
                    }

                    curcell1 = curcell1.right;
                }

                Cell curcell2 = null;
                curcell2 = cell.up;
                while (curcell2 != null)
                {
                    if (curcell2.gameObject != null)
                        curcell2.gameObject.SendMessage("Onbreak");
                    curcell2 = curcell2.up;
                }

                curcell2 = cell.down;
                while (curcell2 != null)
                {
                    if (curcell2.gameObject != null)
                        curcell2.gameObject.SendMessage("Onbreak");
                    curcell2 = curcell2.down;
                }
            }
        }
    }
}

